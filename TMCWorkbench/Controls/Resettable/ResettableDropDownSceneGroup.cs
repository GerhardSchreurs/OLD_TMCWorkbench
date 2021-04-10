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
    public partial class ResettableDropDownSceneGroup : ResettableDropDownHold
    {
        public ResettableDropDownSceneGroup()
        {
            InitializeComponent();
        }

        public void Init()
        {
            DBManager.Instance.LoadSceneGroups();

            var query = from scenegroup in DB.DBManager.Instance.SceneGroups
                        select new { scenegroup.Name, scenegroup.Scenegroup_id };

            Init(query, "Name", "Scenegroup_id", 0, "== SELECT SCENEGROUP ==");
        }
    }
}
