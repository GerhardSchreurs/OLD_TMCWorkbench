namespace TMCWorkbench
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableOuter = new System.Windows.Forms.TableLayoutPanel();
            this.tableInner = new System.Windows.Forms.TableLayoutPanel();
            this.tablePlayer = new System.Windows.Forms.TableLayoutPanel();
            this.browserControl1 = new TMCWorkbench.Controls.BrowserControl();
            this.musicControl1 = new TMCWorkbench.Controls.MusicControl();
            this.listViewControl1 = new TMCWorkbench.Controls.ListViewControl();
            this.statusStrip1.SuspendLayout();
            this.tableOuter.SuspendLayout();
            this.tableInner.SuspendLayout();
            this.tablePlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(392, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder-icon.png");
            this.imageList1.Images.SetKeyName(1, "Document-Blank-icon.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 599);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1010, 20);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 15);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // tableOuter
            // 
            this.tableOuter.ColumnCount = 1;
            this.tableOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableOuter.Controls.Add(this.tableInner, 0, 0);
            this.tableOuter.Controls.Add(this.statusStrip1, 1, 1);
            this.tableOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOuter.Location = new System.Drawing.Point(0, 0);
            this.tableOuter.Name = "tableOuter";
            this.tableOuter.RowCount = 2;
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableOuter.Size = new System.Drawing.Size(1010, 619);
            this.tableOuter.TabIndex = 1;
            // 
            // tableInner
            // 
            this.tableInner.BackColor = System.Drawing.SystemColors.Control;
            this.tableInner.ColumnCount = 3;
            this.tableInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableInner.Controls.Add(this.browserControl1, 0, 0);
            this.tableInner.Controls.Add(this.tablePlayer, 2, 0);
            this.tableInner.Controls.Add(this.listViewControl1, 1, 0);
            this.tableInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableInner.Location = new System.Drawing.Point(3, 3);
            this.tableInner.Name = "tableInner";
            this.tableInner.RowCount = 1;
            this.tableInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableInner.Size = new System.Drawing.Size(1004, 593);
            this.tableInner.TabIndex = 1;
            // 
            // tablePlayer
            // 
            this.tablePlayer.ColumnCount = 1;
            this.tablePlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePlayer.Controls.Add(this.button3, 0, 0);
            this.tablePlayer.Controls.Add(this.musicControl1, 0, 1);
            this.tablePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePlayer.Location = new System.Drawing.Point(603, 3);
            this.tablePlayer.Name = "tablePlayer";
            this.tablePlayer.RowCount = 2;
            this.tablePlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tablePlayer.Size = new System.Drawing.Size(398, 587);
            this.tablePlayer.TabIndex = 2;
            // 
            // browserControl1
            // 
            this.browserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserControl1.Location = new System.Drawing.Point(3, 3);
            this.browserControl1.Name = "browserControl1";
            this.browserControl1.Size = new System.Drawing.Size(244, 587);
            this.browserControl1.TabIndex = 0;
            // 
            // musicControl1
            // 
            this.musicControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.musicControl1.Location = new System.Drawing.Point(3, 522);
            this.musicControl1.Name = "musicControl1";
            this.musicControl1.Size = new System.Drawing.Size(392, 62);
            this.musicControl1.TabIndex = 7;
            // 
            // listViewControl1
            // 
            this.listViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewControl1.Location = new System.Drawing.Point(253, 3);
            this.listViewControl1.Name = "listViewControl1";
            this.listViewControl1.Size = new System.Drawing.Size(344, 587);
            this.listViewControl1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 619);
            this.Controls.Add(this.tableOuter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableOuter.ResumeLayout(false);
            this.tableOuter.PerformLayout();
            this.tableInner.ResumeLayout(false);
            this.tablePlayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.MusicControl musicControl1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.BrowserControl browserControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableOuter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableInner;
        private System.Windows.Forms.TableLayoutPanel tablePlayer;
        private Controls.ListViewControl listViewControl1;
    }
}

