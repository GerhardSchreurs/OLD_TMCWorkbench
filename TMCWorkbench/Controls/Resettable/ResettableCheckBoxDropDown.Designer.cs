
namespace TMCWorkbench.Controls.Resettable
{
    partial class ResettableCheckBoxDropDown
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
            this.resettableControl1 = new TMCWorkbench.Controls.ResettableControl();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.ddList = new TMCWorkbench.Controls.ControlCheckBoxDropDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Controls.Add(this.resettableControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkLock, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ddList, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 24);
            this.tableLayoutPanel1.TabIndex = 2;
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
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkLock.Location = new System.Drawing.Point(320, 3);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(15, 18);
            this.chkLock.TabIndex = 1;
            this.chkLock.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEdit.Location = new System.Drawing.Point(341, 0);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(22, 24);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "E";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // ddList
            // 
            this.ddList.CheckOnClick = true;
            this.ddList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ddList.DropDownHeight = 1;
            this.ddList.FormattingEnabled = true;
            this.ddList.IntegralHeight = false;
            this.ddList.Location = new System.Drawing.Point(114, 3);
            this.ddList.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ddList.Name = "ddList";
            this.ddList.Size = new System.Drawing.Size(200, 21);
            this.ddList.TabIndex = 3;
            this.ddList.ValueSeparator = ", ";
            // 
            // ResettableCheckBoxDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResettableCheckBoxDropDown";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public ResettableControl resettableControl1;
        protected System.Windows.Forms.CheckBox chkLock;
        protected System.Windows.Forms.Button btnEdit;
        private ControlCheckBoxDropDown ddList;
    }
}
