using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.Controls.Resettable;
using System.ComponentModel.Design;

namespace TMCWorkbench.Controls
{
    //[Designer(typeof(ResettableControlContentDesigner))]
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ResettableControl : UserControl
    {
        public delegate void ResetEventHandler(object sender, EventArgs e);
        public event ResetEventHandler OnReset;

        private void RaiseOnReset()
        {
            OnReset?.Invoke(this, new EventArgs());
        }

        public ResettableControl()
        {
            InitializeComponent();
            //TypeDescriptor.AddAttributes(this.pnlContent, new DesignerAttribute(typeof(ResettableControlPanelDesigner)));
        }

        public void Init()
        {
        }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public Panel ContentsPanel
        //{
        //    get { return pnlContent; }
        //}

        internal string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            RaiseOnReset();
        }
    }
}
