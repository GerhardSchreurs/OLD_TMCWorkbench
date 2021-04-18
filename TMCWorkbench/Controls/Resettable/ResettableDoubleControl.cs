using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.Tools;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDoubleControl : _ResettablePanel
    {
        public ResettableDoubleControl()
        {
            InitializeComponent();

            this.resettableControl1.OnReset -= Handle_OnReset;
            this.resettableControl1.OnReset += Handle_OnReset;
        }


        private void Handle_OnReset(object sender, EventArgs e)
        {
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

        public double? Value { 
            get
            {
                if (txtScore.Text.IsNumeric())
                {
                    return Converter.ToDouble(txtScore.Text);
                }

                return null;

            }
            set
            {
                if (value.HasValue)
                    txtScore.Text = value.Value.ToStr();
            }
        }

        private double? _valueOriginal;

        public double? ValueOriginal
        {
            private get => _valueOriginal;
            set
            {
                _valueOriginal = value;

                var orgValue = "null";
                var newValue = "null";

                if (_valueOriginal.HasValue)
                    orgValue = _valueOriginal.Value.ToStr();

                if (Value.HasValue)
                    newValue = Value.Value.ToStr();


                this.resettableControl1.SetToolTip(orgValue, newValue);
            }
        }

        private void Handle_txtScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
