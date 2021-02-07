using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDropDown : _ResettablePanel
    {
        public ResettableDropDown()
        {
            InitializeComponent();
        }

        private string _displayMember;
        private string _valueMember;
        private IEnumerable<dynamic> _list;

        public void Init(IEnumerable<dynamic> list, string displayMember, string valueMember)
        {
            _list = list;
            _displayMember = displayMember;
            _valueMember = valueMember;

            var bindingSource = new BindingSource();
            bindingSource.DataSource = list;
            ddList.DisplayMember = displayMember;
            ddList.ValueMember = valueMember;
            ddList.AutoCompleteMode = AutoCompleteMode.Suggest;
            ddList.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddList.DataSource = bindingSource;

            this.resettableControl1.OnReset += ResettableControl1_OnReset;
        }

        private dynamic GetDynamicItemFromList(dynamic item, string property)
        {
            var propertyInfo = item.GetType().GetProperty(property);
            return propertyInfo.GetValue(item, null);
        }

        private string GetDisplayMember(dynamic item)
        {
            string value = GetDynamicItemFromList(item, _displayMember);
            return value;
        }

        private int GetValueMember(dynamic item)
        {
            int value = GetDynamicItemFromList(item, _valueMember);
            return value;
        }


        private string _value;
        private string _valueOriginal;
        private int? _id;
        private int? _idOriginal;

        public string TextValue
        {
            get 
            {
                dynamic item = ddList.SelectedItem;

                if (item == null)
                {
                    return "Unknown";
                }

                return GetDisplayMember(item);
            }
            set
            {
                if (value == null) return;

                this.resettableControl1.ResetToolTip();

                foreach (var item in _list)
                {
                    string listValue = GetDisplayMember(item);

                    if (listValue != null)
                    {
                        listValue = listValue.ToLow();
                    }

                    if (listValue != null && listValue == value.ToLow())
                    {
                        int id = GetValueMember(item);
                        ddList.SelectedValue = id;

                        _value = value;
                        _id = id;
                    }
                }
            }
        }

        public string TextValueOriginal
        {
            set
            {
                _valueOriginal = value;
                this.resettableControl1.SetToolTip(value, _value);
            }
        }

        public int? IdValueOriginal
        {
            set
            {
                _idOriginal = value;

                string currentValue = "null";
                string originalValue = "null";

                if (_id.HasValue)
                {
                    currentValue = _id.Value.ToStr();
                }
                if (_idOriginal.HasValue)
                {
                    originalValue = _idOriginal.Value.ToStr();
                }

                this.resettableControl1.SetToolTip(originalValue, currentValue);
            }
        }


        public int? IdValue
        {
            get
            {
                var item = ddList.SelectedItem;

                if (item == null)
                    return null;

                return GetValueMember(item);
            }
            set
            {
                this.resettableControl1.ResetToolTip();

                if (value.HasValue)
                {
                    ddList.SelectedValue = value.Value;
                    _id = value.Value;
                }
                else
                {
                    ddList.SelectedValue = 0;
                    _id = value;
                }
            }
        }

        private void ResettableControl1_OnReset(object sender, EventArgs e)
        {
            if (_valueOriginal != null)
            {
                TextValue = _valueOriginal;
            }
            else 
            {
                if (_idOriginal.HasValue)
                {
                    IdValue = _idOriginal;
                }
                else
                {
                    IdValue = 0;
                }
            }

        }



        //public string GetValue()
        //{
        //    dynamic item = ddList.SelectedItem;

        //    if (item == null)
        //    {
        //        return "Unknown";
        //    }

        //    var value = GetDynamicItemFromList(item, _displayMember);
        //    return value;
        //}

        //public bool SetValue(string text)
        //{
        //    if (text == null) return false;

        //    this.resettableControl1.ResetToolTip();

        //    foreach (var item in _list)
        //    {
        //        string value = GetDynamicItemFromList(item, _displayMember);

        //        if (value != null)
        //        {
        //            value = value.ToLow();
        //        }

        //        if (value != null && value == text.ToLow())
        //        {
        //            int id = GetDynamicItemFromList(item, _valueMember);
        //            ddList.SelectedValue = id;
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public void SetValue(int? id)
        {
            this.resettableControl1.ResetToolTip();

            if (id.HasValue)
            {
                ddList.SelectedValue = id.Value;
            }
            else
            {
                ddList.SelectedValue = 0;
            }
        }

        //private string _valueOriginal;
        //private int _idOriginal = -1;

        //public void SetValueOriginal(string text)
        //{
        //    _valueOriginal = text;
        //}

        //public void SetIdOriginal(int? id)
        //{
        //    if (id.HasValue)
        //    {
        //        _idOriginal = id.Value;
        //    }
        //    else
        //    {
        //        _idOriginal = -1;
        //    }
        //}

    }
}
