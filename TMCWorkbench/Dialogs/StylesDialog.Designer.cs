namespace TMCWorkbench.Dialogs
{
    partial class StylesDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.radStyle = new System.Windows.Forms.RadioButton();
            this.radAlt = new System.Windows.Forms.RadioButton();
            this.pnlRadio = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlRadio.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Weight";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(106, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(106, 85);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(91, 20);
            this.txtWeight.TabIndex = 3;
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(311, 134);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 4;
            this.btnAction.Text = "btnAction";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // radStyle
            // 
            this.radStyle.AutoSize = true;
            this.radStyle.Location = new System.Drawing.Point(6, 3);
            this.radStyle.Name = "radStyle";
            this.radStyle.Size = new System.Drawing.Size(48, 17);
            this.radStyle.TabIndex = 6;
            this.radStyle.TabStop = true;
            this.radStyle.Text = "Style";
            this.radStyle.UseVisualStyleBackColor = true;
            // 
            // radAlt
            // 
            this.radAlt.AutoSize = true;
            this.radAlt.Location = new System.Drawing.Point(60, 3);
            this.radAlt.Name = "radAlt";
            this.radAlt.Size = new System.Drawing.Size(37, 17);
            this.radAlt.TabIndex = 7;
            this.radAlt.TabStop = true;
            this.radAlt.Text = "Alt";
            this.radAlt.UseVisualStyleBackColor = true;
            // 
            // pnlRadio
            // 
            this.pnlRadio.Controls.Add(this.radStyle);
            this.pnlRadio.Controls.Add(this.radAlt);
            this.pnlRadio.Location = new System.Drawing.Point(106, 30);
            this.pnlRadio.Name = "pnlRadio";
            this.pnlRadio.Size = new System.Drawing.Size(207, 23);
            this.pnlRadio.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StylesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 169);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlRadio);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StylesDialog";
            this.Text = "StylesDialog";
            this.pnlRadio.ResumeLayout(false);
            this.pnlRadio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.RadioButton radStyle;
        private System.Windows.Forms.RadioButton radAlt;
        private System.Windows.Forms.Panel pnlRadio;
        private System.Windows.Forms.Label label4;
    }
}