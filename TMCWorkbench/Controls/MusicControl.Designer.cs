namespace TMCWorkbench.Controls
{
    partial class MusicControl
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.trackVolume = new System.Windows.Forms.TrackBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.trackPosition = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPlay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrev, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPause, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 33);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.Controls.Add(this.trackVolume, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblInfo, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(346, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(148, 27);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // trackVolume
            // 
            this.trackVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackVolume.Location = new System.Drawing.Point(77, 3);
            this.trackVolume.Name = "trackVolume";
            this.trackVolume.Size = new System.Drawing.Size(68, 45);
            this.trackVolume.TabIndex = 11;
            this.trackVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(19, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 51);
            this.lblInfo.TabIndex = 18;
            this.lblInfo.Text = "lblInfo";
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(3, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(28, 27);
            this.btnPlay.TabIndex = 14;
            this.btnPlay.Text = "►";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNext.Location = new System.Drawing.Point(159, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(28, 27);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "»";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.Font = new System.Drawing.Font("Arial", 10F);
            this.btnStop.Location = new System.Drawing.Point(71, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(28, 27);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "■";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrev.Location = new System.Drawing.Point(125, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(28, 27);
            this.btnPrev.TabIndex = 12;
            this.btnPrev.Text = "«";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPause.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPause.Location = new System.Drawing.Point(37, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(28, 27);
            this.btnPause.TabIndex = 15;
            this.btnPause.Text = "❚❚";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // trackPosition
            // 
            this.trackPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackPosition.Location = new System.Drawing.Point(0, 0);
            this.trackPosition.Maximum = 1000;
            this.trackPosition.Name = "trackPosition";
            this.trackPosition.Size = new System.Drawing.Size(497, 45);
            this.trackPosition.TabIndex = 19;
            this.trackPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrackPosition_MouseDown);
            this.trackPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackPosition_MouseUp);
            // 
            // NewMusicControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.trackPosition);
            this.Name = "NewMusicControl";
            this.Size = new System.Drawing.Size(497, 63);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TrackBar trackPosition;
    }
}
