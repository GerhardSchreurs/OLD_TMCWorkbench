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
    public partial class _ResettableDropDownHold : _ResettablePanel
    {
        private ResettableDropDownHelper _helper;
        private Form _editForm;
        private int? _oldIndex;

        public _ResettableDropDownHold()
        {
            InitializeComponent();

            //WORKAROUND
            //https://stackoverflow.com/questions/3064780/winforms-combobox-dropdown-and-autocomplete-window-both-appear
            this.ddList.KeyDown += Handle_DdList_KeyDown;
            this.Disposed += Handle_ResettableDropDown_Disposed;
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
        public void Init(Form editForm, IEnumerable<dynamic> list, string displayMember, string valueMember, int emptyID = 0, string emptyValue = null)
        {
            if (_editForm == null)
            {
                _editForm = editForm;
                _editForm.FormClosed += Handle_editForm_FormClosed;
                btnEdit.Click += Handle_BtnEdit_Click;
            }

            _helper = new ResettableDropDownHelper(this.ddList, resettableControl1, list, displayMember, valueMember, emptyID, emptyValue);
            _helper.DataBind();
        }

        private void Handle_BtnEdit_Click(object sender, EventArgs e)
        {
            _oldIndex = IdValue;
            _editForm.ShowDialog();
        }
         
        private void Handle_editForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((IRefreshableInit)this).Init(true);
            IdValue = _oldIndex;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TextValue
        {
            get => _helper?.TextValue ?? ""; //HACK: visual studio
            set
            {
                if (_helper == null) return;
                if (chkLock.Checked) return;

                _helper.TextValue = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TextValueOriginal
        {
            set => _helper.TextValueOriginal = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? IdValue
        {
            get => _helper?.IdValue ?? 0; //HACK: visual studio
            set
            {
                if (_helper == null) return;
                if (chkLock.Checked) return;
                _helper.IdValue = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? IdValueOriginal
        {
            set => _helper.IdValueOriginal = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void Reset()
        {
            if (chkLock.Checked) return;
            _helper.Reset();
        }

        private void Handle_ResettableDropDown_Disposed(object sender, EventArgs e)
        {
            this.ddList.KeyDown -= Handle_DdList_KeyDown;
        }

        private void Handle_DdList_KeyDown(object sender, KeyEventArgs e)
        {
            ddList.DroppedDown = false;
        }
    }
}
