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
    public partial class ResettableDropDownTracker : _ResettableDropDown
    {
        public ResettableDropDownTracker()
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
            DBManager.Instance.LoadTrackers();

            var query = from tracker in DB.DBManager.Instance.Trackers
                        select new { tracker.Name, tracker.Tracker_id };

            var bindingSource = new BindingSource();
            var list = query.ToList();

            bindingSource.DataSource = list;

            ddList.DisplayMember = "Name";
            ddList.ValueMember = "Tracker_id";
            ddList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ddList.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddList.DataSource = bindingSource;
        }

        public string GetTracker()
        {
            dynamic item = ddList.SelectedItem;

            if (item == null)
            {
                return "Unknown";
            }

            return item.Name;
        }

        public bool SetTracker(string text)
        {
            try
            {
                //HACK: FOR WINFORMS NULL REFERENCE
                //Cannot perform runtime binding on a null reference
                //Can't be bothered to figure out

                if (text == null) return false;

                var tracker = DB.DBManager.Instance.Trackers.Where(x => x.Name.ToLow() == text.ToLow()).FirstOrNull();

                if (tracker != null)
                {
                    ddList.SelectedValue = tracker.Tracker_id;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            return false;
        }

        public void SetTracker(int? id)
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
