namespace TMCWorkbench.Controls.Resettable
{
    partial class ResettableTextAreaControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResettableTextAreaControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtArea = new FastColoredTextBoxNS.FastColoredTextBox();
            this.ctrResettable = new TMCWorkbench.Controls.ResettableControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ctrResettable, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtArea, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtArea
            // 
            this.txtArea.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtArea.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.txtArea.BackBrush = null;
            this.txtArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArea.CharHeight = 14;
            this.txtArea.CharWidth = 8;
            this.txtArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArea.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArea.IsReplaceMode = false;
            this.txtArea.Location = new System.Drawing.Point(114, 3);
            this.txtArea.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtArea.Name = "txtArea";
            this.txtArea.Paddings = new System.Windows.Forms.Padding(0);
            this.txtArea.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtArea.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtArea.ServiceColors")));
            this.txtArea.ShowLineNumbers = false;
            this.txtArea.Size = new System.Drawing.Size(248, 94);
            this.txtArea.TabIndex = 1;
            this.txtArea.Zoom = 100;
            // 
            // ctrResettable
            // 
            this.ctrResettable.Location = new System.Drawing.Point(0, 0);
            this.ctrResettable.Margin = new System.Windows.Forms.Padding(0);
            this.ctrResettable.Name = "ctrResettable";
            this.ctrResettable.Size = new System.Drawing.Size(114, 24);
            this.ctrResettable.TabIndex = 0;
            // 
            // ResettableTextAreaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResettableTextAreaControl";
            this.Size = new System.Drawing.Size(365, 100);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ResettableControl ctrResettable;
        private FastColoredTextBoxNS.FastColoredTextBox txtArea;
    }
}
