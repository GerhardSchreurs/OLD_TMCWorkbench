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
    public partial class ResettableDropDownComposer : ResettableDropDownHold
    {
        public ResettableDropDownComposer()
        {
            InitializeComponent();
        }

        public void Init()
        {
            DBManager.Instance.LoadComposers();

            var query = from composer in DB.DBManager.Instance.Composers
                        select new { composer.Name, composer.Composer_id };

            Init(query, "Name", "Composer_id", 0, "== SELECT COMPOSER ==");
        }
    }
}
