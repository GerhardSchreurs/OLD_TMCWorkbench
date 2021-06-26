
namespace TMCWorkbench
{
    partial class FormAlpha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlpha));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableOuter = new System.Windows.Forms.TableLayoutPanel();
            this.tableMenu = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenegroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileShow = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileHide = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileOnlyDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.miDatabaseShow = new System.Windows.Forms.ToolStripMenuItem();
            this.miDatabaseHide = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOriginal = new System.Windows.Forms.TabPage();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.tableInner = new System.Windows.Forms.TableLayoutPanel();
            this.tableRightControls = new System.Windows.Forms.TableLayoutPanel();
            this.ctrPlayer = new TMCWorkbench.Controls.ControlMusic();
            this.tableEditControls = new System.Windows.Forms.TableLayoutPanel();
            this.ctrOutput = new TMCWorkbench.Controls.ControlOutput();
            this.tableRight = new System.Windows.Forms.TableLayoutPanel();
            this.ctrMessage = new TMCWorkbench.Controls.ControlTextAreaState();
            this.tableMetaData = new System.Windows.Forms.TableLayoutPanel();
            this.ctrSamples = new TMCWorkbench.Controls.ControlTextAreaState();
            this.ctrInstruments = new TMCWorkbench.Controls.ControlTextAreaState();
            this.ctrMetaData = new TMCWorkbench.Controls.ControlMetaData();
            this.pnlEndgame = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableOffline = new System.Windows.Forms.TableLayoutPanel();
            this.ctrBrowser = new TMCWorkbench.Controls.ControlBrowser();
            this.ctrListView = new TMCWorkbench.Controls.ControlListView();
            this.ctrTracks = new TMCWorkbench.Controls.ControlTracks();
            this.statusStrip1.SuspendLayout();
            this.tableOuter.SuspendLayout();
            this.tableMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tableInner.SuspendLayout();
            this.tableRightControls.SuspendLayout();
            this.tableEditControls.SuspendLayout();
            this.tableRight.SuspendLayout();
            this.tableMetaData.SuspendLayout();
            this.pnlEndgame.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableOffline.SuspendLayout();
            this.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 937);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1904, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 19);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // tableOuter
            // 
            this.tableOuter.ColumnCount = 1;
            this.tableOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableOuter.Controls.Add(this.tableMenu, 0, 0);
            this.tableOuter.Controls.Add(this.tableInner, 0, 1);
            this.tableOuter.Controls.Add(this.statusStrip1, 1, 2);
            this.tableOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOuter.Location = new System.Drawing.Point(0, 0);
            this.tableOuter.Name = "tableOuter";
            this.tableOuter.RowCount = 3;
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableOuter.Size = new System.Drawing.Size(1904, 961);
            this.tableOuter.TabIndex = 2;
            // 
            // tableMenu
            // 
            this.tableMenu.ColumnCount = 2;
            this.tableMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 608F));
            this.tableMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMenu.Controls.Add(this.menuStrip1, 0, 0);
            this.tableMenu.Controls.Add(this.tabControl, 1, 0);
            this.tableMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMenu.Location = new System.Drawing.Point(0, 0);
            this.tableMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tableMenu.Name = "tableMenu";
            this.tableMenu.RowCount = 1;
            this.tableMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMenu.Size = new System.Drawing.Size(1904, 24);
            this.tableMenu.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(608, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stylesToolStripMenuItem,
            this.scenegroupsToolStripMenuItem,
            this.composersToolStripMenuItem,
            this.tagsToolStripMenuItem,
            this.playlistsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // stylesToolStripMenuItem
            // 
            this.stylesToolStripMenuItem.Name = "stylesToolStripMenuItem";
            this.stylesToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.stylesToolStripMenuItem.Text = "Styles";
            this.stylesToolStripMenuItem.Click += new System.EventHandler(this.Handle_stylesToolStripMenuItem_Click);
            // 
            // scenegroupsToolStripMenuItem
            // 
            this.scenegroupsToolStripMenuItem.Name = "scenegroupsToolStripMenuItem";
            this.scenegroupsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.scenegroupsToolStripMenuItem.Text = "Scenegroups";
            this.scenegroupsToolStripMenuItem.Click += new System.EventHandler(this.Handle_scenegroupsToolStripMenuItem_Click);
            // 
            // composersToolStripMenuItem
            // 
            this.composersToolStripMenuItem.Name = "composersToolStripMenuItem";
            this.composersToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.composersToolStripMenuItem.Text = "Composers";
            this.composersToolStripMenuItem.Click += new System.EventHandler(this.Handle_composersToolStripMenuItem_Click);
            // 
            // tagsToolStripMenuItem
            // 
            this.tagsToolStripMenuItem.Name = "tagsToolStripMenuItem";
            this.tagsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.tagsToolStripMenuItem.Text = "Tags";
            this.tagsToolStripMenuItem.Click += new System.EventHandler(this.Handle_tagsToolStripMenuItem_Click);
            // 
            // playlistsToolStripMenuItem
            // 
            this.playlistsToolStripMenuItem.Name = "playlistsToolStripMenuItem";
            this.playlistsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.playlistsToolStripMenuItem.Text = "Playlists";
            this.playlistsToolStripMenuItem.Click += new System.EventHandler(this.Handle_playlistsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miDatabase});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileShow,
            this.miFileHide,
            this.miFileOnlyDetails});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(180, 22);
            this.miFile.Text = "File Area";
            // 
            // miFileShow
            // 
            this.miFileShow.Name = "miFileShow";
            this.miFileShow.Size = new System.Drawing.Size(189, 22);
            this.miFileShow.Text = "Show";
            // 
            // miFileHide
            // 
            this.miFileHide.Name = "miFileHide";
            this.miFileHide.Size = new System.Drawing.Size(189, 22);
            this.miFileHide.Text = "Hide";
            // 
            // miFileOnlyDetails
            // 
            this.miFileOnlyDetails.Name = "miFileOnlyDetails";
            this.miFileOnlyDetails.Size = new System.Drawing.Size(189, 22);
            this.miFileOnlyDetails.Text = "Only Show File details";
            // 
            // miDatabase
            // 
            this.miDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDatabaseShow,
            this.miDatabaseHide});
            this.miDatabase.Name = "miDatabase";
            this.miDatabase.Size = new System.Drawing.Size(180, 22);
            this.miDatabase.Text = "Database Area";
            // 
            // miDatabaseShow
            // 
            this.miDatabaseShow.Name = "miDatabaseShow";
            this.miDatabaseShow.Size = new System.Drawing.Size(180, 22);
            this.miDatabaseShow.Text = "Show";
            // 
            // miDatabaseHide
            // 
            this.miDatabaseHide.Name = "miDatabaseHide";
            this.miDatabaseHide.Size = new System.Drawing.Size(180, 22);
            this.miDatabaseHide.Text = "Hide";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabOriginal);
            this.tabControl.Controls.Add(this.tabDatabase);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(608, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1296, 24);
            this.tabControl.TabIndex = 7;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.Handle_TabControl_Selected);
            // 
            // tabOriginal
            // 
            this.tabOriginal.Location = new System.Drawing.Point(4, 22);
            this.tabOriginal.Name = "tabOriginal";
            this.tabOriginal.Padding = new System.Windows.Forms.Padding(3);
            this.tabOriginal.Size = new System.Drawing.Size(1288, 0);
            this.tabOriginal.TabIndex = 0;
            this.tabOriginal.Text = "Original";
            this.tabOriginal.UseVisualStyleBackColor = true;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(1288, 0);
            this.tabDatabase.TabIndex = 1;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // tableInner
            // 
            this.tableInner.BackColor = System.Drawing.SystemColors.Control;
            this.tableInner.ColumnCount = 2;
            this.tableInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableInner.Controls.Add(this.tableRightControls, 1, 0);
            this.tableInner.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableInner.Location = new System.Drawing.Point(3, 24);
            this.tableInner.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tableInner.Name = "tableInner";
            this.tableInner.RowCount = 1;
            this.tableInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableInner.Size = new System.Drawing.Size(1898, 910);
            this.tableInner.TabIndex = 1;
            // 
            // tableRightControls
            // 
            this.tableRightControls.ColumnCount = 1;
            this.tableRightControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRightControls.Controls.Add(this.ctrPlayer, 0, 2);
            this.tableRightControls.Controls.Add(this.tableEditControls, 0, 0);
            this.tableRightControls.Controls.Add(this.pnlEndgame, 0, 1);
            this.tableRightControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRightControls.Location = new System.Drawing.Point(603, 3);
            this.tableRightControls.Name = "tableRightControls";
            this.tableRightControls.RowCount = 3;
            this.tableRightControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRightControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableRightControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableRightControls.Size = new System.Drawing.Size(1292, 904);
            this.tableRightControls.TabIndex = 2;
            // 
            // ctrPlayer
            // 
            this.ctrPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrPlayer.Location = new System.Drawing.Point(3, 838);
            this.ctrPlayer.Name = "ctrPlayer";
            this.ctrPlayer.Size = new System.Drawing.Size(1286, 63);
            this.ctrPlayer.TabIndex = 9;
            // 
            // tableEditControls
            // 
            this.tableEditControls.ColumnCount = 2;
            this.tableEditControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 568F));
            this.tableEditControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableEditControls.Controls.Add(this.ctrOutput, 0, 0);
            this.tableEditControls.Controls.Add(this.tableRight, 1, 0);
            this.tableEditControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableEditControls.Location = new System.Drawing.Point(3, 3);
            this.tableEditControls.Name = "tableEditControls";
            this.tableEditControls.RowCount = 1;
            this.tableEditControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableEditControls.Size = new System.Drawing.Size(1286, 788);
            this.tableEditControls.TabIndex = 10;
            // 
            // ctrOutput
            // 
            this.ctrOutput.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrOutput.Location = new System.Drawing.Point(0, 0);
            this.ctrOutput.Margin = new System.Windows.Forms.Padding(0);
            this.ctrOutput.Name = "ctrOutput";
            this.ctrOutput.Size = new System.Drawing.Size(562, 788);
            this.ctrOutput.TabIndex = 2;
            this.ctrOutput.TextFooterNew = "txtNew";
            this.ctrOutput.TextFooterOrg = "txtOld";
            this.ctrOutput.TextHeaderNew = "txtNew";
            this.ctrOutput.TextHeaderOrg = "txtOld";
            this.ctrOutput.TextSummaryNew = "txtNew";
            this.ctrOutput.TextSummaryOrg = "txtOld";
            // 
            // tableRight
            // 
            this.tableRight.ColumnCount = 1;
            this.tableRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRight.Controls.Add(this.ctrMessage, 0, 0);
            this.tableRight.Controls.Add(this.tableMetaData, 0, 1);
            this.tableRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRight.Location = new System.Drawing.Point(568, 0);
            this.tableRight.Margin = new System.Windows.Forms.Padding(0);
            this.tableRight.Name = "tableRight";
            this.tableRight.RowCount = 2;
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableRight.Size = new System.Drawing.Size(718, 788);
            this.tableRight.TabIndex = 1;
            // 
            // ctrMessage
            // 
            this.ctrMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrMessage.Location = new System.Drawing.Point(3, 3);
            this.ctrMessage.Name = "ctrMessage";
            this.ctrMessage.Size = new System.Drawing.Size(712, 294);
            this.ctrMessage.TabIndex = 4;
            this.ctrMessage.TextNew = "txtNew";
            this.ctrMessage.TextOrg = "txtOld";
            // 
            // tableMetaData
            // 
            this.tableMetaData.ColumnCount = 3;
            this.tableMetaData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableMetaData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableMetaData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMetaData.Controls.Add(this.ctrSamples, 0, 1);
            this.tableMetaData.Controls.Add(this.ctrInstruments, 1, 1);
            this.tableMetaData.Controls.Add(this.ctrMetaData, 2, 1);
            this.tableMetaData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMetaData.Location = new System.Drawing.Point(0, 300);
            this.tableMetaData.Margin = new System.Windows.Forms.Padding(0);
            this.tableMetaData.Name = "tableMetaData";
            this.tableMetaData.RowCount = 2;
            this.tableMetaData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableMetaData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMetaData.Size = new System.Drawing.Size(718, 488);
            this.tableMetaData.TabIndex = 5;
            // 
            // ctrSamples
            // 
            this.ctrSamples.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrSamples.Location = new System.Drawing.Point(3, 23);
            this.ctrSamples.Name = "ctrSamples";
            this.ctrSamples.Size = new System.Drawing.Size(176, 462);
            this.ctrSamples.TabIndex = 0;
            this.ctrSamples.TextNew = "txtNew";
            this.ctrSamples.TextOrg = "txtOld";
            // 
            // ctrInstruments
            // 
            this.ctrInstruments.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrInstruments.Location = new System.Drawing.Point(185, 23);
            this.ctrInstruments.Name = "ctrInstruments";
            this.ctrInstruments.Size = new System.Drawing.Size(176, 462);
            this.ctrInstruments.TabIndex = 1;
            this.ctrInstruments.TextNew = "txtNew";
            this.ctrInstruments.TextOrg = "txtOld";
            // 
            // ctrMetaData
            // 
            this.ctrMetaData.Bpm = 0;
            this.ctrMetaData.Composer = "";
            this.ctrMetaData.ComposerID = null;
            this.ctrMetaData.ComposerText = "";
            this.ctrMetaData.Date = new System.DateTime(((long)(0)));
            this.ctrMetaData.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrMetaData.FileName = "";
            this.ctrMetaData.LengthInMs = ((long)(0));
            this.ctrMetaData.Location = new System.Drawing.Point(367, 23);
            this.ctrMetaData.Name = "ctrMetaData";
            this.ctrMetaData.SceneGroup = "";
            this.ctrMetaData.ScenegroupID = null;
            this.ctrMetaData.ScenegroupText = "";
            this.ctrMetaData.Score = null;
            this.ctrMetaData.Size = new System.Drawing.Size(348, 440);
            this.ctrMetaData.Style = "";
            this.ctrMetaData.StyleID = null;
            this.ctrMetaData.StyleText = "";
            this.ctrMetaData.TabIndex = 2;
            this.ctrMetaData.Tracker = "Unknown";
            this.ctrMetaData.TrackerID = 0;
            this.ctrMetaData.TrackTitle = "";
            // 
            // pnlEndgame
            // 
            this.pnlEndgame.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlEndgame.Controls.Add(this.btnSave);
            this.pnlEndgame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEndgame.Location = new System.Drawing.Point(6, 794);
            this.pnlEndgame.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pnlEndgame.Name = "pnlEndgame";
            this.pnlEndgame.Size = new System.Drawing.Size(1280, 30);
            this.pnlEndgame.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(1205, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Handle_btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableOffline, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctrTracks, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 910);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableOffline
            // 
            this.tableOffline.ColumnCount = 2;
            this.tableOffline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableOffline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableOffline.Controls.Add(this.ctrBrowser, 0, 0);
            this.tableOffline.Controls.Add(this.ctrListView, 1, 0);
            this.tableOffline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOffline.Location = new System.Drawing.Point(0, 0);
            this.tableOffline.Margin = new System.Windows.Forms.Padding(0);
            this.tableOffline.Name = "tableOffline";
            this.tableOffline.RowCount = 1;
            this.tableOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 455F));
            this.tableOffline.Size = new System.Drawing.Size(600, 455);
            this.tableOffline.TabIndex = 4;
            // 
            // ctrBrowser
            // 
            this.ctrBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrBrowser.Location = new System.Drawing.Point(3, 3);
            this.ctrBrowser.Name = "ctrBrowser";
            this.ctrBrowser.Size = new System.Drawing.Size(244, 449);
            this.ctrBrowser.TabIndex = 0;
            // 
            // ctrListView
            // 
            this.ctrListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrListView.Location = new System.Drawing.Point(253, 3);
            this.ctrListView.Name = "ctrListView";
            this.ctrListView.Size = new System.Drawing.Size(344, 449);
            this.ctrListView.TabIndex = 1;
            // 
            // ctrTracks
            // 
            this.ctrTracks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrTracks.Location = new System.Drawing.Point(0, 455);
            this.ctrTracks.Margin = new System.Windows.Forms.Padding(0);
            this.ctrTracks.Name = "ctrTracks";
            this.ctrTracks.Size = new System.Drawing.Size(600, 455);
            this.ctrTracks.TabIndex = 5;
            // 
            // FormAlpha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 961);
            this.Controls.Add(this.tableOuter);
            this.Name = "FormAlpha";
            this.Text = "FormAlpha";
            this.Load += new System.EventHandler(this.Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableOuter.ResumeLayout(false);
            this.tableOuter.PerformLayout();
            this.tableMenu.ResumeLayout(false);
            this.tableMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tableInner.ResumeLayout(false);
            this.tableRightControls.ResumeLayout(false);
            this.tableEditControls.ResumeLayout(false);
            this.tableRight.ResumeLayout(false);
            this.tableMetaData.ResumeLayout(false);
            this.pnlEndgame.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableOffline.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableOuter;
        private System.Windows.Forms.TableLayoutPanel tableMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenegroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composersToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOriginal;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.TableLayoutPanel tableInner;
        private System.Windows.Forms.TableLayoutPanel tableRightControls;
        private Controls.ControlMusic ctrPlayer;
        private System.Windows.Forms.TableLayoutPanel tableEditControls;
        private System.Windows.Forms.TableLayoutPanel tableRight;
        private Controls.ControlTextAreaState ctrMessage;
        private System.Windows.Forms.TableLayoutPanel tableMetaData;
        private Controls.ControlTextAreaState ctrSamples;
        private Controls.ControlTextAreaState ctrInstruments;
        private Controls.ControlMetaData ctrMetaData;
        private Controls.ControlOutput ctrOutput;
        private System.Windows.Forms.Panel pnlEndgame;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem tagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistsToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableOffline;
        private Controls.ControlBrowser ctrBrowser;
        private Controls.ControlListView ctrListView;
        private Controls.ControlTracks ctrTracks;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miFileShow;
        private System.Windows.Forms.ToolStripMenuItem miFileOnlyDetails;
        private System.Windows.Forms.ToolStripMenuItem miDatabase;
        private System.Windows.Forms.ToolStripMenuItem miFileHide;
        private System.Windows.Forms.ToolStripMenuItem miDatabaseShow;
        private System.Windows.Forms.ToolStripMenuItem miDatabaseHide;
    }
}