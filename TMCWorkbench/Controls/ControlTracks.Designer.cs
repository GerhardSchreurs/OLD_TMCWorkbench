
namespace TMCWorkbench.Controls
{
    partial class ControlTracks
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
            this.tblOuter = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFill2 = new System.Windows.Forms.Label();
            this.lblFill1 = new System.Windows.Forms.Label();
            this.lblDateSaved = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.tblMoreCen = new System.Windows.Forms.TableLayoutPanel();
            this.lblStuff = new System.Windows.Forms.Label();
            this.lblPlaylists = new System.Windows.Forms.Label();
            this.lblTrackers = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBPM = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStyle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateSaved = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tblTopControls = new System.Windows.Forms.TableLayoutPanel();
            this.tblTopRightControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ddlFormat = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tblBottomControlsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tblMoreTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblTags = new System.Windows.Forms.Label();
            this.lblComposer = new System.Windows.Forms.Label();
            this.lblScenegroup = new System.Windows.Forms.Label();
            this.lblStyles = new System.Windows.Forms.Label();
            this.ctrDateSaved2 = new TMCWorkbench.Controls.ControlDateChooser();
            this.ctrDateSaved1 = new TMCWorkbench.Controls.ControlDateChooser();
            this.ctrDateCreated2 = new TMCWorkbench.Controls.ControlDateChooser();
            this.ctrDateCreated1 = new TMCWorkbench.Controls.ControlDateChooser();
            this.ddlTrackers = new TMCWorkbench.Controls.ControlCheckBoxDropDown();
            this.ddlPlaylist = new TMCWorkbench.Controls.DropDownList();
            this.ctrScore = new TMCWorkbench.Controls.ControlDoubleTextBoxRange();
            this.ctrBPM = new TMCWorkbench.Controls.ControlDoubleTextBoxRange();
            this.ctrMetaData = new TMCWorkbench.Controls.ControlHintTextBox();
            this.ctrFileName = new TMCWorkbench.Controls.ControlHintTextBox();
            this.ctrTrackTitle = new TMCWorkbench.Controls.ControlHintTextBox();
            this.ddlTags = new TMCWorkbench.Controls.ControlCheckBoxDropDown();
            this.ddlStyles = new TMCWorkbench.Controls.ControlCheckBoxDropDown();
            this.ddlComposer = new TMCWorkbench.Controls.DropDownList();
            this.ddlScenegroup = new TMCWorkbench.Controls.DropDownList();
            this.tblOuter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblMoreCen.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tblTopControls.SuspendLayout();
            this.tblTopRightControls.SuspendLayout();
            this.tblBottomControlsContainer.SuspendLayout();
            this.tblMoreTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblOuter
            // 
            this.tblOuter.ColumnCount = 1;
            this.tblOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblOuter.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tblOuter.Controls.Add(this.tblMoreCen, 0, 2);
            this.tblOuter.Controls.Add(this.listView, 0, 4);
            this.tblOuter.Controls.Add(this.tblTopControls, 0, 0);
            this.tblOuter.Controls.Add(this.tblBottomControlsContainer, 0, 1);
            this.tblOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOuter.Location = new System.Drawing.Point(0, 0);
            this.tblOuter.Name = "tblOuter";
            this.tblOuter.RowCount = 6;
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblOuter.Size = new System.Drawing.Size(600, 749);
            this.tblOuter.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.ctrDateSaved2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ctrDateSaved1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ctrDateCreated2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFill2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFill1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDateSaved, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDateCreated, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctrDateCreated1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 140);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 55);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // lblFill2
            // 
            this.lblFill2.AutoSize = true;
            this.lblFill2.Location = new System.Drawing.Point(453, 0);
            this.lblFill2.Name = "lblFill2";
            this.lblFill2.Size = new System.Drawing.Size(80, 13);
            this.lblFill2.TabIndex = 7;
            this.lblFill2.Text = "Date saved (till)";
            // 
            // lblFill1
            // 
            this.lblFill1.AutoSize = true;
            this.lblFill1.Location = new System.Drawing.Point(153, 0);
            this.lblFill1.Name = "lblFill1";
            this.lblFill1.Size = new System.Drawing.Size(87, 13);
            this.lblFill1.TabIndex = 5;
            this.lblFill1.Text = "Date created (till)";
            // 
            // lblDateSaved
            // 
            this.lblDateSaved.AutoSize = true;
            this.lblDateSaved.Location = new System.Drawing.Point(303, 0);
            this.lblDateSaved.Name = "lblDateSaved";
            this.lblDateSaved.Size = new System.Drawing.Size(91, 13);
            this.lblDateSaved.TabIndex = 3;
            this.lblDateSaved.Text = "Date saved (from)";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(3, 0);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(98, 13);
            this.lblDateCreated.TabIndex = 2;
            this.lblDateCreated.Text = "Date created (from)";
            // 
            // tblMoreCen
            // 
            this.tblMoreCen.BackColor = System.Drawing.SystemColors.Control;
            this.tblMoreCen.ColumnCount = 4;
            this.tblMoreCen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMoreCen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMoreCen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMoreCen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMoreCen.Controls.Add(this.lblStuff, 4, 0);
            this.tblMoreCen.Controls.Add(this.lblPlaylists, 0, 0);
            this.tblMoreCen.Controls.Add(this.ddlTrackers, 0, 1);
            this.tblMoreCen.Controls.Add(this.lblTrackers, 0, 0);
            this.tblMoreCen.Controls.Add(this.ddlPlaylist, 1, 1);
            this.tblMoreCen.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tblMoreCen.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tblMoreCen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMoreCen.Location = new System.Drawing.Point(0, 85);
            this.tblMoreCen.Margin = new System.Windows.Forms.Padding(0);
            this.tblMoreCen.Name = "tblMoreCen";
            this.tblMoreCen.RowCount = 2;
            this.tblMoreCen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblMoreCen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblMoreCen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMoreCen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMoreCen.Size = new System.Drawing.Size(600, 55);
            this.tblMoreCen.TabIndex = 8;
            // 
            // lblStuff
            // 
            this.lblStuff.AutoSize = true;
            this.lblStuff.Location = new System.Drawing.Point(453, 0);
            this.lblStuff.Name = "lblStuff";
            this.lblStuff.Size = new System.Drawing.Size(53, 13);
            this.lblStuff.TabIndex = 7;
            this.lblStuff.Text = "Fav & Stuff";
            // 
            // lblPlaylists
            // 
            this.lblPlaylists.AutoSize = true;
            this.lblPlaylists.Location = new System.Drawing.Point(3, 0);
            this.lblPlaylists.Name = "lblPlaylists";
            this.lblPlaylists.Size = new System.Drawing.Size(39, 13);
            this.lblPlaylists.TabIndex = 5;
            this.lblPlaylists.Text = "Playlist";
            // 
            // lblTrackers
            // 
            this.lblTrackers.AutoSize = true;
            this.lblTrackers.Location = new System.Drawing.Point(153, 0);
            this.lblTrackers.Name = "lblTrackers";
            this.lblTrackers.Size = new System.Drawing.Size(55, 13);
            this.lblTrackers.TabIndex = 2;
            this.lblTrackers.Text = "Tracker(s)";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ctrScore, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ctrBPM, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(303, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(144, 34);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblBPM, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblScore, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(300, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(150, 15);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // lblBPM
            // 
            this.lblBPM.AutoSize = true;
            this.lblBPM.Location = new System.Drawing.Point(78, 0);
            this.lblBPM.Name = "lblBPM";
            this.lblBPM.Size = new System.Drawing.Size(30, 13);
            this.lblBPM.TabIndex = 5;
            this.lblBPM.Text = "BPM";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(3, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(35, 13);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "Score";
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colType,
            this.colFileName,
            this.colName,
            this.colStyle,
            this.colDateSaved});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 198);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(594, 528);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 45;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 45;
            // 
            // colFileName
            // 
            this.colFileName.Text = "Filename";
            this.colFileName.Width = 120;
            // 
            // colName
            // 
            this.colName.Text = "Title";
            this.colName.Width = 150;
            // 
            // colStyle
            // 
            this.colStyle.Text = "Style";
            this.colStyle.Width = 90;
            // 
            // colDateSaved
            // 
            this.colDateSaved.Text = "DateSaved";
            this.colDateSaved.Width = 90;
            // 
            // tblTopControls
            // 
            this.tblTopControls.BackColor = System.Drawing.SystemColors.Control;
            this.tblTopControls.ColumnCount = 4;
            this.tblTopControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTopControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTopControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTopControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblTopControls.Controls.Add(this.ctrMetaData, 2, 0);
            this.tblTopControls.Controls.Add(this.ctrFileName, 1, 0);
            this.tblTopControls.Controls.Add(this.ctrTrackTitle, 0, 0);
            this.tblTopControls.Controls.Add(this.tblTopRightControls, 3, 0);
            this.tblTopControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTopControls.Location = new System.Drawing.Point(0, 0);
            this.tblTopControls.Margin = new System.Windows.Forms.Padding(0);
            this.tblTopControls.Name = "tblTopControls";
            this.tblTopControls.RowCount = 1;
            this.tblTopControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblTopControls.Size = new System.Drawing.Size(600, 30);
            this.tblTopControls.TabIndex = 6;
            // 
            // tblTopRightControls
            // 
            this.tblTopRightControls.ColumnCount = 4;
            this.tblTopRightControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblTopRightControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tblTopRightControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tblTopRightControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tblTopRightControls.Controls.Add(this.btnSwitch, 0, 0);
            this.tblTopRightControls.Controls.Add(this.btnRefresh, 0, 0);
            this.tblTopRightControls.Controls.Add(this.ddlFormat, 0, 0);
            this.tblTopRightControls.Controls.Add(this.btnSearch, 3, 0);
            this.tblTopRightControls.Location = new System.Drawing.Point(450, 0);
            this.tblTopRightControls.Margin = new System.Windows.Forms.Padding(0);
            this.tblTopRightControls.Name = "tblTopRightControls";
            this.tblTopRightControls.RowCount = 1;
            this.tblTopRightControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTopRightControls.Size = new System.Drawing.Size(150, 25);
            this.tblTopRightControls.TabIndex = 3;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSwitch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSwitch.Location = new System.Drawing.Point(70, 2);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(24, 22);
            this.btnSwitch.TabIndex = 4;
            this.btnSwitch.Text = "▼";
            this.btnSwitch.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Location = new System.Drawing.Point(45, 2);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 22);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "⟳";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // ddlFormat
            // 
            this.ddlFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.ddlFormat.FormattingEnabled = true;
            this.ddlFormat.Location = new System.Drawing.Point(3, 3);
            this.ddlFormat.Name = "ddlFormat";
            this.ddlFormat.Size = new System.Drawing.Size(39, 20);
            this.ddlFormat.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.btnSearch.Location = new System.Drawing.Point(95, 2);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 22);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Handle_btnSearch_Click);
            // 
            // tblBottomControlsContainer
            // 
            this.tblBottomControlsContainer.BackColor = System.Drawing.SystemColors.Control;
            this.tblBottomControlsContainer.ColumnCount = 1;
            this.tblBottomControlsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBottomControlsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblBottomControlsContainer.Controls.Add(this.tblMoreTop, 0, 1);
            this.tblBottomControlsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBottomControlsContainer.Location = new System.Drawing.Point(0, 30);
            this.tblBottomControlsContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tblBottomControlsContainer.Name = "tblBottomControlsContainer";
            this.tblBottomControlsContainer.RowCount = 3;
            this.tblBottomControlsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblBottomControlsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblBottomControlsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblBottomControlsContainer.Size = new System.Drawing.Size(600, 55);
            this.tblBottomControlsContainer.TabIndex = 5;
            // 
            // tblMoreTop
            // 
            this.tblMoreTop.BackColor = System.Drawing.SystemColors.Control;
            this.tblMoreTop.ColumnCount = 4;
            this.tblMoreTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMoreTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMoreTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMoreTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMoreTop.Controls.Add(this.ddlTags, 4, 1);
            this.tblMoreTop.Controls.Add(this.lblTags, 4, 0);
            this.tblMoreTop.Controls.Add(this.lblComposer, 0, 0);
            this.tblMoreTop.Controls.Add(this.lblScenegroup, 1, 0);
            this.tblMoreTop.Controls.Add(this.ddlStyles, 0, 1);
            this.tblMoreTop.Controls.Add(this.lblStyles, 0, 0);
            this.tblMoreTop.Controls.Add(this.ddlComposer, 1, 1);
            this.tblMoreTop.Controls.Add(this.ddlScenegroup, 2, 1);
            this.tblMoreTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMoreTop.Location = new System.Drawing.Point(0, 10);
            this.tblMoreTop.Margin = new System.Windows.Forms.Padding(0);
            this.tblMoreTop.Name = "tblMoreTop";
            this.tblMoreTop.RowCount = 2;
            this.tblMoreTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblMoreTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblMoreTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMoreTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMoreTop.Size = new System.Drawing.Size(600, 40);
            this.tblMoreTop.TabIndex = 7;
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(453, 0);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(31, 13);
            this.lblTags.TabIndex = 7;
            this.lblTags.Text = "Tags";
            // 
            // lblComposer
            // 
            this.lblComposer.AutoSize = true;
            this.lblComposer.Location = new System.Drawing.Point(153, 0);
            this.lblComposer.Name = "lblComposer";
            this.lblComposer.Size = new System.Drawing.Size(54, 13);
            this.lblComposer.TabIndex = 5;
            this.lblComposer.Text = "Composer";
            // 
            // lblScenegroup
            // 
            this.lblScenegroup.AutoSize = true;
            this.lblScenegroup.Location = new System.Drawing.Point(303, 0);
            this.lblScenegroup.Name = "lblScenegroup";
            this.lblScenegroup.Size = new System.Drawing.Size(65, 13);
            this.lblScenegroup.TabIndex = 3;
            this.lblScenegroup.Text = "Scenegroup";
            // 
            // lblStyles
            // 
            this.lblStyles.AutoSize = true;
            this.lblStyles.Location = new System.Drawing.Point(3, 0);
            this.lblStyles.Name = "lblStyles";
            this.lblStyles.Size = new System.Drawing.Size(41, 13);
            this.lblStyles.TabIndex = 2;
            this.lblStyles.Text = "Style(s)";
            // 
            // ctrDateSaved2
            // 
            this.ctrDateSaved2.Location = new System.Drawing.Point(453, 18);
            this.ctrDateSaved2.Name = "ctrDateSaved2";
            this.ctrDateSaved2.Size = new System.Drawing.Size(144, 34);
            this.ctrDateSaved2.TabIndex = 17;
            // 
            // ctrDateSaved1
            // 
            this.ctrDateSaved1.Location = new System.Drawing.Point(303, 18);
            this.ctrDateSaved1.Name = "ctrDateSaved1";
            this.ctrDateSaved1.Size = new System.Drawing.Size(144, 34);
            this.ctrDateSaved1.TabIndex = 16;
            // 
            // ctrDateCreated2
            // 
            this.ctrDateCreated2.Location = new System.Drawing.Point(153, 18);
            this.ctrDateCreated2.Name = "ctrDateCreated2";
            this.ctrDateCreated2.Size = new System.Drawing.Size(144, 34);
            this.ctrDateCreated2.TabIndex = 15;
            // 
            // ctrDateCreated1
            // 
            this.ctrDateCreated1.Location = new System.Drawing.Point(3, 18);
            this.ctrDateCreated1.Name = "ctrDateCreated1";
            this.ctrDateCreated1.Size = new System.Drawing.Size(144, 34);
            this.ctrDateCreated1.TabIndex = 14;
            // 
            // ddlTrackers
            // 
            this.ddlTrackers.CheckOnClick = true;
            this.ddlTrackers.DisplayMember = "Name";
            this.ddlTrackers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlTrackers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ddlTrackers.DropDownHeight = 1;
            this.ddlTrackers.FormattingEnabled = true;
            this.ddlTrackers.IntegralHeight = false;
            this.ddlTrackers.ItemHeight = 15;
            this.ddlTrackers.Location = new System.Drawing.Point(3, 18);
            this.ddlTrackers.MaxDropDownItems = 25;
            this.ddlTrackers.Name = "ddlTrackers";
            this.ddlTrackers.Size = new System.Drawing.Size(144, 21);
            this.ddlTrackers.TabIndex = 1;
            this.ddlTrackers.ValueSeparator = ", ";
            // 
            // ddlPlaylist
            // 
            this.ddlPlaylist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlPlaylist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlPlaylist.DisplayMember = "Name";
            this.ddlPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlPlaylist.FormattingEnabled = true;
            this.ddlPlaylist.Location = new System.Drawing.Point(153, 18);
            this.ddlPlaylist.Name = "ddlPlaylist";
            this.ddlPlaylist.Size = new System.Drawing.Size(144, 21);
            this.ddlPlaylist.TabIndex = 9;
            // 
            // ctrScore
            // 
            this.ctrScore.AllowsNegatives = false;
            this.ctrScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrScore.Location = new System.Drawing.Point(0, 0);
            this.ctrScore.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ctrScore.MaxValue = 10;
            this.ctrScore.MinValue = 0;
            this.ctrScore.Modifier = null;
            this.ctrScore.Name = "ctrScore";
            this.ctrScore.Result = null;
            this.ctrScore.Size = new System.Drawing.Size(69, 34);
            this.ctrScore.TabIndex = 0;
            // 
            // ctrBPM
            // 
            this.ctrBPM.AllowsNegatives = false;
            this.ctrBPM.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrBPM.Location = new System.Drawing.Point(75, 0);
            this.ctrBPM.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ctrBPM.MaxValue = 999;
            this.ctrBPM.MinValue = 0;
            this.ctrBPM.Modifier = null;
            this.ctrBPM.Name = "ctrBPM";
            this.ctrBPM.Result = null;
            this.ctrBPM.Size = new System.Drawing.Size(69, 34);
            this.ctrBPM.TabIndex = 1;
            // 
            // ctrMetaData
            // 
            this.ctrMetaData.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrMetaData.Hint = "Meta data";
            this.ctrMetaData.Location = new System.Drawing.Point(303, 3);
            this.ctrMetaData.Name = "ctrMetaData";
            this.ctrMetaData.Size = new System.Drawing.Size(144, 20);
            this.ctrMetaData.TabIndex = 2;
            // 
            // ctrFileName
            // 
            this.ctrFileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrFileName.Hint = "File name";
            this.ctrFileName.Location = new System.Drawing.Point(153, 3);
            this.ctrFileName.Name = "ctrFileName";
            this.ctrFileName.Size = new System.Drawing.Size(144, 20);
            this.ctrFileName.TabIndex = 1;
            // 
            // ctrTrackTitle
            // 
            this.ctrTrackTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrTrackTitle.Hint = "Track title";
            this.ctrTrackTitle.Location = new System.Drawing.Point(3, 3);
            this.ctrTrackTitle.Name = "ctrTrackTitle";
            this.ctrTrackTitle.Size = new System.Drawing.Size(144, 20);
            this.ctrTrackTitle.TabIndex = 0;
            // 
            // ddlTags
            // 
            this.ddlTags.CheckOnClick = true;
            this.ddlTags.DisplayMember = "Name";
            this.ddlTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlTags.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ddlTags.DropDownHeight = 1;
            this.ddlTags.FormattingEnabled = true;
            this.ddlTags.IntegralHeight = false;
            this.ddlTags.ItemHeight = 15;
            this.ddlTags.Location = new System.Drawing.Point(453, 18);
            this.ddlTags.MaxDropDownItems = 25;
            this.ddlTags.Name = "ddlTags";
            this.ddlTags.Size = new System.Drawing.Size(144, 21);
            this.ddlTags.TabIndex = 8;
            this.ddlTags.ValueSeparator = ", ";
            // 
            // ddlStyles
            // 
            this.ddlStyles.CheckOnClick = true;
            this.ddlStyles.DisplayMember = "Name";
            this.ddlStyles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlStyles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ddlStyles.DropDownHeight = 1;
            this.ddlStyles.FormattingEnabled = true;
            this.ddlStyles.IntegralHeight = false;
            this.ddlStyles.ItemHeight = 15;
            this.ddlStyles.Location = new System.Drawing.Point(3, 18);
            this.ddlStyles.MaxDropDownItems = 25;
            this.ddlStyles.Name = "ddlStyles";
            this.ddlStyles.Size = new System.Drawing.Size(144, 21);
            this.ddlStyles.TabIndex = 1;
            this.ddlStyles.ValueSeparator = ", ";
            // 
            // ddlComposer
            // 
            this.ddlComposer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlComposer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlComposer.DisplayMember = "Name";
            this.ddlComposer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlComposer.FormattingEnabled = true;
            this.ddlComposer.Location = new System.Drawing.Point(153, 18);
            this.ddlComposer.Name = "ddlComposer";
            this.ddlComposer.Size = new System.Drawing.Size(144, 21);
            this.ddlComposer.TabIndex = 9;
            // 
            // ddlScenegroup
            // 
            this.ddlScenegroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlScenegroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlScenegroup.DisplayMember = "Name";
            this.ddlScenegroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlScenegroup.FormattingEnabled = true;
            this.ddlScenegroup.Location = new System.Drawing.Point(303, 18);
            this.ddlScenegroup.Name = "ddlScenegroup";
            this.ddlScenegroup.Size = new System.Drawing.Size(144, 21);
            this.ddlScenegroup.TabIndex = 10;
            // 
            // ControlTracks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblOuter);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlTracks";
            this.Size = new System.Drawing.Size(600, 749);
            this.tblOuter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tblMoreCen.ResumeLayout(false);
            this.tblMoreCen.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tblTopControls.ResumeLayout(false);
            this.tblTopControls.PerformLayout();
            this.tblTopRightControls.ResumeLayout(false);
            this.tblBottomControlsContainer.ResumeLayout(false);
            this.tblMoreTop.ResumeLayout(false);
            this.tblMoreTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblOuter;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStyle;
        private System.Windows.Forms.ColumnHeader colDateSaved;
        private System.Windows.Forms.TableLayoutPanel tblBottomControlsContainer;
        private System.Windows.Forms.TableLayoutPanel tblTopControls;
        private ControlHintTextBox ctrMetaData;
        private ControlHintTextBox ctrFileName;
        private ControlHintTextBox ctrTrackTitle;
        private System.Windows.Forms.TableLayoutPanel tblTopRightControls;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox ddlFormat;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tblMoreTop;
        private ControlCheckBoxDropDown ddlStyles;
        private System.Windows.Forms.Label lblStyles;
        private System.Windows.Forms.Label lblScenegroup;
        private System.Windows.Forms.Label lblComposer;
        private ControlCheckBoxDropDown ddlTags;
        private System.Windows.Forms.Label lblTags;
        private DropDownList ddlComposer;
        private DropDownList ddlScenegroup;
        private System.Windows.Forms.TableLayoutPanel tblMoreCen;
        private System.Windows.Forms.Label lblStuff;
        private System.Windows.Forms.Label lblPlaylists;
        private ControlCheckBoxDropDown ddlTrackers;
        private System.Windows.Forms.Label lblTrackers;
        private DropDownList ddlPlaylist;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFill2;
        private System.Windows.Forms.Label lblFill1;
        private System.Windows.Forms.Label lblDateSaved;
        private System.Windows.Forms.Label lblDateCreated;
        private ControlDateChooser ctrDateCreated1;
        private ControlDateChooser ctrDateSaved2;
        private ControlDateChooser ctrDateSaved1;
        private ControlDateChooser ctrDateCreated2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ControlDoubleTextBoxRange ctrScore;
        private ControlDoubleTextBoxRange ctrBPM;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblBPM;
        private System.Windows.Forms.Label lblScore;
    }
}
