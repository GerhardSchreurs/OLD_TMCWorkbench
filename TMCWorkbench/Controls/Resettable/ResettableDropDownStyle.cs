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
    public partial class ResettableDropDownStyle : _ResettableDropDownHold, IRefreshableInit
    {
        private UCStyles _form;
        //private int? _oldID;

        public ResettableDropDownStyle()
        {
            InitializeComponent();
            //_form = new UCStyles();
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
            if (_form == null) _form = new UCStyles();

            DBManager.Instance.LoadStyles(refresh );

            var query = from style in DB.DBManager.Instance.Styles
                        where style.IsAlt == false
                        select new { style.Name, style.Style_id };

            Init(_form, query, "Name", "Style_id", 0, "== SELECT STYLE ==");
        }
    }
}
