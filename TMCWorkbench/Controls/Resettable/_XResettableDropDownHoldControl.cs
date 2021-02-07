using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class _XResettableDropDownHoldControl : _ResettablePanel
    {
        //TODO: Make dynamic?
        //public void Wroah<T>
        //    (
        //    Action loadDataFunction,
        //    IEnumerable<dynamic> query, 
        //    string title, 
        //    string displayMember, 
        //    string valueMember
        //    ) where T : class
        //{
        //    loadDataFunction();

        //    var bindingSource = new BindingSource();
        //    var list = query.ToList();
        //    var s = (T)Activator.CreateInstance(typeof(T));
        //    s.Style_id = 0;
        //    s.Name = "== SELECT STYLE ==";

        //    list.Insert(0, new { s.Name, s.Style_id });

        //    bindingSource.DataSource = list;

        //    ddList.DisplayMember = "Name";
        //    ddList.ValueMember = "Style_id";
        //    ddList.AutoCompleteMode = AutoCompleteMode.Suggest;
        //    ddList.AutoCompleteSource = AutoCompleteSource.ListItems;
        //    ddList.DataSource = bindingSource;
        //}

        public _XResettableDropDownHoldControl()
        {
            InitializeComponent();
        }

        public string GetStringValue()
        {
            var value = string.Empty;

            if (ddList.SelectedIndex > 0)
            {
                dynamic item = ddList.SelectedItem;
                value = item.Name;
            }

            return value;
        }

        public int GetIntValue()
        {
            var value = 0;

            if (ddList.SelectedValue.IsNumeric())
            {
                value = ddList.SelectedValue.ToInt();
            }

            return value;
        }
    }
}
