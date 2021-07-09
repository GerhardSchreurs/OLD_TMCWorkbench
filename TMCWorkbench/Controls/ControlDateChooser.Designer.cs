
namespace TMCWorkbench.Controls
{
    partial class ControlDateChooser
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
            this.pnlDateSaved1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ddlY = new System.Windows.Forms.ComboBox();
            this.ddlM = new System.Windows.Forms.ComboBox();
            this.ddlD = new System.Windows.Forms.ComboBox();
            this.pnlDateSaved1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDateSaved1
            // 
            this.pnlDateSaved1.Controls.Add(this.ddlY);
            this.pnlDateSaved1.Controls.Add(this.ddlM);
            this.pnlDateSaved1.Controls.Add(this.ddlD);
            this.pnlDateSaved1.Location = new System.Drawing.Point(0, 0);
            this.pnlDateSaved1.Name = "pnlDateSaved1";
            this.pnlDateSaved1.Size = new System.Drawing.Size(144, 34);
            this.pnlDateSaved1.TabIndex = 13;
            // 
            // ddlY
            // 
            this.ddlY.FormattingEnabled = true;
            this.ddlY.Location = new System.Drawing.Point(0, 0);
            this.ddlY.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.ddlY.Name = "ddlY";
            this.ddlY.Size = new System.Drawing.Size(50, 21);
            this.ddlY.TabIndex = 0;
            // 
            // ddlM
            // 
            this.ddlM.FormattingEnabled = true;
            this.ddlM.Location = new System.Drawing.Point(57, 0);
            this.ddlM.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.ddlM.Name = "ddlM";
            this.ddlM.Size = new System.Drawing.Size(40, 21);
            this.ddlM.TabIndex = 1;
            // 
            // ddlD
            // 
            this.ddlD.FormattingEnabled = true;
            this.ddlD.Location = new System.Drawing.Point(104, 0);
            this.ddlD.Margin = new System.Windows.Forms.Padding(0);
            this.ddlD.Name = "ddlD";
            this.ddlD.Size = new System.Drawing.Size(40, 21);
            this.ddlD.TabIndex = 2;
            // 
            // ControlDateChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDateSaved1);
            this.Name = "ControlDateChooser";
            this.Size = new System.Drawing.Size(144, 34);
            this.pnlDateSaved1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlDateSaved1;
        private System.Windows.Forms.ComboBox ddlY;
        private System.Windows.Forms.ComboBox ddlM;
        private System.Windows.Forms.ComboBox ddlD;
    }
}
