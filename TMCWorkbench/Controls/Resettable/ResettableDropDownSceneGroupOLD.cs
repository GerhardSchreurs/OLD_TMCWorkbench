using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.DB;
using TMCWorkbench;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDropDownSceneGroupOLD : _XResettableDropDownHoldControl
    {
        public ResettableDropDownSceneGroupOLD()
        {
            InitializeComponent();
        }

        public override string LabelTitle
        {
            get => base.LabelTitle;
            set
            {
                base.LabelTitle = value;
                this.resettableControl1.Title = value;
            }
        }

        public void Init()
        {
            DBManager.Instance.LoadSceneGroups();

            var query = from scenegroup in DB.DBManager.Instance.SceneGroups
                        select new { scenegroup.Name, scenegroup.Scenegroup_id };

            var bindingSource = new BindingSource();
            var list = query.ToList();
            var s = new TMCDatabase.DBModel.Scenegroup();
            s.Scenegroup_id = 0;
            s.Name = "== SELECT SCENEGROUP ==";

            list.Insert(0, new { s.Name, s.Scenegroup_id });

            bindingSource.DataSource = list;

            ddList.DisplayMember = "Name";
            ddList.ValueMember = "Scenegroup_id";
            ddList.AutoCompleteMode = AutoCompleteMode.Suggest;
            ddList.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddList.DataSource = bindingSource;
        }

        public void Reset()
        {
            ddList.SelectedValue = 0;
        }

        public bool SetScenegroup(string text)
        {
            if (text.IsNotNullOrEmpty())
            {
                var scenegroup = DBManager.Instance.SceneGroups.Where(x => x.Name.ToLow() == text.ToLow()).FirstOrNull();

                if (scenegroup != null)
                {
                    ddList.SelectedValue = scenegroup.Scenegroup_id;
                    return true;
                }
            }

            ddList.SelectedValue = 0;
            return false;
        }

        public void SetScenegroup(int? id)
        {
            if (id.HasValue)
            {
                ddList.SelectedValue = id.Value;
            }
            else
            {
                ddList.SelectedValue = 0;
            }
        }
    }
}
