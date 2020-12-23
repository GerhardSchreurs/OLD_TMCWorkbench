namespace TMCWorkbench
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOriginal = new System.Windows.Forms.TabPage();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.tableInner = new System.Windows.Forms.TableLayoutPanel();
            this.tablePlayer = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlSamples = new System.Windows.Forms.Panel();
            this.pnlInstruments = new System.Windows.Forms.Panel();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.tableLayoutPanelBot = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelSave = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pnlMeta = new System.Windows.Forms.Panel();
            this.pnlMetaOrg = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBla = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.musicControl1 = new TMCWorkbench.Controls.MusicControl();
            this.txtSamplesNew = new TMCWorkbench.Controls.TextAreaControl();
            this.txtSamplesOrg = new TMCWorkbench.Controls.TextAreaControl();
            this.txtInstrumentsNew = new TMCWorkbench.Controls.TextAreaControl();
            this.txtInstrumentsOrg = new TMCWorkbench.Controls.TextAreaControl();
            this.txtMessageNew = new TMCWorkbench.Controls.TextAreaControl();
            this.txtMessageOrg = new TMCWorkbench.Controls.TextAreaControl();
            this.ctrSummary = new TMCWorkbench.Controls.HistoryTextBox();
            this.ctrMetaData = new TMCWorkbench.Controls.MetaDataControl();
            this.listViewControl1 = new TMCWorkbench.Controls.ListViewControl();
            this.browserControl1 = new TMCWorkbench.Controls.BrowserControl();
            this.statusStrip1.SuspendLayout();
            this.tableOuter.SuspendLayout();
            this.tableMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tableInner.SuspendLayout();
            this.tablePlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanelTop.SuspendLayout();
            this.pnlSamples.SuspendLayout();
            this.pnlInstruments.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.tableLayoutPanelBot.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelSave.SuspendLayout();
            this.pnlMeta.SuspendLayout();
            this.pnlMetaOrg.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSamplesNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSamplesOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentsNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentsOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageOrg)).BeginInit();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 837);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1637, 24);
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
            this.tableOuter.Size = new System.Drawing.Size(1637, 861);
            this.tableOuter.TabIndex = 1;
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
            this.tableMenu.Size = new System.Drawing.Size(1637, 24);
            this.tableMenu.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
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
            this.composersToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // stylesToolStripMenuItem
            // 
            this.stylesToolStripMenuItem.Name = "stylesToolStripMenuItem";
            this.stylesToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.stylesToolStripMenuItem.Text = "Styles";
            this.stylesToolStripMenuItem.Click += new System.EventHandler(this.stylesToolStripMenuItem_Click);
            // 
            // scenegroupsToolStripMenuItem
            // 
            this.scenegroupsToolStripMenuItem.Name = "scenegroupsToolStripMenuItem";
            this.scenegroupsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.scenegroupsToolStripMenuItem.Text = "Scenegroups";
            this.scenegroupsToolStripMenuItem.Click += new System.EventHandler(this.scenegroupsToolStripMenuItem_Click);
            // 
            // composersToolStripMenuItem
            // 
            this.composersToolStripMenuItem.Name = "composersToolStripMenuItem";
            this.composersToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.composersToolStripMenuItem.Text = "Composers";
            this.composersToolStripMenuItem.Click += new System.EventHandler(this.composersToolStripMenuItem_Click);
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
            this.tabControl.Size = new System.Drawing.Size(1029, 24);
            this.tabControl.TabIndex = 7;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tabOriginal
            // 
            this.tabOriginal.Location = new System.Drawing.Point(4, 22);
            this.tabOriginal.Name = "tabOriginal";
            this.tabOriginal.Padding = new System.Windows.Forms.Padding(3);
            this.tabOriginal.Size = new System.Drawing.Size(1021, 0);
            this.tabOriginal.TabIndex = 0;
            this.tabOriginal.Text = "Original";
            this.tabOriginal.UseVisualStyleBackColor = true;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(1021, 0);
            this.tabDatabase.TabIndex = 1;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // tableInner
            // 
            this.tableInner.BackColor = System.Drawing.SystemColors.Control;
            this.tableInner.ColumnCount = 3;
            this.tableInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableInner.Controls.Add(this.tablePlayer, 2, 0);
            this.tableInner.Controls.Add(this.listViewControl1, 1, 0);
            this.tableInner.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableInner.Location = new System.Drawing.Point(3, 24);
            this.tableInner.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tableInner.Name = "tableInner";
            this.tableInner.RowCount = 1;
            this.tableInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableInner.Size = new System.Drawing.Size(1631, 810);
            this.tableInner.TabIndex = 1;
            // 
            // tablePlayer
            // 
            this.tablePlayer.ColumnCount = 1;
            this.tablePlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePlayer.Controls.Add(this.musicControl1, 0, 1);
            this.tablePlayer.Controls.Add(this.splitContainer1, 0, 0);
            this.tablePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePlayer.Location = new System.Drawing.Point(603, 3);
            this.tablePlayer.Name = "tablePlayer";
            this.tablePlayer.RowCount = 2;
            this.tablePlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tablePlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePlayer.Size = new System.Drawing.Size(1025, 804);
            this.tablePlayer.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanelTop);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanelBot);
            this.splitContainer1.Size = new System.Drawing.Size(1019, 721);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 10;
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.ColumnCount = 3;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 651F));
            this.tableLayoutPanelTop.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanelTop.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.pnlSamples, 0, 1);
            this.tableLayoutPanelTop.Controls.Add(this.pnlInstruments, 1, 1);
            this.tableLayoutPanelTop.Controls.Add(this.pnlMessage, 2, 1);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 2;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1019, 357);
            this.tableLayoutPanelTop.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(371, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(645, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Message";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(187, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Instruments";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Samples";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSamples
            // 
            this.pnlSamples.Controls.Add(this.txtSamplesNew);
            this.pnlSamples.Controls.Add(this.txtSamplesOrg);
            this.pnlSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSamples.Location = new System.Drawing.Point(3, 23);
            this.pnlSamples.Name = "pnlSamples";
            this.pnlSamples.Size = new System.Drawing.Size(178, 331);
            this.pnlSamples.TabIndex = 10;
            // 
            // pnlInstruments
            // 
            this.pnlInstruments.Controls.Add(this.txtInstrumentsNew);
            this.pnlInstruments.Controls.Add(this.txtInstrumentsOrg);
            this.pnlInstruments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInstruments.Location = new System.Drawing.Point(187, 23);
            this.pnlInstruments.Name = "pnlInstruments";
            this.pnlInstruments.Size = new System.Drawing.Size(178, 331);
            this.pnlInstruments.TabIndex = 11;
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.txtMessageNew);
            this.pnlMessage.Controls.Add(this.txtMessageOrg);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(371, 23);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(645, 331);
            this.pnlMessage.TabIndex = 12;
            // 
            // tableLayoutPanelBot
            // 
            this.tableLayoutPanelBot.ColumnCount = 2;
            this.tableLayoutPanelBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 368F));
            this.tableLayoutPanelBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 651F));
            this.tableLayoutPanelBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBot.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanelBot.Controls.Add(this.pnlMeta, 0, 1);
            this.tableLayoutPanelBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBot.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBot.Name = "tableLayoutPanelBot";
            this.tableLayoutPanelBot.RowCount = 2;
            this.tableLayoutPanelBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBot.Size = new System.Drawing.Size(1019, 360);
            this.tableLayoutPanelBot.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panelSave, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ctrSummary, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(371, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 334);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelSave
            // 
            this.panelSave.Controls.Add(this.btnSave);
            this.panelSave.Controls.Add(this.comboBox1);
            this.panelSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSave.Location = new System.Drawing.Point(3, 307);
            this.panelSave.Name = "panelSave";
            this.panelSave.Size = new System.Drawing.Size(639, 24);
            this.panelSave.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(564, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hardcore",
            "Drum & bass",
            "Trance"});
            this.comboBox1.Location = new System.Drawing.Point(3, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // pnlMeta
            // 
            this.pnlMeta.Controls.Add(this.pnlMetaOrg);
            this.pnlMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeta.Location = new System.Drawing.Point(3, 23);
            this.pnlMeta.Name = "pnlMeta";
            this.pnlMeta.Size = new System.Drawing.Size(362, 334);
            this.pnlMeta.TabIndex = 1;
            // 
            // pnlMetaOrg
            // 
            this.pnlMetaOrg.Controls.Add(this.ctrMetaData);
            this.pnlMetaOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMetaOrg.Location = new System.Drawing.Point(0, 0);
            this.pnlMetaOrg.Name = "pnlMetaOrg";
            this.pnlMetaOrg.Size = new System.Drawing.Size(362, 313);
            this.pnlMetaOrg.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnBla, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.browserControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTest, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 804);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnBla
            // 
            this.btnBla.Location = new System.Drawing.Point(3, 787);
            this.btnBla.Name = "btnBla";
            this.btnBla.Size = new System.Drawing.Size(75, 14);
            this.btnBla.TabIndex = 3;
            this.btnBla.Text = "Bla";
            this.btnBla.UseVisualStyleBackColor = true;
            this.btnBla.Click += new System.EventHandler(this.btnBla_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(3, 747);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1, -7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // musicControl1
            // 
            this.musicControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.musicControl1.Location = new System.Drawing.Point(3, 738);
            this.musicControl1.Name = "musicControl1";
            this.musicControl1.Size = new System.Drawing.Size(1019, 63);
            this.musicControl1.TabIndex = 9;
            // 
            // txtSamplesNew
            // 
            this.txtSamplesNew.AllowMacroRecording = false;
            this.txtSamplesNew.AutoCompleteBracketsList = new char[] {
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
            this.txtSamplesNew.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.txtSamplesNew.BackBrush = null;
            this.txtSamplesNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSamplesNew.CharHeight = 12;
            this.txtSamplesNew.CharWidth = 6;
            this.txtSamplesNew.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSamplesNew.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSamplesNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSamplesNew.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtSamplesNew.IsReplaceMode = false;
            this.txtSamplesNew.Location = new System.Drawing.Point(0, 56);
            this.txtSamplesNew.Name = "txtSamplesNew";
            this.txtSamplesNew.Paddings = new System.Windows.Forms.Padding(3);
            this.txtSamplesNew.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtSamplesNew.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtSamplesNew.ServiceColors")));
            this.txtSamplesNew.ShowLineNumbers = false;
            this.txtSamplesNew.Size = new System.Drawing.Size(178, 56);
            this.txtSamplesNew.TabIndex = 9;
            this.txtSamplesNew.Text = "txtSamplesNew";
            this.txtSamplesNew.WordWrap = true;
            this.txtSamplesNew.Zoom = 100;
            // 
            // txtSamplesOrg
            // 
            this.txtSamplesOrg.AllowMacroRecording = false;
            this.txtSamplesOrg.AutoCompleteBracketsList = new char[] {
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
            this.txtSamplesOrg.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.txtSamplesOrg.BackBrush = null;
            this.txtSamplesOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSamplesOrg.CharHeight = 12;
            this.txtSamplesOrg.CharWidth = 6;
            this.txtSamplesOrg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSamplesOrg.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSamplesOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSamplesOrg.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtSamplesOrg.IsReplaceMode = false;
            this.txtSamplesOrg.Location = new System.Drawing.Point(0, 0);
            this.txtSamplesOrg.Name = "txtSamplesOrg";
            this.txtSamplesOrg.Paddings = new System.Windows.Forms.Padding(3);
            this.txtSamplesOrg.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtSamplesOrg.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtSamplesOrg.ServiceColors")));
            this.txtSamplesOrg.ShowLineNumbers = false;
            this.txtSamplesOrg.Size = new System.Drawing.Size(178, 56);
            this.txtSamplesOrg.TabIndex = 8;
            this.txtSamplesOrg.Text = "txtSamplesOrg";
            this.txtSamplesOrg.WordWrap = true;
            this.txtSamplesOrg.Zoom = 100;
            // 
            // txtInstrumentsNew
            // 
            this.txtInstrumentsNew.AllowMacroRecording = false;
            this.txtInstrumentsNew.AutoCompleteBracketsList = new char[] {
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
            this.txtInstrumentsNew.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.txtInstrumentsNew.BackBrush = null;
            this.txtInstrumentsNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstrumentsNew.CharHeight = 12;
            this.txtInstrumentsNew.CharWidth = 6;
            this.txtInstrumentsNew.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInstrumentsNew.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtInstrumentsNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInstrumentsNew.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtInstrumentsNew.IsReplaceMode = false;
            this.txtInstrumentsNew.Location = new System.Drawing.Point(0, 56);
            this.txtInstrumentsNew.Name = "txtInstrumentsNew";
            this.txtInstrumentsNew.Paddings = new System.Windows.Forms.Padding(3);
            this.txtInstrumentsNew.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtInstrumentsNew.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtInstrumentsNew.ServiceColors")));
            this.txtInstrumentsNew.ShowLineNumbers = false;
            this.txtInstrumentsNew.Size = new System.Drawing.Size(178, 56);
            this.txtInstrumentsNew.TabIndex = 10;
            this.txtInstrumentsNew.Text = "txtInstrumentsNew";
            this.txtInstrumentsNew.WordWrap = true;
            this.txtInstrumentsNew.Zoom = 100;
            // 
            // txtInstrumentsOrg
            // 
            this.txtInstrumentsOrg.AllowMacroRecording = false;
            this.txtInstrumentsOrg.AutoCompleteBracketsList = new char[] {
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
            this.txtInstrumentsOrg.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.txtInstrumentsOrg.BackBrush = null;
            this.txtInstrumentsOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstrumentsOrg.CharHeight = 12;
            this.txtInstrumentsOrg.CharWidth = 6;
            this.txtInstrumentsOrg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInstrumentsOrg.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtInstrumentsOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInstrumentsOrg.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtInstrumentsOrg.IsReplaceMode = false;
            this.txtInstrumentsOrg.Location = new System.Drawing.Point(0, 0);
            this.txtInstrumentsOrg.Name = "txtInstrumentsOrg";
            this.txtInstrumentsOrg.Paddings = new System.Windows.Forms.Padding(3);
            this.txtInstrumentsOrg.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtInstrumentsOrg.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtInstrumentsOrg.ServiceColors")));
            this.txtInstrumentsOrg.ShowLineNumbers = false;
            this.txtInstrumentsOrg.Size = new System.Drawing.Size(178, 56);
            this.txtInstrumentsOrg.TabIndex = 9;
            this.txtInstrumentsOrg.Text = "txtInstrumentsOrg";
            this.txtInstrumentsOrg.WordWrap = true;
            this.txtInstrumentsOrg.Zoom = 100;
            // 
            // txtMessageNew
            // 
            this.txtMessageNew.AllowMacroRecording = false;
            this.txtMessageNew.AutoCompleteBracketsList = new char[] {
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
            this.txtMessageNew.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.txtMessageNew.BackBrush = null;
            this.txtMessageNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessageNew.CharHeight = 12;
            this.txtMessageNew.CharWidth = 6;
            this.txtMessageNew.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessageNew.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtMessageNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMessageNew.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtMessageNew.IsReplaceMode = false;
            this.txtMessageNew.Location = new System.Drawing.Point(0, 56);
            this.txtMessageNew.Name = "txtMessageNew";
            this.txtMessageNew.Paddings = new System.Windows.Forms.Padding(3);
            this.txtMessageNew.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtMessageNew.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtMessageNew.ServiceColors")));
            this.txtMessageNew.ShowLineNumbers = false;
            this.txtMessageNew.Size = new System.Drawing.Size(645, 56);
            this.txtMessageNew.TabIndex = 11;
            this.txtMessageNew.Text = "txtMessageNew";
            this.txtMessageNew.WordWrap = true;
            this.txtMessageNew.Zoom = 100;
            // 
            // txtMessageOrg
            // 
            this.txtMessageOrg.AllowMacroRecording = false;
            this.txtMessageOrg.AutoCompleteBracketsList = new char[] {
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
            this.txtMessageOrg.AutoScrollMinSize = new System.Drawing.Size(0, 18);
            this.txtMessageOrg.BackBrush = null;
            this.txtMessageOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessageOrg.CharHeight = 12;
            this.txtMessageOrg.CharWidth = 6;
            this.txtMessageOrg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessageOrg.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtMessageOrg.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMessageOrg.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtMessageOrg.IsReplaceMode = false;
            this.txtMessageOrg.Location = new System.Drawing.Point(0, 0);
            this.txtMessageOrg.Name = "txtMessageOrg";
            this.txtMessageOrg.Paddings = new System.Windows.Forms.Padding(3);
            this.txtMessageOrg.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtMessageOrg.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtMessageOrg.ServiceColors")));
            this.txtMessageOrg.ShowLineNumbers = false;
            this.txtMessageOrg.Size = new System.Drawing.Size(645, 56);
            this.txtMessageOrg.TabIndex = 10;
            this.txtMessageOrg.Text = "txtMessageOrg";
            this.txtMessageOrg.WordWrap = true;
            this.txtMessageOrg.Zoom = 100;
            // 
            // ctrSummary
            // 
            this.ctrSummary.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrSummary.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrSummary.Location = new System.Drawing.Point(3, 3);
            this.ctrSummary.Multiline = true;
            this.ctrSummary.Name = "ctrSummary";
            this.ctrSummary.Size = new System.Drawing.Size(562, 298);
            this.ctrSummary.TabIndex = 12;
            // 
            // ctrMetaData
            // 
            this.ctrMetaData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrMetaData.Location = new System.Drawing.Point(0, 0);
            this.ctrMetaData.Name = "ctrMetaData";
            this.ctrMetaData.Size = new System.Drawing.Size(362, 313);
            this.ctrMetaData.TabIndex = 0;
            // 
            // listViewControl1
            // 
            this.listViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewControl1.Location = new System.Drawing.Point(253, 3);
            this.listViewControl1.Name = "listViewControl1";
            this.listViewControl1.Size = new System.Drawing.Size(344, 804);
            this.listViewControl1.TabIndex = 3;
            // 
            // browserControl1
            // 
            this.browserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserControl1.Location = new System.Drawing.Point(3, 3);
            this.browserControl1.Name = "browserControl1";
            this.browserControl1.Size = new System.Drawing.Size(238, 738);
            this.browserControl1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 861);
            this.Controls.Add(this.tableOuter);
            this.Name = "FormMain";
            this.Text = "TMC Workbench";
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
            this.tablePlayer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.pnlSamples.ResumeLayout(false);
            this.pnlInstruments.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.tableLayoutPanelBot.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelSave.ResumeLayout(false);
            this.pnlMeta.ResumeLayout(false);
            this.pnlMetaOrg.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSamplesNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSamplesOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentsNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstrumentsOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageOrg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableOuter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableInner;
        private System.Windows.Forms.TableLayoutPanel tablePlayer;
        private Controls.ListViewControl listViewControl1;
        private Controls.MusicControl musicControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlMeta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Controls.BrowserControl browserControl1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnBla;
        private System.Windows.Forms.TableLayoutPanel tableMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOriginal;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.Panel pnlSamples;
        private Controls.TextAreaControl txtSamplesNew;
        private Controls.TextAreaControl txtSamplesOrg;
        private System.Windows.Forms.Panel pnlInstruments;
        private Controls.TextAreaControl txtInstrumentsNew;
        private Controls.TextAreaControl txtInstrumentsOrg;
        private System.Windows.Forms.Panel pnlMessage;
        private Controls.TextAreaControl txtMessageNew;
        private Controls.TextAreaControl txtMessageOrg;
        private System.Windows.Forms.Panel pnlMetaOrg;
        private System.Windows.Forms.ToolStripMenuItem stylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenegroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composersToolStripMenuItem;
        private Controls.MetaDataControl ctrMetaData;
        private Controls.HistoryTextBox ctrSummary;
    }
}

