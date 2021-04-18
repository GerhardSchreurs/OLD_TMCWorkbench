
namespace TMCWorkbench.Controls.Resettable
{
    partial class ResettableDoubleControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.TabIndex = 3;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.txtScore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(114, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 24);
            this.panel1.TabIndex = 1;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(0, 2);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(65, 20);
            this.txtScore.TabIndex = 1;
            this.txtScore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Handle_txtScore_KeyPress);
            // 
            // ResettableScoreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResettableScoreControl";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ResettableControl resettableControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtScore;
    }
}
