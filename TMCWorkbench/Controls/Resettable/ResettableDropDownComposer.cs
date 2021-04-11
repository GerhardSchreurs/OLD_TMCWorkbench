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

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDropDownComposer : ResettableDropDownHold, IRefreshableInit
    {
        private UCComposers _form;

        public ResettableDropDownComposer()
        {
            InitializeComponent();
            //_form = new UCComposers();
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
            if (_form == null) _form = new UCComposers();

            DBManager.Instance.LoadComposers(refresh);

            var query = from composer in DB.DBManager.Instance.Composers
                        select new { composer.Name, composer.Composer_id };

            Init(_form, query, "Name", "Composer_id", 0, "== SELECT COMPOSER ==");
        }
    }
}
