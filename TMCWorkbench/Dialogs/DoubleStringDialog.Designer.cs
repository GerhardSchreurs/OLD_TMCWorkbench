
namespace TMCWorkbench.Dialogs
{
    partial class DoubleStringDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAction = new System.Windows.Forms.Button();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.lblB = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAction.Location = new System.Drawing.Point(311, 134);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 9;
            this.btnAction.Text = "btnAction";
            this.btnAction.UseVisualStyleBackColor = true;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(109, 79);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(207, 20);
            this.txtB.TabIndex = 8;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(109, 53);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(207, 20);
            this.txtA.TabIndex = 7;
            // 
            // lblB
            // 
            this.lblB.Location = new System.Drawing.Point(12, 82);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(91, 13);
            this.lblB.TabIndex = 6;
            this.lblB.Text = "lblB";
            this.lblB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblA
            // 
            this.lblA.Location = new System.Drawing.Point(15, 56);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(88, 13);
            this.lblA.TabIndex = 5;
            this.lblA.Text = "lblA";
            this.lblA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DoubleStringDialog
            // 
            this.AcceptButton = this.btnAction;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAction;
            this.ClientSize = new System.Drawing.Size(398, 169);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DoubleStringDialog";
            this.Text = "DoubleStringDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblA;
    }
}