namespace TMCWorkbench.Controls.Resettable
{
    partial class ResettableDateControl
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
            this.resettableControl1 = new TMCWorkbench.Controls.ResettableControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlMonth = new System.Windows.Forms.ComboBox();
            this.ddlYear = new System.Windows.Forms.ComboBox();
            this.ddlDay = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resettableControl1
            // 
            this.resettableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resettableControl1.Location = new System.Drawing.Point(0, 0);
            this.resettableControl1.Margin = new System.Windows.Forms.Padding(0);
            this.resettableControl1.Name = "resettableControl1";
            this.resettableControl1.Size = new System.Drawing.Size(114, 24);
            this.resettableControl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.resettableControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 24);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ddlDay);
            this.panel1.Controls.Add(this.ddlMonth);
            this.panel1.Controls.Add(this.ddlYear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(114, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 24);
            this.panel1.TabIndex = 1;
            // 
            // ddlMonth
            // 
            this.ddlMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMonth.FormattingEnabled = true;
            this.ddlMonth.Location = new System.Drawing.Point(69, 2);
            this.ddlMonth.Name = "ddlMonth";
            this.ddlMonth.Size = new System.Drawing.Size(118, 21);
            this.ddlMonth.TabIndex = 2;
            // 
            // ddlYear
            // 
            this.ddlYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlYear.FormattingEnabled = true;
            this.ddlYear.Location = new System.Drawing.Point(0, 2);
            this.ddlYear.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ddlYear.Name = "ddlYear";
            this.ddlYear.Size = new System.Drawing.Size(65, 21);
            this.ddlYear.TabIndex = 0;
            // 
            // ddlDay
            // 
            this.ddlDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDay.FormattingEnabled = true;
            this.ddlDay.Location = new System.Drawing.Point(191, 2);
            this.ddlDay.Name = "ddlDay";
            this.ddlDay.Size = new System.Drawing.Size(54, 21);
            this.ddlDay.TabIndex = 3;
            // 
            // ResettableDateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResettableDateControl";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ResettableControl resettableControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ddlMonth;
        private System.Windows.Forms.ComboBox ddlYear;
        private System.Windows.Forms.ComboBox ddlDay;
    }
}
