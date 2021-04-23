
namespace TMCWorkbench.Controls
{
    partial class EditableListControl
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
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tableLayoutBot = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddScenegroup = new System.Windows.Forms.Button();
            this.txtAddSceneGroup = new System.Windows.Forms.TextBox();
            this.gridGroups = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.tableLayoutTop.SuspendLayout();
            this.tableLayoutBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.tableLayoutTop, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.tableLayoutBot, 0, 2);
            this.tableLayoutPanelLeft.Controls.Add(this.gridGroups, 0, 1);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 3;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(499, 338);
            this.tableLayoutPanelLeft.TabIndex = 1;
            // 
            // tableLayoutTop
            // 
            this.tableLayoutTop.ColumnCount = 2;
            this.tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutTop.Controls.Add(this.txtSearch, 0, 0);
            this.tableLayoutTop.Controls.Add(this.btnSearch, 1, 0);
            this.tableLayoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutTop.Name = "tableLayoutTop";
            this.tableLayoutTop.RowCount = 1;
            this.tableLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutTop.Size = new System.Drawing.Size(499, 40);
            this.tableLayoutTop.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(353, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(377, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // tableLayoutBot
            // 
            this.tableLayoutBot.ColumnCount = 2;
            this.tableLayoutBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutBot.Controls.Add(this.btnAddScenegroup, 0, 0);
            this.tableLayoutBot.Controls.Add(this.txtAddSceneGroup, 0, 0);
            this.tableLayoutBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBot.Location = new System.Drawing.Point(0, 298);
            this.tableLayoutBot.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBot.Name = "tableLayoutBot";
            this.tableLayoutBot.RowCount = 1;
            this.tableLayoutBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutBot.Size = new System.Drawing.Size(499, 40);
            this.tableLayoutBot.TabIndex = 1;
            // 
            // btnAddScenegroup
            // 
            this.btnAddScenegroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddScenegroup.Location = new System.Drawing.Point(377, 14);
            this.btnAddScenegroup.Name = "btnAddScenegroup";
            this.btnAddScenegroup.Size = new System.Drawing.Size(119, 23);
            this.btnAddScenegroup.TabIndex = 2;
            this.btnAddScenegroup.Text = "Add";
            this.btnAddScenegroup.UseVisualStyleBackColor = true;
            // 
            // txtAddSceneGroup
            // 
            this.txtAddSceneGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAddSceneGroup.Location = new System.Drawing.Point(3, 17);
            this.txtAddSceneGroup.Name = "txtAddSceneGroup";
            this.txtAddSceneGroup.Size = new System.Drawing.Size(327, 20);
            this.txtAddSceneGroup.TabIndex = 1;
            // 
            // gridGroups
            // 
            this.gridGroups.AllowUserToAddRows = false;
            this.gridGroups.AllowUserToResizeRows = false;
            this.gridGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGroups.Location = new System.Drawing.Point(3, 43);
            this.gridGroups.Name = "gridGroups";
            this.gridGroups.ReadOnly = true;
            this.gridGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGroups.Size = new System.Drawing.Size(493, 252);
            this.gridGroups.TabIndex = 2;
            // 
            // EditableListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelLeft);
            this.Name = "EditableListControl";
            this.Size = new System.Drawing.Size(499, 338);
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.tableLayoutTop.ResumeLayout(false);
            this.tableLayoutTop.PerformLayout();
            this.tableLayoutBot.ResumeLayout(false);
            this.tableLayoutBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBot;
        private System.Windows.Forms.Button btnAddScenegroup;
        private System.Windows.Forms.TextBox txtAddSceneGroup;
        private System.Windows.Forms.DataGridView gridGroups;
    }
}
