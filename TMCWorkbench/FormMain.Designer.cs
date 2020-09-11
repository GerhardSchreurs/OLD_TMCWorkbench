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
            this.tableInner = new System.Windows.Forms.TableLayoutPanel();
            this.tablePlayer = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanelBot = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelSave = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pnlMeta = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBla = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicControl1 = new TMCWorkbench.Controls.MusicControl();
            this.txtSamples = new TMCWorkbench.Controls.TextAreaControl();
            this.txtInstruments = new TMCWorkbench.Controls.TextAreaControl();
            this.txtMessage = new TMCWorkbench.Controls.TextAreaControl();
            this.txtOutput = new TMCWorkbench.Controls.TextAreaControl();
            this.ctrBPM = new TMCWorkbench.Controls.Resettable.ResettableBpmControl();
            this.ctrSpeed = new TMCWorkbench.Controls.Resettable.ResettableDoubleIntControl();
            this.ctrLength = new TMCWorkbench.Controls.Resettable.ResettableDoubleIntControl();
            this.ctrDate = new TMCWorkbench.Controls.Resettable.ResettableDateControl();
            this.ctrFileInfo = new TMCWorkbench.Controls.Resettable.ResettableTextControl();
            this.listViewControl1 = new TMCWorkbench.Controls.ListViewControl();
            this.browserControl1 = new TMCWorkbench.Controls.BrowserControl();
            this.statusStrip1.SuspendLayout();
            this.tableOuter.SuspendLayout();
            this.tableInner.SuspendLayout();
            this.tablePlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanelTop.SuspendLayout();
            this.tableLayoutPanelBot.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelSave.SuspendLayout();
            this.pnlMeta.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstruments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutput)).BeginInit();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 728);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1637, 24);
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
            this.tableOuter.Controls.Add(this.menuStrip1, 0, 0);
            this.tableOuter.Controls.Add(this.tableInner, 0, 1);
            this.tableOuter.Controls.Add(this.statusStrip1, 1, 2);
            this.tableOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOuter.Location = new System.Drawing.Point(0, 0);
            this.tableOuter.Name = "tableOuter";
            this.tableOuter.RowCount = 3;
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableOuter.Size = new System.Drawing.Size(1637, 752);
            this.tableOuter.TabIndex = 1;
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
            this.tableInner.Location = new System.Drawing.Point(3, 27);
            this.tableInner.Name = "tableInner";
            this.tableInner.RowCount = 1;
            this.tableInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableInner.Size = new System.Drawing.Size(1631, 698);
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
            this.tablePlayer.Size = new System.Drawing.Size(1025, 692);
            this.tablePlayer.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
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
            this.splitContainer1.Size = new System.Drawing.Size(1019, 606);
            this.splitContainer1.SplitterDistance = 302;
            this.splitContainer1.TabIndex = 10;
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.ColumnCount = 3;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 651F));
            this.tableLayoutPanelTop.Controls.Add(this.txtSamples, 0, 1);
            this.tableLayoutPanelTop.Controls.Add(this.txtInstruments, 1, 1);
            this.tableLayoutPanelTop.Controls.Add(this.txtMessage, 2, 1);
            this.tableLayoutPanelTop.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanelTop.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 2;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1019, 302);
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
            this.tableLayoutPanelBot.Size = new System.Drawing.Size(1019, 300);
            this.tableLayoutPanelBot.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtOutput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelSave, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(371, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 274);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelSave
            // 
            this.panelSave.Controls.Add(this.btnSave);
            this.panelSave.Controls.Add(this.comboBox1);
            this.panelSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSave.Location = new System.Drawing.Point(3, 247);
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
            this.pnlMeta.Controls.Add(this.ctrBPM);
            this.pnlMeta.Controls.Add(this.ctrSpeed);
            this.pnlMeta.Controls.Add(this.ctrLength);
            this.pnlMeta.Controls.Add(this.ctrDate);
            this.pnlMeta.Controls.Add(this.ctrFileInfo);
            this.pnlMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeta.Location = new System.Drawing.Point(3, 23);
            this.pnlMeta.Name = "pnlMeta";
            this.pnlMeta.Size = new System.Drawing.Size(362, 274);
            this.pnlMeta.TabIndex = 1;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 692);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnBla
            // 
            this.btnBla.Location = new System.Drawing.Point(3, 675);
            this.btnBla.Name = "btnBla";
            this.btnBla.Size = new System.Drawing.Size(75, 14);
            this.btnBla.TabIndex = 3;
            this.btnBla.Text = "Bla";
            this.btnBla.UseVisualStyleBackColor = true;
            this.btnBla.Click += new System.EventHandler(this.btnBla_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(3, 635);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1637, 24);
            this.menuStrip1.TabIndex = 5;
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // musicControl1
            // 
            this.musicControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.musicControl1.Location = new System.Drawing.Point(3, 626);
            this.musicControl1.Name = "musicControl1";
            this.musicControl1.Size = new System.Drawing.Size(1019, 63);
            this.musicControl1.TabIndex = 9;
            // 
            // txtSamples
            // 
            this.txtSamples.AllowMacroRecording = false;
            this.txtSamples.AutoCompleteBracketsList = new char[] {
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
            this.txtSamples.AutoScrollMinSize = new System.Drawing.Size(68, 18);
            this.txtSamples.BackBrush = null;
            this.txtSamples.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSamples.CharHeight = 12;
            this.txtSamples.CharWidth = 6;
            this.txtSamples.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSamples.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSamples.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtSamples.IsReplaceMode = false;
            this.txtSamples.Location = new System.Drawing.Point(3, 23);
            this.txtSamples.Name = "txtSamples";
            this.txtSamples.Paddings = new System.Windows.Forms.Padding(3);
            this.txtSamples.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtSamples.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtSamples.ServiceColors")));
            this.txtSamples.ShowLineNumbers = false;
            this.txtSamples.Size = new System.Drawing.Size(178, 276);
            this.txtSamples.TabIndex = 7;
            this.txtSamples.Text = "txtSamples";
            this.txtSamples.Zoom = 100;
            // 
            // txtInstruments
            // 
            this.txtInstruments.AllowMacroRecording = false;
            this.txtInstruments.AutoCompleteBracketsList = new char[] {
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
            this.txtInstruments.AutoScrollMinSize = new System.Drawing.Size(92, 18);
            this.txtInstruments.BackBrush = null;
            this.txtInstruments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstruments.CharHeight = 12;
            this.txtInstruments.CharWidth = 6;
            this.txtInstruments.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInstruments.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtInstruments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInstruments.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtInstruments.IsReplaceMode = false;
            this.txtInstruments.Location = new System.Drawing.Point(187, 23);
            this.txtInstruments.Name = "txtInstruments";
            this.txtInstruments.Paddings = new System.Windows.Forms.Padding(3);
            this.txtInstruments.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtInstruments.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtInstruments.ServiceColors")));
            this.txtInstruments.ShowLineNumbers = false;
            this.txtInstruments.Size = new System.Drawing.Size(178, 276);
            this.txtInstruments.TabIndex = 8;
            this.txtInstruments.Text = "txtInstruments";
            this.txtInstruments.Zoom = 100;
            // 
            // txtMessage
            // 
            this.txtMessage.AllowMacroRecording = false;
            this.txtMessage.AutoCompleteBracketsList = new char[] {
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
            this.txtMessage.AutoScrollMinSize = new System.Drawing.Size(68, 18);
            this.txtMessage.BackBrush = null;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.CharHeight = 12;
            this.txtMessage.CharWidth = 6;
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessage.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtMessage.IsReplaceMode = false;
            this.txtMessage.Location = new System.Drawing.Point(371, 23);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Paddings = new System.Windows.Forms.Padding(3);
            this.txtMessage.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtMessage.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtMessage.ServiceColors")));
            this.txtMessage.ShowLineNumbers = false;
            this.txtMessage.Size = new System.Drawing.Size(645, 276);
            this.txtMessage.TabIndex = 9;
            this.txtMessage.Text = "txtMessage";
            this.txtMessage.Zoom = 100;
            // 
            // txtOutput
            // 
            this.txtOutput.AllowMacroRecording = false;
            this.txtOutput.AutoCompleteBracketsList = new char[] {
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
            this.txtOutput.AutoScrollMinSize = new System.Drawing.Size(62, 18);
            this.txtOutput.BackBrush = null;
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.CharHeight = 12;
            this.txtOutput.CharWidth = 6;
            this.txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOutput.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtOutput.IsReplaceMode = false;
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Paddings = new System.Windows.Forms.Padding(3);
            this.txtOutput.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtOutput.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtOutput.ServiceColors")));
            this.txtOutput.ShowLineNumbers = false;
            this.txtOutput.Size = new System.Drawing.Size(639, 238);
            this.txtOutput.TabIndex = 10;
            this.txtOutput.Text = "txtOutput";
            this.txtOutput.Zoom = 100;
            // 
            // ctrBPM
            // 
            this.ctrBPM.BPM = 0;
            this.ctrBPM.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrBPM.LabelTitle = "BPM:";
            this.ctrBPM.Location = new System.Drawing.Point(0, 96);
            this.ctrBPM.Margin = new System.Windows.Forms.Padding(0);
            this.ctrBPM.Name = "ctrBPM";
            this.ctrBPM.Size = new System.Drawing.Size(362, 24);
            this.ctrBPM.TabIndex = 4;
            // 
            // ctrSpeed
            // 
            this.ctrSpeed.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrSpeed.LabelTitle = "Speed/Tempo:";
            this.ctrSpeed.Location = new System.Drawing.Point(0, 72);
            this.ctrSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.ctrSpeed.Name = "ctrSpeed";
            this.ctrSpeed.Size = new System.Drawing.Size(362, 24);
            this.ctrSpeed.TabIndex = 3;
            this.ctrSpeed.ValueA = 0;
            this.ctrSpeed.ValueB = 0;
            // 
            // ctrLength
            // 
            this.ctrLength.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrLength.LabelTitle = "Minutes/Sec:";
            this.ctrLength.Location = new System.Drawing.Point(0, 48);
            this.ctrLength.Margin = new System.Windows.Forms.Padding(0);
            this.ctrLength.Name = "ctrLength";
            this.ctrLength.Size = new System.Drawing.Size(362, 24);
            this.ctrLength.TabIndex = 2;
            this.ctrLength.ValueA = 0;
            this.ctrLength.ValueB = 0;
            // 
            // ctrDate
            // 
            this.ctrDate.Date = new System.DateTime(((long)(0)));
            this.ctrDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrDate.LabelTitle = "Date:";
            this.ctrDate.Location = new System.Drawing.Point(0, 24);
            this.ctrDate.Margin = new System.Windows.Forms.Padding(0);
            this.ctrDate.Name = "ctrDate";
            this.ctrDate.Size = new System.Drawing.Size(362, 24);
            this.ctrDate.TabIndex = 1;
            // 
            // ctrFileInfo
            // 
            this.ctrFileInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrFileInfo.Filename = null;
            this.ctrFileInfo.LabelTitle = "Filename:";
            this.ctrFileInfo.Location = new System.Drawing.Point(0, 0);
            this.ctrFileInfo.Margin = new System.Windows.Forms.Padding(0);
            this.ctrFileInfo.Name = "ctrFileInfo";
            this.ctrFileInfo.Size = new System.Drawing.Size(362, 24);
            this.ctrFileInfo.TabIndex = 0;
            // 
            // listViewControl1
            // 
            this.listViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewControl1.Location = new System.Drawing.Point(253, 3);
            this.listViewControl1.Name = "listViewControl1";
            this.listViewControl1.Size = new System.Drawing.Size(344, 692);
            this.listViewControl1.TabIndex = 3;
            // 
            // browserControl1
            // 
            this.browserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserControl1.Location = new System.Drawing.Point(3, 3);
            this.browserControl1.Name = "browserControl1";
            this.browserControl1.Size = new System.Drawing.Size(238, 626);
            this.browserControl1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 752);
            this.Controls.Add(this.tableOuter);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "TMC Workbench";
            this.Load += new System.EventHandler(this.Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableOuter.ResumeLayout(false);
            this.tableOuter.PerformLayout();
            this.tableInner.ResumeLayout(false);
            this.tablePlayer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.tableLayoutPanelBot.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelSave.ResumeLayout(false);
            this.pnlMeta.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstruments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutput)).EndInit();
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
        private Controls.TextAreaControl txtSamples;
        private Controls.TextAreaControl txtInstruments;
        private Controls.TextAreaControl txtMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.TextAreaControl txtOutput;
        private System.Windows.Forms.Panel panelSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlMeta;
        private Controls.Resettable.ResettableTextControl ctrFileInfo;
        private Controls.Resettable.ResettableDateControl ctrDate;
        private Controls.Resettable.ResettableDoubleIntControl ctrLength;
        private Controls.Resettable.ResettableDoubleIntControl ctrSpeed;
        private Controls.Resettable.ResettableBpmControl ctrBPM;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Controls.BrowserControl browserControl1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnBla;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}

