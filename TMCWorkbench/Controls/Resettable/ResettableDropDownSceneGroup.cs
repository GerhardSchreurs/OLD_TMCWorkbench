using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.DB;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDropDownSceneGroup : ResettableDropDownHold, IRefreshableInit
    {
        private UCSceneGroups _form;
        //private int? _oldID;

        public ResettableDropDownSceneGroup()
        {
            InitializeComponent();
            //_form = new UCSceneGroups();
            //_form.FormClosed += Handle_form_FormClosed;
            //btnEdit.Click += Handle_BtnEdit_Click;
        }

        //private void Handle_form_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    Init(true);
        //    IdValue = _oldID;
        //}

        //private void Handle_BtnEdit_Click(object sender, EventArgs e)
        //{
        //    _oldID = IdValue;
        //    _form.ShowDialog();
        //}

        public void Init(bool refresh = false)
        {
            if (_form == null) _form = new UCSceneGroups();

            DBManager.Instance.LoadSceneGroups(refresh);

            var query = from scenegroup in DB.DBManager.Instance.SceneGroups
                        select new { scenegroup.Name, scenegroup.Scenegroup_id };

            Init(_form, query, "Name", "Scenegroup_id", 0, "== SELECT SCENEGROUP ==");
        }
    }
}
