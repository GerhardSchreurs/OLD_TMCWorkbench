
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
            this.listView = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStyle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateSaved = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tblTopControls = new System.Windows.Forms.TableLayoutPanel();
            this.ctrMetaData = new TMCWorkbench.Controls.ControlHintTextBox();
            this.ctrFileName = new TMCWorkbench.Controls.ControlHintTextBox();
            this.ctrTrackTitle = new TMCWorkbench.Controls.ControlHintTextBox();
            this.tblTopRightControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ddlFormat = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tblBottomControlsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ddlTags = new TMCWorkbench.Controls.ControlCheckBoxDropDown();
            this.lblTags = new System.Windows.Forms.Label();
            this.lblComposer = new System.Windows.Forms.Label();
            this.lblScenegroup = new System.Windows.Forms.Label();
            this.ddlStyles = new TMCWorkbench.Controls.ControlCheckBoxDropDown();
            this.lblStyles = new System.Windows.Forms.Label();
            this.ddlComposer = new TMCWorkbench.Controls.DropDownList();
            this.ddlScenegroup = new TMCWorkbench.Controls.DropDownList();
            this.tblOuter.SuspendLayout();
            this.tblTopControls.SuspendLayout();
            this.tblTopRightControls.SuspendLayout();
            this.tblBottomControlsContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblOuter
            // 
            this.tblOuter.ColumnCount = 1;
            this.tblOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblOuter.Controls.Add(this.listView, 0, 2);
            this.tblOuter.Controls.Add(this.tblTopControls, 0, 0);
            this.tblOuter.Controls.Add(this.tblBottomControlsContainer, 0, 1);
            this.tblOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOuter.Location = new System.Drawing.Point(0, 0);
            this.tblOuter.Name = "tblOuter";
            this.tblOuter.RowCount = 3;
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblOuter.Size = new System.Drawing.Size(600, 749);
            this.tblOuter.TabIndex = 0;
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
            this.listView.Location = new System.Drawing.Point(3, 113);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(594, 633);
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
            this.tblBottomControlsContainer.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tblBottomControlsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBottomControlsContainer.Location = new System.Drawing.Point(0, 30);
            this.tblBottomControlsContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tblBottomControlsContainer.Name = "tblBottomControlsContainer";
            this.tblBottomControlsContainer.RowCount = 3;
            this.tblBottomControlsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblBottomControlsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblBottomControlsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblBottomControlsContainer.Size = new System.Drawing.Size(600, 80);
            this.tblBottomControlsContainer.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.ddlTags, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTags, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblComposer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblScenegroup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ddlStyles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblStyles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ddlComposer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ddlScenegroup, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 40);
            this.tableLayoutPanel1.TabIndex = 7;
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
            // lblStyles
            // 
            this.lblStyles.AutoSize = true;
            this.lblStyles.Location = new System.Drawing.Point(3, 0);
            this.lblStyles.Name = "lblStyles";
            this.lblStyles.Size = new System.Drawing.Size(41, 13);
            this.lblStyles.TabIndex = 2;
            this.lblStyles.Text = "Style(s)";
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
            this.tblTopControls.ResumeLayout(false);
            this.tblTopControls.PerformLayout();
            this.tblTopRightControls.ResumeLayout(false);
            this.tblBottomControlsContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ControlCheckBoxDropDown ddlStyles;
        private System.Windows.Forms.Label lblStyles;
        private System.Windows.Forms.Label lblScenegroup;
        private System.Windows.Forms.Label lblComposer;
        private ControlCheckBoxDropDown ddlTags;
        private System.Windows.Forms.Label lblTags;
        private DropDownList ddlComposer;
        private DropDownList ddlScenegroup;
    }
}
