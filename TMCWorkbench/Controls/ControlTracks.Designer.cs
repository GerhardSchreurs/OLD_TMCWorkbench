
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
            this.tblTopRightControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ddlFormat = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tblBottomControlsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ctrMetaData = new TMCWorkbench.Controls.ControlHintTextBox();
            this.ctrFileName = new TMCWorkbench.Controls.ControlHintTextBox();
            this.ctrTrackTitle = new TMCWorkbench.Controls.ControlHintTextBox();
            this.controlHintTextBox4 = new TMCWorkbench.Controls.ControlHintTextBox();
            this.controlHintTextBox1 = new TMCWorkbench.Controls.ControlHintTextBox();
            this.controlHintTextBox2 = new TMCWorkbench.Controls.ControlHintTextBox();
            this.controlHintTextBox3 = new TMCWorkbench.Controls.ControlHintTextBox();
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
            this.tableLayoutPanel1.Controls.Add(this.controlHintTextBox4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.controlHintTextBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.controlHintTextBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.controlHintTextBox3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 40);
            this.tableLayoutPanel1.TabIndex = 7;
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
            // controlHintTextBox4
            // 
            this.controlHintTextBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHintTextBox4.Hint = "Scenegroup";
            this.controlHintTextBox4.Location = new System.Drawing.Point(153, 3);
            this.controlHintTextBox4.Name = "controlHintTextBox4";
            this.controlHintTextBox4.Size = new System.Drawing.Size(144, 20);
            this.controlHintTextBox4.TabIndex = 3;
            // 
            // controlHintTextBox1
            // 
            this.controlHintTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHintTextBox1.Hint = "Tags";
            this.controlHintTextBox1.Location = new System.Drawing.Point(453, 3);
            this.controlHintTextBox1.Name = "controlHintTextBox1";
            this.controlHintTextBox1.Size = new System.Drawing.Size(144, 20);
            this.controlHintTextBox1.TabIndex = 2;
            // 
            // controlHintTextBox2
            // 
            this.controlHintTextBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHintTextBox2.Hint = "Composer";
            this.controlHintTextBox2.Location = new System.Drawing.Point(303, 3);
            this.controlHintTextBox2.Name = "controlHintTextBox2";
            this.controlHintTextBox2.Size = new System.Drawing.Size(144, 20);
            this.controlHintTextBox2.TabIndex = 1;
            // 
            // controlHintTextBox3
            // 
            this.controlHintTextBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlHintTextBox3.Hint = "Style";
            this.controlHintTextBox3.Location = new System.Drawing.Point(3, 3);
            this.controlHintTextBox3.Name = "controlHintTextBox3";
            this.controlHintTextBox3.Size = new System.Drawing.Size(144, 20);
            this.controlHintTextBox3.TabIndex = 0;
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
        private ControlHintTextBox controlHintTextBox1;
        private ControlHintTextBox controlHintTextBox2;
        private ControlHintTextBox controlHintTextBox3;
        private ControlHintTextBox controlHintTextBox4;
    }
}
