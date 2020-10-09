﻿namespace TMCWorkbench
{
    partial class UCMembers
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrSave = new TMCWorkbench.Controls.Resettable.ResettableButtonControl();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeftTop = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanelLeftBot = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddComposer1 = new System.Windows.Forms.Button();
            this.txtAddComposer1 = new System.Windows.Forms.TextBox();
            this.gridComposers = new System.Windows.Forms.DataGridView();
            this.ctrAbout = new TMCWorkbench.Controls.Resettable.ResettableTextAreaControl();
            this.ctrDateStop = new TMCWorkbench.Controls.Resettable.ResettableDateControl();
            this.ctrDateStart = new TMCWorkbench.Controls.Resettable.ResettableDateControl();
            this.ctrName = new TMCWorkbench.Controls.Resettable.ResettableTextControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.ddlGroups = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.gridGroups = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelOuter = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelDivider = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.tableLayoutPanelLeftTop.SuspendLayout();
            this.tableLayoutPanelLeftBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridComposers)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroups)).BeginInit();
            this.tableLayoutPanelOuter.SuspendLayout();
            this.tableLayoutPanelDivider.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Member of scenegroups:";
            // 
            // ctrSave
            // 
            this.ctrSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrSave.LabelTitle = "Save";
            this.ctrSave.Location = new System.Drawing.Point(0, 178);
            this.ctrSave.Margin = new System.Windows.Forms.Padding(0);
            this.ctrSave.Name = "ctrSave";
            this.ctrSave.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ctrSave.Size = new System.Drawing.Size(461, 24);
            this.ctrSave.TabIndex = 12;
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.tableLayoutPanelLeftTop, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.tableLayoutPanelLeftBot, 0, 2);
            this.tableLayoutPanelLeft.Controls.Add(this.gridComposers, 0, 1);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 3;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(473, 536);
            this.tableLayoutPanelLeft.TabIndex = 0;
            // 
            // tableLayoutPanelLeftTop
            // 
            this.tableLayoutPanelLeftTop.ColumnCount = 2;
            this.tableLayoutPanelLeftTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeftTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanelLeftTop.Controls.Add(this.txtSearch, 0, 0);
            this.tableLayoutPanelLeftTop.Controls.Add(this.btnSearch, 1, 0);
            this.tableLayoutPanelLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLeftTop.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLeftTop.Name = "tableLayoutPanelLeftTop";
            this.tableLayoutPanelLeftTop.RowCount = 1;
            this.tableLayoutPanelLeftTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeftTop.Size = new System.Drawing.Size(473, 40);
            this.tableLayoutPanelLeftTop.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(327, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(351, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelLeftBot
            // 
            this.tableLayoutPanelLeftBot.ColumnCount = 2;
            this.tableLayoutPanelLeftBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeftBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanelLeftBot.Controls.Add(this.btnAddComposer1, 0, 0);
            this.tableLayoutPanelLeftBot.Controls.Add(this.txtAddComposer1, 0, 0);
            this.tableLayoutPanelLeftBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeftBot.Location = new System.Drawing.Point(0, 496);
            this.tableLayoutPanelLeftBot.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLeftBot.Name = "tableLayoutPanelLeftBot";
            this.tableLayoutPanelLeftBot.RowCount = 1;
            this.tableLayoutPanelLeftBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeftBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeftBot.Size = new System.Drawing.Size(473, 40);
            this.tableLayoutPanelLeftBot.TabIndex = 1;
            // 
            // btnAddComposer1
            // 
            this.btnAddComposer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddComposer1.Location = new System.Drawing.Point(351, 14);
            this.btnAddComposer1.Name = "btnAddComposer1";
            this.btnAddComposer1.Size = new System.Drawing.Size(119, 23);
            this.btnAddComposer1.TabIndex = 2;
            this.btnAddComposer1.Text = "Add";
            this.btnAddComposer1.UseVisualStyleBackColor = true;
            // 
            // txtAddComposer1
            // 
            this.txtAddComposer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAddComposer1.Location = new System.Drawing.Point(3, 17);
            this.txtAddComposer1.Name = "txtAddComposer1";
            this.txtAddComposer1.Size = new System.Drawing.Size(327, 20);
            this.txtAddComposer1.TabIndex = 1;
            // 
            // gridComposers
            // 
            this.gridComposers.AllowUserToAddRows = false;
            this.gridComposers.AllowUserToResizeRows = false;
            this.gridComposers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridComposers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridComposers.Location = new System.Drawing.Point(3, 43);
            this.gridComposers.Name = "gridComposers";
            this.gridComposers.ReadOnly = true;
            this.gridComposers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridComposers.Size = new System.Drawing.Size(467, 450);
            this.gridComposers.TabIndex = 2;
            // 
            // ctrAbout
            // 
            this.ctrAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrAbout.LabelTitle = "About:";
            this.ctrAbout.Location = new System.Drawing.Point(0, 72);
            this.ctrAbout.Name = "ctrAbout";
            this.ctrAbout.Size = new System.Drawing.Size(461, 100);
            this.ctrAbout.TabIndex = 11;
            // 
            // ctrDateStop
            // 
            this.ctrDateStop.Date = new System.DateTime(((long)(0)));
            this.ctrDateStop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrDateStop.LabelTitle = "Date stopped:";
            this.ctrDateStop.Location = new System.Drawing.Point(0, 48);
            this.ctrDateStop.Margin = new System.Windows.Forms.Padding(0);
            this.ctrDateStop.Name = "ctrDateStop";
            this.ctrDateStop.Size = new System.Drawing.Size(461, 24);
            this.ctrDateStop.TabIndex = 10;
            // 
            // ctrDateStart
            // 
            this.ctrDateStart.Date = new System.DateTime(((long)(0)));
            this.ctrDateStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrDateStart.LabelTitle = "Date started:";
            this.ctrDateStart.Location = new System.Drawing.Point(0, 24);
            this.ctrDateStart.Margin = new System.Windows.Forms.Padding(0);
            this.ctrDateStart.Name = "ctrDateStart";
            this.ctrDateStart.Size = new System.Drawing.Size(461, 24);
            this.ctrDateStart.TabIndex = 9;
            // 
            // ctrName
            // 
            this.ctrName.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrName.LabelTitle = "Name:";
            this.ctrName.Location = new System.Drawing.Point(0, 0);
            this.ctrName.Margin = new System.Windows.Forms.Padding(0);
            this.ctrName.Name = "ctrName";
            this.ctrName.Size = new System.Drawing.Size(461, 24);
            this.ctrName.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrAbout);
            this.panel1.Controls.Add(this.ctrDateStop);
            this.panel1.Controls.Add(this.ctrDateStart);
            this.panel1.Controls.Add(this.ctrName);
            this.panel1.Controls.Add(this.ctrSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 202);
            this.panel1.TabIndex = 2;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGroup.Location = new System.Drawing.Point(345, 14);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(119, 23);
            this.btnAddGroup.TabIndex = 2;
            this.btnAddGroup.Text = "Add";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            // 
            // ddlGroups
            // 
            this.ddlGroups.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ddlGroups.FormattingEnabled = true;
            this.ddlGroups.Location = new System.Drawing.Point(3, 16);
            this.ddlGroups.Name = "ddlGroups";
            this.ddlGroups.Size = new System.Drawing.Size(321, 21);
            this.ddlGroups.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddGroup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ddlGroups, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 490);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(467, 40);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelRight.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tableLayoutPanelRight.Controls.Add(this.gridGroups, 0, 2);
            this.tableLayoutPanelRight.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(516, 3);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 4;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(467, 530);
            this.tableLayoutPanelRight.TabIndex = 1;
            // 
            // gridGroups
            // 
            this.gridGroups.AllowUserToAddRows = false;
            this.gridGroups.AllowUserToResizeRows = false;
            this.gridGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGroups.Location = new System.Drawing.Point(3, 241);
            this.gridGroups.Name = "gridGroups";
            this.gridGroups.ReadOnly = true;
            this.gridGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGroups.Size = new System.Drawing.Size(461, 246);
            this.gridGroups.TabIndex = 3;
            // 
            // tableLayoutPanelOuter
            // 
            this.tableLayoutPanelOuter.ColumnCount = 1;
            this.tableLayoutPanelOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOuter.Controls.Add(this.tableLayoutPanelDivider, 0, 0);
            this.tableLayoutPanelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOuter.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelOuter.Name = "tableLayoutPanelOuter";
            this.tableLayoutPanelOuter.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanelOuter.RowCount = 1;
            this.tableLayoutPanelOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelOuter.Size = new System.Drawing.Size(1032, 582);
            this.tableLayoutPanelOuter.TabIndex = 1;
            // 
            // tableLayoutPanelDivider
            // 
            this.tableLayoutPanelDivider.ColumnCount = 3;
            this.tableLayoutPanelDivider.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDivider.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelDivider.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDivider.Controls.Add(this.tableLayoutPanelLeft, 0, 0);
            this.tableLayoutPanelDivider.Controls.Add(this.tableLayoutPanelRight, 2, 0);
            this.tableLayoutPanelDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDivider.Location = new System.Drawing.Point(23, 23);
            this.tableLayoutPanelDivider.Name = "tableLayoutPanelDivider";
            this.tableLayoutPanelDivider.RowCount = 1;
            this.tableLayoutPanelDivider.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDivider.Size = new System.Drawing.Size(986, 536);
            this.tableLayoutPanelDivider.TabIndex = 0;
            // 
            // UCMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 582);
            this.Controls.Add(this.tableLayoutPanelOuter);
            this.Name = "UCMembers";
            this.Text = "UCMembers";
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.tableLayoutPanelLeftTop.ResumeLayout(false);
            this.tableLayoutPanelLeftTop.PerformLayout();
            this.tableLayoutPanelLeftBot.ResumeLayout(false);
            this.tableLayoutPanelLeftBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridComposers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.tableLayoutPanelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroups)).EndInit();
            this.tableLayoutPanelOuter.ResumeLayout(false);
            this.tableLayoutPanelDivider.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.Resettable.ResettableButtonControl ctrSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeftTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeftBot;
        private System.Windows.Forms.Button btnAddComposer1;
        private System.Windows.Forms.TextBox txtAddComposer1;
        private System.Windows.Forms.DataGridView gridComposers;
        private Controls.Resettable.ResettableTextAreaControl ctrAbout;
        private Controls.Resettable.ResettableDateControl ctrDateStop;
        private Controls.Resettable.ResettableDateControl ctrDateStart;
        private Controls.Resettable.ResettableTextControl ctrName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.ComboBox ddlGroups;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private System.Windows.Forms.DataGridView gridGroups;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOuter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDivider;
    }
}