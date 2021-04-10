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
        private ResettableDropDownHelper _helper;

        public ResettableDropDown()
        {
            InitializeComponent();
        }

        public void Init(IEnumerable<dynamic> list, string displayMember, string valueMember)
        {
            _helper = new ResettableDropDownHelper(this.ddList, resettableControl1, list, displayMember, valueMember);
            _helper.DataBind();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TextValue
        {
            get => _helper?.TextValue ?? ""; //HACK: visual studio
            set => _helper.TextValue = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TextValueOriginal
        {
            set =>_helper.TextValueOriginal = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? IdValue
        {
            get => _helper?.IdValue ?? 0; //HACK: visual studio
            set => _helper.IdValue = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? IdValueOriginal
        {
            set => _helper.IdValueOriginal = value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void Reset()
        {
            _helper.Reset();
        }
    }
}
