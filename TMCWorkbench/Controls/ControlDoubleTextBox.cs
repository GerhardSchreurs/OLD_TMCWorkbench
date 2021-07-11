using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls
{
    public class ControlDoubleTextBox : TextBox
    {
        public bool AllowsNegatives { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }

        public ControlDoubleTextBox() : base()
        {
            MaxValue = int.MaxValue;
            MinValue = int.MinValue;

            this.KeyPress -= Handle_ControlDoubleCheckbox_KeyPress;
            this.KeyPress += Handle_ControlDoubleCheckbox_KeyPress;
            this.KeyUp -= Handle_ControlDoubleCheckbox_KeyUp;
            this.KeyUp += Handle_ControlDoubleCheckbox_KeyUp;
        }

        public double? Result
        {
            get
            {
                if (Text.IsNumeric())
                    return Convert.ToDouble(Text);

                return null;
            }
            set
            {
                Text = value.ToString();
            }
        }

        private void Handle_ControlDoubleCheckbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (Text.IsNumeric())
            {
                double total = Convert.ToDouble(Text);

                if (total < MinValue || total > MaxValue)
                {
                    Text = _lastValue.ToString();
                    SelectionStart = _lastPosition;
                }

                _lastValue = Convert.ToDouble(Text);
                _lastPosition = this.SelectionStart;
            }
        }

        private double _lastValue = 0;
        private int _lastPosition = 0;

        private void Handle_ControlDoubleCheckbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isDigit = e.KeyChar >= '0' && e.KeyChar <= '9';
            bool isBackspace = e.KeyChar == '\b';
            bool isDot = e.KeyChar == ',';
            bool hasDot = Text.Contains(',');
            bool isDash = e.KeyChar == '-';
            bool hasText = Text.Length > 0;
            bool hasNoText = !hasText;

            if (isDigit == false)
            {
                if (AllowsNegatives && hasNoText && isDash)
                {
                    //Do nothing
                }
                else if (isDot && hasDot == false)
                {
                    //Do nothing
                }
                else if (isBackspace)
                {
                    //Do nothing
                }
                else
                {
                    //Everything else
                    e.Handled = true;
                }
            }
        }
    }
}
