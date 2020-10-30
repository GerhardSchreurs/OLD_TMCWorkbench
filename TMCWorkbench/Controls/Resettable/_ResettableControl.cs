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
using TMCWorkbench.Extensions;

namespace TMCWorkbench.Controls
{
    //[Designer(typeof(ResettableControlContentDesigner))]
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ResettableControl : UserControl
    {
        public delegate void ResetEventHandler(object sender, EventArgs e);
        public event ResetEventHandler OnReset;

        private ToolTip _toopTip;

        private void RaiseOnReset()
        {
            OnReset?.Invoke(this, new EventArgs());
        }

        public ResettableControl()
        {
            InitializeComponent();

            //todo: dispose
            _toopTip = new ToolTip();
            _toopTip.AutoPopDelay = 10000;
            _toopTip.InitialDelay = 100;
            _toopTip.ReshowDelay = 500;
            _toopTip.ShowAlways = true;
            //TypeDescriptor.AddAttributes(this.pnlContent, new DesignerAttribute(typeof(ResettableControlPanelDesigner)));
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

        private string _toolTipValue;

        public void SetToolTip(string oldValue, string newValue)
        {
            _toopTip.SetToolTip(btnReset, oldValue);

            if (oldValue == newValue)
            {
                SetBlack();
            }
            else
            {
                SetRed();
            }
        }

        private void SetRed()
        {
            btnReset.ForeColor = Color.Red;
        }

        private void SetBlack()
        {
            btnReset.ForeColor = SystemColors.ControlText;
        }

        private void SetCompare(object a, object b)
        {
            if (!a.Equals(b))
            {
                SetRed();
            }
            else
            {
                SetBlack();
            }
        }

        public void SetToolTip(DateTime? oldValue, DateTime? newValue)
        {
            string valueOld = "";
            string valueNew = "";

            if (oldValue.HasValue)
            {
                valueOld = oldValue.Value.ToDateString();
            }
            if (newValue.HasValue)
            {
                valueNew = newValue.Value.ToDateString();
            }

            if (valueOld == valueNew)
            {
                SetBlack();
            }
            else
            {
                SetRed();
            }

            _toopTip.SetToolTip(btnReset, valueOld);
        }

        public void ResetToolTip()
        {
            _toopTip.SetToolTip(btnReset, "");
            btnReset.ForeColor = SystemColors.ControlText;
        }

        /// <summary>
        /// DO NOT USE
        /// </summary>
        //public string Tooltip
        //{
        //    get { return _toolTipValue; }
        //    set {
        //        _toolTipValue = value;
        //        _toopTip.SetToolTip(btnReset, value);
        //    }
        //}

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.ForeColor = SystemColors.ControlText;
            RaiseOnReset();
        }
    }
}
