﻿namespace TMCWorkbench.Controls.Resettable
{
    partial class ResettableButtonControl
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
            this.btnAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAction.Location = new System.Drawing.Point(243, 0);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(119, 24);
            this.btnAction.TabIndex = 0;
            this.btnAction.Text = "button1";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // ResettableButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAction);
            this.Name = "ResettableButtonControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAction;
    }
}
