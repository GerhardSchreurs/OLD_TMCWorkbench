﻿using System;
using System.Windows.Forms;

namespace TMCWorkbench.Controls
{
    public class IntegerTextBox : TextBox
    {
        public IntegerTextBox() : base()
        {
            this.KeyPress -= Handle_IntegerTextBox_KeyPress;
            this.KeyPress += Handle_IntegerTextBox_KeyPress;
        }

        private void Handle_IntegerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            this.KeyPress -= Handle_IntegerTextBox_KeyPress;
        }
    }
}
