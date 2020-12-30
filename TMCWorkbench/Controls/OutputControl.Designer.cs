
namespace TMCWorkbench.Controls
{
    partial class OutputControl
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
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtHeaderYT = new TMCWorkbench.Controls.HistoryTextBoxStateControl();
            this.txtHeader = new TMCWorkbench.Controls.TextAreaStateControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSummaryYT = new TMCWorkbench.Controls.HistoryTextBoxStateControl();
            this.txtSummary = new TMCWorkbench.Controls.TextAreaStateControl();
            this.tableLayout.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 1;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Controls.Add(this.pnlHeader, 0, 0);
            this.tableLayout.Controls.Add(this.panel1, 0, 1);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 2;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Size = new System.Drawing.Size(570, 500);
            this.tableLayout.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.txtHeaderYT);
            this.pnlHeader.Controls.Add(this.txtHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(564, 94);
            this.pnlHeader.TabIndex = 17;
            // 
            // txtHeaderYT
            // 
            this.txtHeaderYT.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtHeaderYT.Location = new System.Drawing.Point(0, 44);
            this.txtHeaderYT.Name = "txtHeaderYT";
            this.txtHeaderYT.Size = new System.Drawing.Size(564, 29);
            this.txtHeaderYT.TabIndex = 1;
            this.txtHeaderYT.TextNew = "";
            this.txtHeaderYT.TextOrg = "";
            // 
            // txtHeader
            // 
            this.txtHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtHeader.Location = new System.Drawing.Point(0, 0);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(564, 44);
            this.txtHeader.TabIndex = 0;
            this.txtHeader.TextNew = "txtNew";
            this.txtHeader.TextOrg = "txtOld";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSummaryYT);
            this.panel1.Controls.Add(this.txtSummary);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 394);
            this.panel1.TabIndex = 18;
            // 
            // txtSummaryYT
            // 
            this.txtSummaryYT.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSummaryYT.Location = new System.Drawing.Point(0, 263);
            this.txtSummaryYT.Name = "txtSummaryYT";
            this.txtSummaryYT.Size = new System.Drawing.Size(564, 29);
            this.txtSummaryYT.TabIndex = 2;
            this.txtSummaryYT.TextNew = "";
            this.txtSummaryYT.TextOrg = "";
            // 
            // txtSummary
            // 
            this.txtSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSummary.Location = new System.Drawing.Point(0, 0);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(564, 263);
            this.txtSummary.TabIndex = 0;
            this.txtSummary.TextNew = "txtNew";
            this.txtSummary.TextOrg = "txtOld";
            // 
            // OutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OutputControl";
            this.Size = new System.Drawing.Size(570, 500);
            this.tableLayout.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel panel1;
        private HistoryTextBoxStateControl historyTextBoxStateControl1;
        private TextAreaStateControl txtHeader;
        private TextAreaStateControl txtSummary;
        private HistoryTextBoxStateControl txtHeaderYT;
        private HistoryTextBoxStateControl txtSummaryYT;
    }
}
