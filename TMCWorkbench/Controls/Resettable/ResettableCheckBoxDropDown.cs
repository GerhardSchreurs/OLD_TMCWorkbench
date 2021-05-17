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
    public partial class ResettableCheckBoxDropDown : _ResettablePanel
    {
        private ResettableCheckBoxDropDownHelper _helper;
        private Form _editForm;
        private int[] _oldIds;

        public ResettableCheckBoxDropDown()
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void Init(Form editForm, IEnumerable<dynamic> list, string displayMember, string valueMember)
        {
            if (_editForm == null)
            {
                _editForm = editForm;
                _editForm.FormClosed += Handle_editForm_FormClosed;
                btnEdit.Click += Handle_BtnEdit_Click;
            }

            _helper = new ResettableCheckBoxDropDownHelper(this.ddList, resettableControl1, list, displayMember, valueMember);
            _helper.DataBind();
        }

        private void Handle_BtnEdit_Click(object sender, EventArgs e)
        {
            _oldIds = GetIdValues();
            _editForm.ShowDialog();
        }

        private void Handle_editForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((IRefreshableInit)this).Init(true);
            SetIdValues(_oldIds);
        }

        public void SetIdValues(int[] ids)
        {
            if (_helper == null) return;
            if (chkLock.Checked)
            {
                _oldIds = ids;
                return;
            }
            _helper.SetIdValues(ids);
        }

        public int[] GetIdValues()
        {
            return _helper?.GetIdValues();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void Reset()
        {
            if (chkLock.Checked) return;
            _helper.Reset();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private void Handle_chkLock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLock.Checked == false)
                SetIdValues(_oldIds);
        }
    }
}
