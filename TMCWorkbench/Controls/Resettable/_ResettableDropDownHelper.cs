using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.Helpers;

namespace TMCWorkbench.Controls.Resettable
{
    public class ResettableDropDownHelper
    {
        private ComboBox _box;
        private ResettableControl _resettableControl;
        private string _sourceValueMember;
        private string _sourceDisplayMember;
        private IEnumerable<dynamic> _sourceList;
        private List<dynamic> _targetList;

        private string _value;
        private string _valueOriginal;

        int _emptyID;
        string _emptyValue;

        private int? _id;
        private int? _idOriginal;

        private const string DISPLAYMEMBER = "DisplayMember";
        private const string VALUEMEMBER = "ValueMember";

        public ResettableDropDownHelper(ComboBox box, ResettableControl resttableControl, IEnumerable<dynamic> sourceList, string displayMember, string valueMember, int emptyID = 0, string emptyValue = null)
        {
            _sourceList = sourceList;
            _box = box;
            _resettableControl = resttableControl;

            _sourceValueMember = valueMember;         //Value (int)
            _sourceDisplayMember = displayMember;      //Name (string)
            _emptyID = emptyID;                         //0
            _emptyValue = emptyValue;                   //==== select =====

            _resettableControl.OnReset += ResettableControl1_OnReset;
        }

        //TODO: Ext?
        public static T GetValueFromAnonymousType<T>(object dataitem, string itemkey)
        {
            System.Type type = dataitem.GetType();
            T itemvalue = (T)type.GetProperty(itemkey).GetValue(dataitem, null);
            return itemvalue;
        }

        public void Reset()
        {
            _box.SelectedValue = 0;
            _resettableControl.ResetToolTip();
        }

        public void DataBind()
        {
            var bindingSource = new BindingSource();
            
            var sourceList = _sourceList.ToList();
            _targetList = new List<dynamic>();

            for (var i = 0; i<sourceList.Count; i++)
            {
                var sourceItem = sourceList[i];
                var sourceDisplayMember = DynamicHelper.GetPropertyValueFromDynamic<string>(sourceItem, _sourceDisplayMember);
                var sourceValueMember = DynamicHelper.GetPropertyValueFromDynamic<int>(sourceItem, _sourceValueMember);

                //I just couldn't figure it out, but this hack works!! Yej.
                if (i == 0 && _emptyValue != null)
                {
                    sourceDisplayMember = _emptyValue;
                    sourceValueMember = _emptyID;

                    _emptyValue = null;
                    i = -1;
                }

                var target = new
                {
                    DisplayMember = sourceDisplayMember,
                    ValueMember = sourceValueMember
                };

                _targetList.Add(target);
            }

            bindingSource.DataSource = _targetList;

            _box.DisplayMember = DISPLAYMEMBER;
            _box.ValueMember = VALUEMEMBER;
            _box.AutoCompleteMode = AutoCompleteMode.Suggest;
            _box.AutoCompleteSource = AutoCompleteSource.ListItems;
            _box.DataSource = bindingSource;
        }

        private dynamic GetDynamicItemFromList(dynamic item, string property)
        {
            //return item.GetPropertyValue(property);
            var propertyInfo = item.GetType().GetProperty(property);
            return propertyInfo.GetValue(item, null);
        }

        private string GetDisplayMember(dynamic item)
        {
            return (string)DynamicHelper.GetPropertyValueFromDynamic(item, DISPLAYMEMBER);
        }

        private int GetValueMember(dynamic item)
        {
            return (int)DynamicHelper.GetPropertyValueFromDynamic(item, VALUEMEMBER);
        }

        public string TextValue
        {
            get
            {
                dynamic item = _box.SelectedItem;

                if (item == null)
                {
                    return "Unknown";
                }

                return GetDisplayMember(item);
            }
            set
            {
                if (value == null) return;

                _resettableControl.ResetToolTip();

                foreach (var item in _targetList)
                {
                    string listValue = GetDisplayMember(item);

                    if (listValue != null)
                    {
                        listValue = listValue.ToLow();
                    }

                    if (listValue != null && listValue == value.ToLow())
                    {
                        int id = GetValueMember(item);
                        _box.SelectedValue = id;

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
                _resettableControl.SetToolTip(value, _value);
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

                _resettableControl.SetToolTip(originalValue, currentValue);
            }

        }

        public int? IdValue
        {
            get
            {
                var item = _box.SelectedItem;

                if (item == null)
                    return null;

                return GetValueMember(item);
            }
            set
            {
                _resettableControl.ResetToolTip();

                if (value.HasValue)
                {
                    _box.SelectedValue = value.Value;
                    _id = value.Value;
                }
                else
                {
                    _box.SelectedValue = 0;
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
    }
}
