
namespace TMCWorkbench.Controls
{
    partial class HistoryTextBoxStateControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelState = new System.Windows.Forms.Panel();
            this.txtNew = new TMCWorkbench.Controls.HistoryTextBoxControl();
            this.txtOld = new TMCWorkbench.Controls.HistoryTextBoxControl();
            this.panelState.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelState
            // 
            this.panelState.Controls.Add(this.txtOld);
            this.panelState.Controls.Add(this.txtNew);
            this.panelState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelState.Location = new System.Drawing.Point(0, 0);
            this.panelState.Name = "panelState";
            this.panelState.Size = new System.Drawing.Size(408, 263);
            this.panelState.TabIndex = 0;
            // 
            // txtNew
            // 
            this.txtNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNew.Location = new System.Drawing.Point(0, 0);
            this.txtNew.Multiline = true;
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(408, 20);
            this.txtNew.TabIndex = 0;
            // 
            // txtOld
            // 
            this.txtOld.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtOld.Location = new System.Drawing.Point(0, 20);
            this.txtOld.Multiline = true;
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(408, 20);
            this.txtOld.TabIndex = 1;
            // 
            // HistoryTextBoxStateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelState);
            this.Name = "HistoryTextBoxStateControl";
            this.Size = new System.Drawing.Size(408, 263);
            this.panelState.ResumeLayout(false);
            this.panelState.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelState;
        private HistoryTextBoxControl txtNew;
        private HistoryTextBoxControl txtOld;
    }
}
