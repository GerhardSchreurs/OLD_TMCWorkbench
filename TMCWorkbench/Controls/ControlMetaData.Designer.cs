namespace TMCWorkbench.Controls
{
    partial class ControlMetaData
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
            this.pnlMeta = new System.Windows.Forms.Panel();
            this.pnlMetaOrg = new System.Windows.Forms.Panel();
            this.ctrTags = new TMCWorkbench.Controls.Resettable.ResettableCheckBoxDropDownTags();
            this.ctrScore = new TMCWorkbench.Controls.Resettable.ResettableDouble();
            this.ctrScenegroupText = new TMCWorkbench.Controls.Resettable.ResettableText();
            this.ctrScenegroup = new TMCWorkbench.Controls.Resettable.ResettableDropDownSceneGroup();
            this.ctrComposerText = new TMCWorkbench.Controls.Resettable.ResettableText();
            this.ctrComposer = new TMCWorkbench.Controls.Resettable.ResettableDropDownComposer();
            this.ctrStyleText = new TMCWorkbench.Controls.Resettable.ResettableText();
            this.ctrStyle = new TMCWorkbench.Controls.Resettable.ResettableDropDownStyle();
            this.ctrTracker = new TMCWorkbench.Controls.Resettable.ResettableDropDownTracker();
            this.ctrBPM = new TMCWorkbench.Controls.Resettable.ResettableBpm();
            this.ctrSpeed = new TMCWorkbench.Controls.Resettable.ResettableDoubleInt();
            this.ctrLength = new TMCWorkbench.Controls.Resettable.ResettableDoubleInt();
            this.ctrDate = new TMCWorkbench.Controls.Resettable.ResettableDate();
            this.ctrTrackTitle = new TMCWorkbench.Controls.Resettable.ResettableText();
            this.ctrFileInfo = new TMCWorkbench.Controls.Resettable.ResettableText();
            this.pnlMeta.SuspendLayout();
            this.pnlMetaOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMeta
            // 
            this.pnlMeta.Controls.Add(this.pnlMetaOrg);
            this.pnlMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeta.Location = new System.Drawing.Point(0, 0);
            this.pnlMeta.Name = "pnlMeta";
            this.pnlMeta.Size = new System.Drawing.Size(654, 400);
            this.pnlMeta.TabIndex = 2;
            // 
            // pnlMetaOrg
            // 
            this.pnlMetaOrg.Controls.Add(this.ctrTags);
            this.pnlMetaOrg.Controls.Add(this.ctrScore);
            this.pnlMetaOrg.Controls.Add(this.ctrScenegroupText);
            this.pnlMetaOrg.Controls.Add(this.ctrScenegroup);
            this.pnlMetaOrg.Controls.Add(this.ctrComposerText);
            this.pnlMetaOrg.Controls.Add(this.ctrComposer);
            this.pnlMetaOrg.Controls.Add(this.ctrStyleText);
            this.pnlMetaOrg.Controls.Add(this.ctrStyle);
            this.pnlMetaOrg.Controls.Add(this.ctrTracker);
            this.pnlMetaOrg.Controls.Add(this.ctrBPM);
            this.pnlMetaOrg.Controls.Add(this.ctrSpeed);
            this.pnlMetaOrg.Controls.Add(this.ctrLength);
            this.pnlMetaOrg.Controls.Add(this.ctrDate);
            this.pnlMetaOrg.Controls.Add(this.ctrTrackTitle);
            this.pnlMetaOrg.Controls.Add(this.ctrFileInfo);
            this.pnlMetaOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMetaOrg.Location = new System.Drawing.Point(0, 0);
            this.pnlMetaOrg.Name = "pnlMetaOrg";
            this.pnlMetaOrg.Size = new System.Drawing.Size(654, 400);
            this.pnlMetaOrg.TabIndex = 0;
            // 
            // ctrTags
            // 
            this.ctrTags.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrTags.LabelTitle = "Tags";
            this.ctrTags.Location = new System.Drawing.Point(0, 336);
            this.ctrTags.Margin = new System.Windows.Forms.Padding(0);
            this.ctrTags.Name = "ctrTags";
            this.ctrTags.Size = new System.Drawing.Size(654, 24);
            this.ctrTags.TabIndex = 24;
            // 
            // ctrScore
            // 
            this.ctrScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrScore.LabelTitle = "Score";
            this.ctrScore.Location = new System.Drawing.Point(0, 312);
            this.ctrScore.Margin = new System.Windows.Forms.Padding(0);
            this.ctrScore.Name = "ctrScore";
            this.ctrScore.Size = new System.Drawing.Size(654, 24);
            this.ctrScore.TabIndex = 22;
            this.ctrScore.Value = null;
            // 
            // ctrScenegroupText
            // 
            this.ctrScenegroupText.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrScenegroupText.LabelTitle = "Scenegroup (S)";
            this.ctrScenegroupText.Location = new System.Drawing.Point(0, 288);
            this.ctrScenegroupText.Margin = new System.Windows.Forms.Padding(0);
            this.ctrScenegroupText.Name = "ctrScenegroupText";
            this.ctrScenegroupText.Original = null;
            this.ctrScenegroupText.Size = new System.Drawing.Size(654, 24);
            this.ctrScenegroupText.TabIndex = 15;
            // 
            // ctrScenegroup
            // 
            this.ctrScenegroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrScenegroup.LabelTitle = "Scenegroup";
            this.ctrScenegroup.Location = new System.Drawing.Point(0, 264);
            this.ctrScenegroup.Margin = new System.Windows.Forms.Padding(0);
            this.ctrScenegroup.Name = "ctrScenegroup";
            this.ctrScenegroup.Size = new System.Drawing.Size(654, 24);
            this.ctrScenegroup.TabIndex = 21;
            // 
            // ctrComposerText
            // 
            this.ctrComposerText.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrComposerText.LabelTitle = "Composer (S)";
            this.ctrComposerText.Location = new System.Drawing.Point(0, 240);
            this.ctrComposerText.Margin = new System.Windows.Forms.Padding(0);
            this.ctrComposerText.Name = "ctrComposerText";
            this.ctrComposerText.Original = null;
            this.ctrComposerText.Size = new System.Drawing.Size(654, 24);
            this.ctrComposerText.TabIndex = 13;
            // 
            // ctrComposer
            // 
            this.ctrComposer.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrComposer.LabelTitle = "Composer";
            this.ctrComposer.Location = new System.Drawing.Point(0, 216);
            this.ctrComposer.Margin = new System.Windows.Forms.Padding(0);
            this.ctrComposer.Name = "ctrComposer";
            this.ctrComposer.Size = new System.Drawing.Size(654, 24);
            this.ctrComposer.TabIndex = 19;
            // 
            // ctrStyleText
            // 
            this.ctrStyleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrStyleText.LabelTitle = "Style (S)";
            this.ctrStyleText.Location = new System.Drawing.Point(0, 192);
            this.ctrStyleText.Margin = new System.Windows.Forms.Padding(0);
            this.ctrStyleText.Name = "ctrStyleText";
            this.ctrStyleText.Original = null;
            this.ctrStyleText.Size = new System.Drawing.Size(654, 24);
            this.ctrStyleText.TabIndex = 16;
            // 
            // ctrStyle
            // 
            this.ctrStyle.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrStyle.LabelTitle = "Style";
            this.ctrStyle.Location = new System.Drawing.Point(0, 168);
            this.ctrStyle.Margin = new System.Windows.Forms.Padding(0);
            this.ctrStyle.Name = "ctrStyle";
            this.ctrStyle.Size = new System.Drawing.Size(654, 24);
            this.ctrStyle.TabIndex = 20;
            // 
            // ctrTracker
            // 
            this.ctrTracker.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrTracker.LabelTitle = "Tracker";
            this.ctrTracker.Location = new System.Drawing.Point(0, 144);
            this.ctrTracker.Margin = new System.Windows.Forms.Padding(0);
            this.ctrTracker.Name = "ctrTracker";
            this.ctrTracker.Size = new System.Drawing.Size(654, 24);
            this.ctrTracker.TabIndex = 18;
            // 
            // ctrBPM
            // 
            this.ctrBPM.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrBPM.LabelTitle = "BPM:";
            this.ctrBPM.Location = new System.Drawing.Point(0, 120);
            this.ctrBPM.Margin = new System.Windows.Forms.Padding(0);
            this.ctrBPM.Name = "ctrBPM";
            this.ctrBPM.Size = new System.Drawing.Size(654, 24);
            this.ctrBPM.TabIndex = 10;
            // 
            // ctrSpeed
            // 
            this.ctrSpeed.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrSpeed.LabelTitle = "Speed/Tempo:";
            this.ctrSpeed.Location = new System.Drawing.Point(0, 96);
            this.ctrSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.ctrSpeed.Name = "ctrSpeed";
            this.ctrSpeed.Size = new System.Drawing.Size(654, 24);
            this.ctrSpeed.TabIndex = 9;
            // 
            // ctrLength
            // 
            this.ctrLength.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrLength.LabelTitle = "Minutes/Sec:";
            this.ctrLength.Location = new System.Drawing.Point(0, 72);
            this.ctrLength.Margin = new System.Windows.Forms.Padding(0);
            this.ctrLength.Name = "ctrLength";
            this.ctrLength.Size = new System.Drawing.Size(654, 24);
            this.ctrLength.TabIndex = 8;
            // 
            // ctrDate
            // 
            this.ctrDate.Date = new System.DateTime(((long)(0)));
            this.ctrDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrDate.LabelTitle = "Date:";
            this.ctrDate.Location = new System.Drawing.Point(0, 48);
            this.ctrDate.Margin = new System.Windows.Forms.Padding(0);
            this.ctrDate.Name = "ctrDate";
            this.ctrDate.Original = null;
            this.ctrDate.Size = new System.Drawing.Size(654, 24);
            this.ctrDate.TabIndex = 7;
            // 
            // ctrTrackTitle
            // 
            this.ctrTrackTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrTrackTitle.LabelTitle = "Track title:";
            this.ctrTrackTitle.Location = new System.Drawing.Point(0, 24);
            this.ctrTrackTitle.Margin = new System.Windows.Forms.Padding(0);
            this.ctrTrackTitle.Name = "ctrTrackTitle";
            this.ctrTrackTitle.Original = null;
            this.ctrTrackTitle.Size = new System.Drawing.Size(654, 24);
            this.ctrTrackTitle.TabIndex = 17;
            // 
            // ctrFileInfo
            // 
            this.ctrFileInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrFileInfo.LabelTitle = "Filename:";
            this.ctrFileInfo.Location = new System.Drawing.Point(0, 0);
            this.ctrFileInfo.Margin = new System.Windows.Forms.Padding(0);
            this.ctrFileInfo.Name = "ctrFileInfo";
            this.ctrFileInfo.Original = null;
            this.ctrFileInfo.Size = new System.Drawing.Size(654, 24);
            this.ctrFileInfo.TabIndex = 6;
            // 
            // ControlMetaData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMeta);
            this.Name = "ControlMetaData";
            this.Size = new System.Drawing.Size(654, 400);
            this.pnlMeta.ResumeLayout(false);
            this.pnlMetaOrg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMeta;
        private System.Windows.Forms.Panel pnlMetaOrg;
        public Resettable.ResettableText ctrStyleText;
        public Resettable.ResettableText ctrScenegroupText;
        public Resettable.ResettableText ctrComposerText;
        public Resettable.ResettableBpm ctrBPM;
        public Resettable.ResettableDoubleInt ctrSpeed;
        public Resettable.ResettableDoubleInt ctrLength;
        public Resettable.ResettableDate ctrDate;
        public Resettable.ResettableText ctrFileInfo;
        public Resettable.ResettableText ctrTrackTitle;
        private Resettable.ResettableDropDownTracker ctrTracker;
        private Resettable.ResettableDropDownComposer ctrComposer;
        private Resettable.ResettableDropDownStyle ctrStyle;
        private Resettable.ResettableDropDownSceneGroup ctrScenegroup;
        private Resettable.ResettableDouble ctrScore;
        private Resettable.ResettableCheckBoxDropDownTags ctrTags;
    }
}
