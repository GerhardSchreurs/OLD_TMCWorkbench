using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDoubleIntControl : _ResettableControlPanel
    {
        public ResettableDoubleIntControl()
        {
            InitializeComponent();

            InitBoxes();

            this.txtValueA.KeyPress += Handle_textBox_KeyPress;
            this.txtValueB.KeyPress += Handle_textBox_KeyPress;
            this.resettableControl1.OnReset += Handle_ResettableControl1_OnReset;
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

        void InitBoxes()
        {
            ValueA = _valueA;
            ValueB = _valueB;
        }

        private void Handle_ResettableControl1_OnReset(object sender, EventArgs e)
        {
            InitBoxes();
        }

        private void Handle_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int _valueA;
        private int _valueB;

        public int ValueA
        {
            get { return _valueA; }
            set { 
                _valueA = value;
                txtValueA.Text = value.ToString();
            }
        }

        public int ValueB
        {
            get { return _valueB; }
            set
            {
                _valueB = value;
                txtValueB.Text = value.ToString();
            }
        }

    }
}
