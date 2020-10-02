using FastColoredTextBoxNS;
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

namespace TMCWorkbench
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();

            DBManager.Instance.LoadStyles();

            //var query = from style in DB.Manager.Instance.C.Styles
            //            select new { style.Name, style.Style_id };

            var query = from style in DB.DBManager.Instance.Styles where style.IsAlt == false
                        select new { style.Name, style.Style_id };

            var bindingSource = new BindingSource();
            bindingSource.DataSource = query.ToList();

            comBox1.DisplayMember = "Name";
            comBox1.ValueMember = "Style_id";
            comBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comBox1.DataSource = bindingSource;
        }
    }
}
