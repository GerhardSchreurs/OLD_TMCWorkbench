using PresentationControls;
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

namespace TMCWorkbench
{
    public partial class UCGroups : _UCForm
    {
        DBManager DB = DBManager.Instance;

        private Scenegroup _sceneGroup;

        public UCGroups()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DB.LoadSceneGroups();
            DB.LoadComposers();

            gridData.DataSource = DB.SceneGroups;

            var wrapper = new ListSelectionWrapper<Composer>(DB.Composers, "Name");

            ddlComposers.DataSource = wrapper;
            ddlComposers.DisplayMemberSingleItem = "Name";
            ddlComposers.DisplayMember = "NameConcatenated";
            ddlComposers.ValueMember = "Selected";
        }

        private void gridData_SelectionChanged(object sender, EventArgs e)
        {
            if (gridData.SelectedRows.Count == 0) return;

            _sceneGroup = gridData.SelectedRows[0].DataBoundItem as Scenegroup;
            txtName.Text = _sceneGroup.Name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_sceneGroup == null) return;

            _sceneGroup.Name = txtName.Text;

            gridData.Refresh();
        }
    }
}
