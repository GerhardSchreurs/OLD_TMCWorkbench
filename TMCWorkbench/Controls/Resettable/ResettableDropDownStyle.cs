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
    public partial class ResettableDropDownStyle : ResettableDropDownHold
    {
        public ResettableDropDownStyle()
        {
            InitializeComponent();
        }

        public void Init()
        {
            DBManager.Instance.LoadStyles();

            var query = from style in DB.DBManager.Instance.Styles
                        where style.IsAlt == false
                        select new { style.Name, style.Style_id };

            Init(query, "Name", "Style_id", 0, "== SELECT STYLE ==");
        }
    }
}
