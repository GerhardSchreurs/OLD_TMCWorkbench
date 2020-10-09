using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCDatabase.Model;
using TMCWorkbench.DB;
using Extensions;

namespace TMCWorkbench
{
    public partial class UCGroups : _UCForm
    {
        DBManager DB = DBManager.Instance;
        //BindingSource _sourceGridGroup;

        private Scenegroup _sceneGroup;
        private C_Scenegroup_Composer _groupsComposers;
        private Composer _composer;
        private List<Composer> _gridComposers;
        private List<Composer> _dropDownComposers;
        private int _gridGroupsIndex;
        private int _gridComposerIndex;

        public UCGroups()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DB.LoadSceneGroups();
            DB.LoadGroupsComposers();
            DB.LoadComposers();

            ddlComposers.AutoCompleteMode = AutoCompleteMode.Suggest;
            ddlComposers.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddlComposers.DisplayMember = "Name";
            ddlComposers.ValueMember = "Composer_id";

            BindGridGroup();
            BindComposerData();

            gridGroups.Select();
        }

        private void BindGridGroup()
        {
            gridGroups.SelectionChanged -= gridGroups_SelectionChanged;

            gridGroups.DataSource = null;
            gridGroups.DataSource = DB.SceneGroups.OrderByDescending(x => x.Scenegroup_id).ToList();
            gridGroups.ClearSelection();

            var index = _gridGroupsIndex;

            if (gridGroups.Rows.Count < _gridGroupsIndex)
            {
                _gridGroupsIndex = 0;
            }

            gridGroups.Rows[_gridGroupsIndex].Selected = true;
            gridGroups.CurrentCell = gridGroups.Rows[_gridGroupsIndex].Cells[0];
            gridGroups.SelectionChanged += gridGroups_SelectionChanged;
        }

        private List<Composer> GetGridComposers(int id)
        {
            //Don't know how to do it in linq/lambda

            var groupComposers = DB.GroupsComposers.Where(x => x.FK_scenegroup_id == id);

            var composers = new List<Composer>();

            foreach (var group in groupComposers)
            {
                composers.Add(DB.Composers.Where(c => c.Composer_id == group.FK_composer_id).FirstOrDefault());
            }

            return composers;
        }

        private void RetrieveComposerData(int id)
        {
            var groupComposers = DB.GroupsComposers.Where(x => x.FK_scenegroup_id == id);
            _gridComposers = new List<Composer>();
            _dropDownComposers = new List<Composer>();

            foreach (var group in groupComposers)
            {
                _gridComposers.Add(DB.Composers.Where(c => c.Composer_id == group.FK_composer_id).FirstOrDefault());
            }

            foreach (var composer in DB.Composers.OrderByDescending(c => c.Composer_id)) 
            {
                if (!_gridComposers.Contains(composer))
                {
                    _dropDownComposers.Add(composer);
                }
            }
        }

        private void BindComposerData()
        {
            gridComposers.SelectionChanged -= gridComposers_SelectionChanged;
            gridComposers.DataSource = null;

            if (_sceneGroup != null)
            {
                RetrieveComposerData(_sceneGroup.Scenegroup_id);

                gridComposers.DataSource = _gridComposers;
                gridComposers.ClearSelection();

                ddlComposers.DataSource = _dropDownComposers;
            }

            gridComposers.SelectionChanged += gridComposers_SelectionChanged;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gridGroups.SelectionChanged -= gridGroups_SelectionChanged;
            base.OnFormClosed(e);
        }


        void UpdateControls()
        {
            ctrName.Text = _sceneGroup.Name;

            if (_sceneGroup.Date_scenegroup_start.HasValue)
            {
                ctrDateStart.Date = _sceneGroup.Date_scenegroup_start.Value;
            }
            if (_sceneGroup.Date_scenegroup_stop.HasValue)
            {
                ctrDateStop.Date = _sceneGroup.Date_scenegroup_stop.Value;
            }

            ctrAbout.Text = _sceneGroup.About;

            BindComposerData();
        }

        private void gridGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (gridGroups.SelectedRows.Count == 0) return;

            _gridGroupsIndex = gridGroups.SelectedRows[0].Index;
            _sceneGroup = gridGroups.SelectedRows[0].DataBoundItem as Scenegroup;

            UpdateControls();
        }

        private void gridComposers_SelectionChanged(object sender, EventArgs e)
        {
            if (gridComposers.SelectedRows.Count == 0) return;

            _gridComposerIndex = gridComposers.SelectedRows[0].Index;
            _composer = gridComposers.SelectedRows[0].DataBoundItem as Composer;
        }

        private void Handle_btnAddScenegroup_Click(object sender, EventArgs e)
        {
            if (txtAddSceneGroup.Text.Length <= 0) return;

            var scenegroup = new Scenegroup();
            scenegroup.Name = txtAddSceneGroup.Text;
            DB.Add(scenegroup, true);

            BindGridGroup();

            //var x = DB.SceneGroups;

            //_sourceGridGroup.ResetBindings(true);
            //gridGroups.Refresh();
        }

        private void Handle_gridGroups_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            var rowsSelected = gridGroups.SelectedRows.Count;

            var result = MessageBox.Show("Are you sure?", $"You are about to delete {rowsSelected} row(s) from scenegroups", MessageBoxButtons.OKCancel);
        
            if (result == DialogResult .OK)
            {
                for (var i = rowsSelected - 1; i>=0; i--)
                {
                    var row = gridGroups.SelectedRows[i].DataBoundItem as Scenegroup;
                    DB.Remove(row);
                }
            }

            DB.Save();
            DB.LoadSceneGroups(true);
            BindGridGroup();
        }

        private void Handle_gridComposers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            var rowsSelected = gridComposers.SelectedRows.Count;

            var result = MessageBox.Show("Are you sure?", $"You are about to delete {rowsSelected} row(s) from composers in scenegroup", MessageBoxButtons.OKCancel);
            var composers = new List<Composer>();

            if (result == DialogResult.OK)
            {
                for (var i = rowsSelected - 1; i >= 0; i--)
                {
                    var row = gridComposers.SelectedRows[i].DataBoundItem as Composer;
                    composers.Add(row);
                }
            }

            if (composers.Count > 0)
            {
                DB.RemoveComposerFromGroup(_sceneGroup, composers);

                DB.Save();
                DB.LoadGroupsComposers(true);
                BindComposerData();
            }
        }

        private void ctrSave_OnButtonClick(object sender, EventArgs e)
        {
            if (ctrDateStart.IsValidDate())
            {
                _sceneGroup.Date_scenegroup_start = ctrDateStart.Date;
            }
            if (ctrDateStop.IsValidDate())
            {
                _sceneGroup.Date_scenegroup_stop = ctrDateStop.Date;
            }

            _sceneGroup.Name = ctrName.Text;
            _sceneGroup.About = ctrAbout.Text;

            DB.Replace(_sceneGroup);
            DB.Save();
            DB.LoadSceneGroups(true);
            BindGridGroup();

            gridGroups.Select();
        }

        private void btnAddComposer_Click(object sender, EventArgs e)
        {
            if (!ddlComposers.SelectedValue.IsNumeric()) return;

            DB.AddComposerToGroup(_sceneGroup.Scenegroup_id, ddlComposers.SelectedValue.ToInt());
            DB.Save();
            DB.LoadSceneGroups();
            DB.LoadGroupsComposers(true);
            BindComposerData();

            gridGroups.Select();
        }
    }
}
