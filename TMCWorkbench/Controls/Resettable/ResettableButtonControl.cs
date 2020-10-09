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
    public partial class ResettableButtonControl : _ResettableControlPanel
    {
        public event EventHandler OnButtonClick;

        public ResettableButtonControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void Handle_btnAction_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            OnButtonClick?.Invoke(this, e);
        }

        public override string LabelTitle
        {
            get => btnAction.Text;
            set => btnAction.Text = value;
        }
    }
}
