using System;
using System.Windows.Forms;

namespace TMCWorkbench.Controls
{
    public class ControlIntegerTextBox : TextBox
    {
        public bool AllowsNegatives { get; set; }

        public ControlIntegerTextBox() : base()
        {
            this.KeyPress -= Handle_IntegerTextBox_KeyPress;
            this.KeyPress += Handle_IntegerTextBox_KeyPress;
        }

        private void Handle_IntegerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (AllowsNegatives)
                {
                    if (e.KeyChar == '-' && Text.Length == 0)
                    {
                        //Do nothing
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            this.KeyPress -= Handle_IntegerTextBox_KeyPress;
        }
    }
}
