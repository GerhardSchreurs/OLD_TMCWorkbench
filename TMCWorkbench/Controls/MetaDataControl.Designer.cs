namespace TMCWorkbench.Controls
{
    partial class MetaDataControl
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
            this.ctrScenegroupText = new TMCWorkbench.Controls.Resettable.ResettableTextControl();
            this.ctrScenegroup = new TMCWorkbench.Controls.Resettable.ResettableSceneGroupDropDownControl();
            this.ctrComposerText = new TMCWorkbench.Controls.Resettable.ResettableTextControl();
            this.ctrComposer = new TMCWorkbench.Controls.Resettable.ResettableComposerDropDownControl();
            this.ctrStyleText = new TMCWorkbench.Controls.Resettable.ResettableTextControl();
            this.ctrStyle = new TMCWorkbench.Controls.Resettable.ResettableStyleDropDownControl();
            this.ctrBPM = new TMCWorkbench.Controls.Resettable.ResettableBpmControl();
            this.ctrSpeed = new TMCWorkbench.Controls.Resettable.ResettableDoubleIntControl();
            this.ctrLength = new TMCWorkbench.Controls.Resettable.ResettableDoubleIntControl();
            this.ctrDate = new TMCWorkbench.Controls.Resettable.ResettableDateControl();
            this.ctrTrackTitle = new TMCWorkbench.Controls.Resettable.ResettableTextControl();
            this.ctrFileInfo = new TMCWorkbench.Controls.Resettable.ResettableTextControl();
            this.ctrTracker = new TMCWorkbench.Controls.Resettable.ResettableTrackerDropDownControl();
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
            this.pnlMeta.Size = new System.Drawing.Size(654, 320);
            this.pnlMeta.TabIndex = 2;
            // 
            // pnlMetaOrg
            // 
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
            this.pnlMetaOrg.Size = new System.Drawing.Size(654, 320);
            this.pnlMetaOrg.TabIndex = 0;
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
            this.ctrScenegroup.TabIndex = 14;
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
            this.ctrComposer.TabIndex = 12;
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
            this.ctrStyle.TabIndex = 11;
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
            // MetaDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMeta);
            this.Name = "MetaDataControl";
            this.Size = new System.Drawing.Size(654, 320);
            this.pnlMeta.ResumeLayout(false);
            this.pnlMetaOrg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMeta;
        private System.Windows.Forms.Panel pnlMetaOrg;
        public Resettable.ResettableTextControl ctrStyleText;
        public Resettable.ResettableTextControl ctrScenegroupText;
        public Resettable.ResettableSceneGroupDropDownControl ctrScenegroup;
        public Resettable.ResettableTextControl ctrComposerText;
        public Resettable.ResettableComposerDropDownControl ctrComposer;
        public Resettable.ResettableStyleDropDownControl ctrStyle;
        public Resettable.ResettableBpmControl ctrBPM;
        public Resettable.ResettableDoubleIntControl ctrSpeed;
        public Resettable.ResettableDoubleIntControl ctrLength;
        public Resettable.ResettableDateControl ctrDate;
        public Resettable.ResettableTextControl ctrFileInfo;
        public Resettable.ResettableTextControl ctrTrackTitle;
        private Resettable.ResettableTrackerDropDownControl ctrTracker;
    }
}
