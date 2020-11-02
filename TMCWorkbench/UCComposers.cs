using TMCWorkbench;
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
using TMCDatabase.Model;
using TMCWorkbench.DB;

namespace TMCWorkbench
{
    public partial class UCComposers : _UCForm
    {
        DBManager DB = DBManager.Instance;

        private int _gridComposersIndex;
        private Composer _composer;
        private List<Scenegroup> _dropDownSceneGroups;
        private List<ScenegroupComposer> _sceneGroupComposers;
        private ScenegroupComposer _scenegroupComposer;




        public UCComposers()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DB.LoadComposers();
            DB.LoadSceneGroups();
            DB.LoadGroupsComposers();

            ddlScenegroups.AutoCompleteMode = AutoCompleteMode.Suggest;
            ddlScenegroups.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddlScenegroups.DisplayMember = "Name";
            ddlScenegroups.ValueMember = "Scenegroup_id";

            BindComposers(true);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gridComposers.SelectionChanged -= Handle_gridComposers_SelectionChanged;
            base.OnFormClosed(e);
        }

        private void BindComposers(bool select = false)
        {
            gridComposers.SelectionChanged -= Handle_gridComposers_SelectionChanged;

            gridComposers.DataSource = null;
            gridComposers.DataSource = DB.Composers.OrderByDescending(x => x.Composer_id).ToList();
            gridComposers.ClearSelection();

            if (gridComposers.Rows.Count < _gridComposersIndex)
            {
                _gridComposersIndex = 0;
            }

            gridComposers.Rows[_gridComposersIndex].Selected = true;
            gridComposers.CurrentCell = gridComposers.Rows[_gridComposersIndex].Cells[0];

            if (select)
            {
                gridComposers.Select();
                Handle_gridComposers_SelectionChanged(null, null);
            }

            gridComposers.SelectionChanged += Handle_gridComposers_SelectionChanged;
        }

        private void Handle_gridComposers_SelectionChanged(object sender, EventArgs e)
        {
            if (gridComposers.SelectedRows.Count == 0) return;

            _gridComposersIndex = gridComposers.SelectedRows[0].Index;
            _composer = gridComposers.SelectedRows[0].DataBoundItem as Composer;

            UpdateControls();
        }

        void UpdateControls()
        {
            ctrName.Text = _composer.Name;
            ctrDateStart.Date = _composer.Date_composer_start;
            ctrDateStop.Date = _composer.Date_composer_stop;
            ctrAbout.Text = _composer.About;
            ctrAliases.Text = _composer.Aliases;

            BindSceneGroups();
        }

        private void BindSceneGroups()
        {
            gridScenegroups.SelectionChanged -= Handle_gridGroups_SelectionChanged;
            gridScenegroups.DataSource = null;

            if (_composer != null)
            {
                RetrieveScenegroupComposerData(_composer.Composer_id);

                gridScenegroups.DataSource = _sceneGroupComposers;
                gridScenegroups.ClearSelection();

                ddlScenegroups.DataSource = _dropDownSceneGroups;
            }

            gridScenegroups.SelectionChanged += Handle_gridGroups_SelectionChanged;
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

            _dropDownSceneGroups = new List<Scenegroup>();

            var groupComposers = DB.GroupsComposers.Where(x => x.FK_composer_id == id);
            var scenegroups = new List<Scenegroup>();
            _sceneGroupComposers = new List<ScenegroupComposer>();

            foreach (var group in groupComposers)
            {
                _sceneGroupComposers.Add(new ScenegroupComposer(group, false));
                scenegroups.Add(group.Scenegroup);
            }

            foreach (var scenegroup in DB.SceneGroups.OrderByDescending(c => c.Scenegroup_id))
            {
                if (!scenegroups.Contains(scenegroup))
                {
                    _dropDownSceneGroups.Add(scenegroup);
                }
            }
        }

        private void Handle_gridGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (gridScenegroups.SelectedRows.Count == 0) return;

            _scenegroupComposer = gridScenegroups.SelectedRows[0].DataBoundItem as ScenegroupComposer;
        }

        private void Handle_btnAddComposer_Click(object sender, EventArgs e)
        {
            if (txtAddComposer.Text.Length <= 0) return;

            var composer = new Composer();
            composer.Name = txtAddComposer.Text;
            DB.Add(composer, true);

            BindComposers(true);
        }

        private void Handle_btnAddScenegroup_Click(object sender, EventArgs e)
        {
            if (!ddlScenegroups.SelectedValue.IsNumeric()) return;

            DB.AddComposerToGroup(ddlScenegroups.SelectedValue.ToInt(), _composer.Composer_id, chkIsComposer.Checked);
            //DB.AddComposerToGroup(_sceneGroup.Scenegroup_id, ddlComposers.SelectedValue.ToInt(), chkIsComposer.Checked);
            DB.Save();
            DB.LoadComposers();
            DB.LoadGroupsComposers(true);
            BindSceneGroups();

            gridScenegroups.Select();
        }

        private void Handle_ctrSave_OnButtonClick(object sender, EventArgs e)
        {
            _composer.Date_composer_start = ctrDateStart.Date;
            _composer.Date_composer_stop = ctrDateStop.Date;
            _composer.Name = ctrName.Text;
            _composer.About = ctrAbout.Text;
            _composer.Aliases = ctrAliases.Text;

            DB.Replace(_composer);
            DB.Save();
            DB.LoadComposers(true);
            BindComposers(true);
        }

        private void Handle_gridComposers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            var rowsSelected = gridComposers.SelectedRows.Count;

            var result = MessageBox.Show("Are you sure?", $"You are about to delete {rowsSelected} row(s) from composers", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                for (var i = rowsSelected - 1; i >= 0; i--)
                {
                    var row = gridComposers.SelectedRows[i].DataBoundItem as Composer;
                    DB.Remove(row);
                }
            }

            _gridComposersIndex -= rowsSelected;
            if (_gridComposersIndex < 0)
            {
                _gridComposersIndex = 0;
            }

            DB.Save();
            DB.LoadComposers(true);
            BindComposers();
        }

        private void Handle_gridScenegroups_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            var rowsSelected = gridScenegroups.SelectedRows.Count;

            var result = MessageBox.Show("Are you sure?", $"You are about to delete {rowsSelected} row(s) from composers in scenegroup", MessageBoxButtons.OKCancel);
            var scenegroups = new List<Scenegroup>();

            if (result == DialogResult.OK)
            {
                for (var i = rowsSelected - 1; i >= 0; i--)
                {
                    var row = gridScenegroups.SelectedRows[i].DataBoundItem as ScenegroupComposer;
                    scenegroups.Add(row.GetScenegroup());
                }
            }

            if (scenegroups.Count > 0)
            {
                DB.RemoveComposerFromGroup(_composer, scenegroups);

                DB.Save();
                DB.LoadGroupsComposers(true);
                BindSceneGroups();
            }
        }
    }
}
