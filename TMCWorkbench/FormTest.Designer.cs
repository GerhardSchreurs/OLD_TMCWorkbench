namespace TMCWorkbench
{
    partial class FormTest
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
            this.comBox1 = new System.Windows.Forms.ComboBox();
            this.resettableDropDownComposer1 = new TMCWorkbench.Controls.Resettable.ResettableDropDownComposer();
            this.SuspendLayout();
            // 
            // comBox1
            // 
            this.comBox1.FormattingEnabled = true;
            this.comBox1.Location = new System.Drawing.Point(321, 89);
            this.comBox1.Name = "comBox1";
            this.comBox1.Size = new System.Drawing.Size(121, 21);
            this.comBox1.TabIndex = 0;
            // 
            // resettableDropDownComposer1
            // 
            this.resettableDropDownComposer1.LabelTitle = null;
            this.resettableDropDownComposer1.Location = new System.Drawing.Point(212, 298);
            this.resettableDropDownComposer1.Margin = new System.Windows.Forms.Padding(0);
            this.resettableDropDownComposer1.Name = "resettableDropDownComposer1";
            this.resettableDropDownComposer1.Size = new System.Drawing.Size(365, 24);
            this.resettableDropDownComposer1.TabIndex = 1;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resettableDropDownComposer1);
            this.Controls.Add(this.comBox1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comBox1;
        private Controls.Resettable.ResettableDropDownComposer resettableDropDownComposer1;
    }
}