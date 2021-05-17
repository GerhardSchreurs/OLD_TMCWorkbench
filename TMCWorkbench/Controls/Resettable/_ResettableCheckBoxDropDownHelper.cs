using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCWorkbench.Helpers;

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
        private int[] _ids;

        public ResettableCheckBoxDropDownHelper(ControlCheckBoxDropDown box, ResettableControl resttableControl, IEnumerable<dynamic> sourceList, string displayMember, string valueMember)
        {
            _sourceList = sourceList;
            _box = box;
            _resettableControl = resttableControl;

            _sourceValueMember = valueMember;         //Value (int)
            _sourceDisplayMember = displayMember;      //Name (string)

            //_resettableControl.OnReset += ResettableControl1_OnReset;
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

            _box.Items.Clear();

            for (var i = 0; i < sourceList.Count; i++)
            {
                var sourceItem = sourceList[i];

                var sourceDisplayMember = DynamicHelper.GetPropertyValueFromDynamic<string>(sourceItem, _sourceDisplayMember);
                var sourceValueMember = DynamicHelper.GetPropertyValueFromDynamic<int>(sourceItem, _sourceValueMember);

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

        private void ResettableControl1_OnReset(object sender, EventArgs e)
        {
        }
    }
}
