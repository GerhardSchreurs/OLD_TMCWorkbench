using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCDatabase.DBModel;
using TMCWorkbench.DB;
using Extensions;
using TMCDatabase.Model;

namespace TMCWorkbench
{
    public partial class UCSceneGroups : _UCForm
    {
        DBManager DB = DBManager.Instance;
        //BindingSource _sourceGridGroup;

        private Scenegroup _sceneGroup;
        private ScenegroupComposer _scenegroupComposer;
        private List<C_Scenegroup_Composer> _groupsComposers;

        private List<ScenegroupComposer> _sceneGroupComposers;
        private List<Composer> _gridComposers;
        private List<Composer> _dropDownComposers;
        private int _gridGroupsIndex;

        public UCSceneGroups()
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

            BindSceneGroups();

            gridGroups.Select();
            Handle_gridGroups_SelectionChanged(null, null);
        }

        private void BindSceneGroups()
        {
            gridGroups.SelectionChanged -= Handle_gridGroups_SelectionChanged;

            gridGroups.DataSource = null;
            gridGroups.DataSource = DB.SceneGroups.OrderByDescending(x => x.Scenegroup_id).ToList();
            gridGroups.ClearSelection();

            if (gridGroups.Rows.Count < _gridGroupsIndex)
            {
                _gridGroupsIndex = 0;
            }

            gridGroups.Rows[_gridGroupsIndex].Selected = true;
            gridGroups.CurrentCell = gridGroups.Rows[_gridGroupsIndex].Cells[0];
            gridGroups.SelectionChanged += Handle_gridGroups_SelectionChanged;
        }

        private void BindComposers()
        {
            gridArtists.SelectionChanged -= Handle_gridArists_SelectionChanged;
            gridArtists.DataSource = null;

            if (_sceneGroup != null)
            {
                RetrieveScenegroupComposerData(_sceneGroup.Scenegroup_id);

                gridArtists.DataSource = _sceneGroupComposers;
                gridArtists.ClearSelection();

                ddlComposers.DataSource = _dropDownComposers;
            }

            gridArtists.SelectionChanged += Handle_gridArists_SelectionChanged;
        }

        private void RetrieveScenegroupComposerData(int id)
        {
            //var groupComposers = DB.GroupsComposers.Where(x => x.FK_scenegroup_id == id);
            //_gridComposers = new List<Composer>();
            //_dropDownComposers = new List<Composer>();

            //foreach (var group in groupComposers)
            //{
            //    _gridComposers.Add(DB.Composers.Where(c => c.Composer_id == group.FK_composer_id).FirstOrDefault());
            //}

            //foreach (var composer in DB.Composers.OrderByDescending(c => c.Composer_id))
            //{
            //    if (!_gridComposers.Contains(composer))
            //    {
            //        _dropDownComposers.Add(composer);
            //    }
            //}

            _dropDownComposers = new List<Composer>();

            var groupComposers = DB.GroupsComposers.Where(x => x.FK_scenegroup_id == id);
            var composers = new List<Composer>();
            _sceneGroupComposers = new List<ScenegroupComposer>();

            foreach (var group in groupComposers)
            {
                _sceneGroupComposers.Add(new ScenegroupComposer(group, true));
                composers.Add(group.Composer);
            }

            foreach (var composer in DB.Composers.OrderByDescending(c => c.Composer_id))
            {
                if (!composers.Contains(composer))
                {
                    _dropDownComposers.Add(composer);
                }
            }
        }



        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gridGroups.SelectionChanged -= Handle_gridGroups_SelectionChanged;
            gridArtists.SelectionChanged -= Handle_gridArists_SelectionChanged;
            base.OnFormClosed(e);
        }


        void UpdateControls()
        {
            ctrName.Text = _sceneGroup.Name;

            ctrDateStart.Date = _sceneGroup.Date_scenegroup_start;
            ctrDateStop.Date = _sceneGroup.Date_scenegroup_stop;

            ctrAbout.Text = _sceneGroup.About;

            BindComposers();
        }

        private void Handle_gridGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (gridGroups.SelectedRows.Count == 0) return;

            _gridGroupsIndex = gridGroups.SelectedRows[0].Index;
            _sceneGroup = gridGroups.SelectedRows[0].DataBoundItem as Scenegroup;

            UpdateControls();
        }

        private void Handle_gridArists_SelectionChanged(object sender, EventArgs e)
        {
            if (gridArtists.SelectedRows.Count == 0) return;

            _scenegroupComposer = gridArtists.SelectedRows[0].DataBoundItem as ScenegroupComposer;
        }

        private void Handle_btnAddScenegroup_Click(object sender, EventArgs e)
        {
            if (txtAddSceneGroup.Text.Length <= 0) return;

            var scenegroup = new Scenegroup();
            scenegroup.Name = txtAddSceneGroup.Text;
            DB.Add(scenegroup, true);

            BindSceneGroups();

            //var x = DB.SceneGroups;

            //_sourceGridGroup.ResetBindings(true);
            //gridGroups.Refresh();
        }

        private void Handle_gridSceneGroups_KeyUp(object sender, KeyEventArgs e)
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
            BindSceneGroups();
        }

        private void Handle_gridArtists_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            var rowsSelected = gridArtists.SelectedRows.Count;

            var result = MessageBox.Show("Are you sure?", $"You are about to delete {rowsSelected} row(s) from composers in scenegroup", MessageBoxButtons.OKCancel);
            var composers = new List<Composer>();

            if (result == DialogResult.OK)
            {
                for (var i = rowsSelected - 1; i >= 0; i--)
                {
                    var row = gridArtists.SelectedRows[i].DataBoundItem as ScenegroupComposer;
                    composers.Add(row.GetComposer());
                }
            }

            if (composers.Count > 0)
            {
                DB.RemoveComposerFromGroup(_sceneGroup, composers);

                DB.Save();
                DB.LoadGroupsComposers(true);
                BindComposers();
            }
        }

        private void Handle_ctrSave_OnButtonClick(object sender, EventArgs e)
        {
            _sceneGroup.Date_scenegroup_start = ctrDateStart.Date;
            _sceneGroup.Date_scenegroup_stop = ctrDateStop.Date;
            _sceneGroup.Name = ctrName.Text;
            _sceneGroup.About = ctrAbout.Text;

            DB.Replace(_sceneGroup);
            DB.Save();
            DB.LoadSceneGroups(true);
            BindSceneGroups();

            gridGroups.Select();
        }

        private void Handle_btnAddComposer_Click(object sender, EventArgs e)
        {
            if (!ddlComposers.SelectedValue.IsNumeric()) return;

            DB.AddComposerToGroup(_sceneGroup.Scenegroup_id, ddlComposers.SelectedValue.ToInt(), chkIsComposer.Checked);
            DB.Save();
            DB.LoadSceneGroups();
            DB.LoadGroupsComposers(true);
            BindComposers();

            gridGroups.Select();
        }
    }
}
