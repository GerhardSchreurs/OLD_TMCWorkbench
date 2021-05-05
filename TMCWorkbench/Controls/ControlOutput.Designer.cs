
namespace TMCWorkbench.Controls
{
    partial class ControlOutput
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
            this.txtHeaderYT = new TMCWorkbench.Controls.ControlHistoryTextBoxState();
            this.txtHeader = new TMCWorkbench.Controls.ControlTextAreaState();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.txtSummaryYT = new TMCWorkbench.Controls.ControlHistoryTextBoxState();
            this.txtSummary = new TMCWorkbench.Controls.ControlTextAreaState();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.txtFooterYT = new TMCWorkbench.Controls.ControlHistoryTextBoxState();
            this.txtFooter = new TMCWorkbench.Controls.ControlTextAreaState();
            this.tableLayout.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 1;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Controls.Add(this.pnlHeader, 0, 0);
            this.tableLayout.Controls.Add(this.pnlSummary, 0, 1);
            this.tableLayout.Controls.Add(this.pnlFooter, 0, 2);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 3;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
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
            this.pnlHeader.Size = new System.Drawing.Size(564, 54);
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
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.txtSummaryYT);
            this.pnlSummary.Controls.Add(this.txtSummary);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummary.Location = new System.Drawing.Point(3, 63);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(564, 374);
            this.pnlSummary.TabIndex = 18;
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
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.txtFooterYT);
            this.pnlFooter.Controls.Add(this.txtFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(3, 443);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(564, 54);
            this.pnlFooter.TabIndex = 19;
            // 
            // txtFooterYT
            // 
            this.txtFooterYT.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFooterYT.Location = new System.Drawing.Point(0, 38);
            this.txtFooterYT.Name = "txtFooterYT";
            this.txtFooterYT.Size = new System.Drawing.Size(564, 10);
            this.txtFooterYT.TabIndex = 4;
            this.txtFooterYT.TextNew = "";
            this.txtFooterYT.TextOrg = "";
            // 
            // txtFooter
            // 
            this.txtFooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFooter.Location = new System.Drawing.Point(0, 0);
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.Size = new System.Drawing.Size(564, 38);
            this.txtFooter.TabIndex = 3;
            this.txtFooter.TextNew = "txtNew";
            this.txtFooter.TextOrg = "txtOld";
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
            this.pnlSummary.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSummary;
        private ControlHistoryTextBoxState historyTextBoxStateControl1;
        private ControlTextAreaState txtHeader;
        private ControlTextAreaState txtSummary;
        private ControlHistoryTextBoxState txtHeaderYT;
        private ControlHistoryTextBoxState txtSummaryYT;
        private System.Windows.Forms.Panel pnlFooter;
        private ControlHistoryTextBoxState txtFooterYT;
        private ControlTextAreaState txtFooter;
    }
}
