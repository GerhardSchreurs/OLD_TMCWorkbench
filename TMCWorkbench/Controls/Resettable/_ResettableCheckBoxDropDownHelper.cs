using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Controls.Resettable
{
    public class ResettableCheckBoxDropDownHelper
    {
        private ControlCheckBoxDropDown _box;
        private ResettableControl _resettableControl;
        private string _sourceValueMember;
        private string _sourceDisplayMember;
        private IEnumerable<dynamic> _sourceList;
        private List<dynamic> _targetList;

        private string _value;
        private string _valueOriginal;

        //int _emptyID;
        //string _emptyValue;

        private int? _id;
        private int? _idOriginal;

        private int[] _ids;

        private const string DISPLAYMEMBER = "DisplayMember";
        private const string VALUEMEMBER = "ValueMember";

        public ResettableCheckBoxDropDownHelper(ControlCheckBoxDropDown box, ResettableControl resttableControl, IEnumerable<dynamic> sourceList, string displayMember, string valueMember)
        {
            _sourceList = sourceList;
            _box = box;
            _resettableControl = resttableControl;

            _sourceValueMember = valueMember;         //Value (int)
            _sourceDisplayMember = displayMember;      //Name (string)

            //_resettableControl.OnReset += ResettableControl1_OnReset;
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
            var sourceList = _sourceList.ToList();
            _targetList = new List<dynamic>();


            for (var i = 0; i < sourceList.Count; i++)
            {
                var sourceItem = sourceList[i];

                var sourceDisplayMember = GetValueFromAnonymousType<string>(sourceItem, _sourceDisplayMember);
                var sourceValueMember = GetValueFromAnonymousType<int>(sourceItem, _sourceValueMember);


                var item = new CCBoxItem(sourceDisplayMember, sourceValueMember);
                _box.Items.Add(item);

                var target = new
                {
                    DisplayMember = sourceDisplayMember,
                    ValueMember = sourceValueMember
                };

                _targetList.Add(target);
            }

            _box.DisplayMember = _sourceDisplayMember;
            //_box.ValueMember = VALUEMEMBER;
            //_box.AutoCompleteMode = AutoCompleteMode.Suggest;
            //_box.AutoCompleteSource = AutoCompleteSource.ListItems;
            //_box.DataSource = bindingSource;
        }

        //TODO: ext?
        private dynamic GetDynamicItemFromList(dynamic item, string property)
        {
            //return item.GetPropertyValue(property);
            var propertyInfo = item.GetType().GetProperty(property);
            return propertyInfo.GetValue(item, null);
        }

        //TODO?
        private string GetDisplayMember(dynamic item)
        {
            string value = GetDynamicItemFromList(item, DISPLAYMEMBER);
            return value;
        }

        //TODO?
        private int GetValueMember(dynamic item)
        {
            int value = GetDynamicItemFromList(item, VALUEMEMBER);
            return value;
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

        public void SetIdValues(int[] ids)
        {
            _resettableControl.ResetToolTip();
            _box.DeselectAll();
            _box.SetItemsByIdChecked(ids);
            _ids = ids;
        }

        public int[] GetIdValues()
        {
            return _box.GetCheckedItemIds();
        }


        //public int[] IdValues
        //{
        //    get
        //    {
        //        return _box.GetCheckedItemIds();
        //    }
        //    set
        //    {
        //        _resettableControl.ResetToolTip();
        //        _box.DeselectAll();
        //        _box.SetItemsByIdChecked(value);
        //        _ids = value;
        //    }
        //}

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
