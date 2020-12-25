using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableDoubleIntControl : _ResettableControlPanel
    {
        public ResettableDoubleIntControl()
        {
            InitializeComponent();

            this.resettableControl1.OnReset += Handle_ResettableControl1_OnReset;
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

        void UpdateUI(int valueA, int valueB)
        {
            txtValueA.Text = valueA.ToStr();
            txtValueB.Text = valueB.ToStr() ;
        }

        private void Handle_ResettableControl1_OnReset(object sender, EventArgs e)
        {
            UpdateUI(_valueOriginalA, _valueOriginalB);
        }

        private void Handle_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int _valueOriginalA;
        private int _valueOriginalB;

        public void SetValues(int valueA, int valueB)
        {
            this.resettableControl1.ResetToolTip();

            ValueA = valueA;
            ValueB = valueB;

            UpdateUI(ValueA, ValueB);
        }

        public (int valueA, int valueB) GetValues()
        {
            var numA = 0;
            var numB = 0;

            if (txtValueA.Text.IsNumeric())
            {
                numA = txtValueA.Text.ToInt();
            }
            if (txtValueB.Text.IsNumeric())
            {
                numB = txtValueB.Text.ToInt();
            }

            return (numA, numB);
        }

        public void SetValuesOriginal(int valueA, int valueB)
        {
            _valueOriginalA = valueA;
            _valueOriginalB = valueB;

            var oldValue = $"{valueA}/{valueB}";
            var newValue = $"{ValueA}/{ValueB}";

            this.resettableControl1.SetToolTip(oldValue, newValue);
        }

        public int ValueA { get; private set; }

        public int ValueB { get; private set; }
    }
}
