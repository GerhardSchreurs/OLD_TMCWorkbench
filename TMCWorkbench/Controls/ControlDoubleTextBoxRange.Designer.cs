
namespace TMCWorkbench.Controls
{
    partial class ControlDoubleTextBoxRange
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ddlRange = new System.Windows.Forms.ComboBox();
            this.ctrDoubleTextbox = new TMCWorkbench.Controls.ControlDoubleTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ddlRange, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctrDoubleTextbox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(195, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ddlRange
            // 
            this.ddlRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.ddlRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.ddlRange.FormattingEnabled = true;
            this.ddlRange.ItemHeight = 12;
            this.ddlRange.Items.AddRange(new object[] {
            "",
            "==",
            "<=",
            ">="});
            this.ddlRange.Location = new System.Drawing.Point(0, 0);
            this.ddlRange.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ddlRange.Name = "ddlRange";
            this.ddlRange.Size = new System.Drawing.Size(32, 20);
            this.ddlRange.TabIndex = 0;
            // 
            // ctrDoubleTextbox
            // 
            this.ctrDoubleTextbox.AllowsNegatives = false;
            this.ctrDoubleTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrDoubleTextbox.Location = new System.Drawing.Point(35, 0);
            this.ctrDoubleTextbox.Margin = new System.Windows.Forms.Padding(0);
            this.ctrDoubleTextbox.MaxValue = 2147483647;
            this.ctrDoubleTextbox.MinValue = -2147483648;
            this.ctrDoubleTextbox.Name = "ctrDoubleTextbox";
            this.ctrDoubleTextbox.Result = null;
            this.ctrDoubleTextbox.Size = new System.Drawing.Size(160, 20);
            this.ctrDoubleTextbox.TabIndex = 0;
            // 
            // ControlDoubleTextBoxRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlDoubleTextBoxRange";
            this.Size = new System.Drawing.Size(195, 35);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox ddlRange;
        private ControlDoubleTextBox ctrDoubleTextbox;
    }
}
