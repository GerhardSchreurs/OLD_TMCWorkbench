namespace TMCWorkbench
{
    partial class FormTest
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
            this.btnTest = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tmcDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmcDataSet = new TMCWorkbench.tmcDataSet();
            this.tracksTableAdapter = new TMCWorkbench.tmcDataSetTableAdapters.tracksTableAdapter();
            this.trackersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackersTableAdapter = new TMCWorkbench.tmcDataSetTableAdapters.trackersTableAdapter();
            this.trackeridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmcDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmcDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(29, 33);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trackeridDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.extensionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.trackersBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(29, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(629, 285);
            this.dataGridView1.TabIndex = 1;
            // 
            // tmcDataSetBindingSource
            // 
            this.tmcDataSetBindingSource.DataSource = this.tmcDataSet;
            this.tmcDataSetBindingSource.Position = 0;
            // 
            // tmcDataSet
            // 
            this.tmcDataSet.DataSetName = "tmcDataSet";
            this.tmcDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tracksTableAdapter
            // 
            this.tracksTableAdapter.ClearBeforeFill = true;
            // 
            // trackersBindingSource
            // 
            this.trackersBindingSource.DataMember = "trackers";
            this.trackersBindingSource.DataSource = this.tmcDataSetBindingSource;
            // 
            // trackersTableAdapter
            // 
            this.trackersTableAdapter.ClearBeforeFill = true;
            // 
            // trackeridDataGridViewTextBoxColumn
            // 
            this.trackeridDataGridViewTextBoxColumn.DataPropertyName = "tracker_id";
            this.trackeridDataGridViewTextBoxColumn.HeaderText = "tracker_id";
            this.trackeridDataGridViewTextBoxColumn.Name = "trackeridDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // extensionDataGridViewTextBoxColumn
            // 
            this.extensionDataGridViewTextBoxColumn.DataPropertyName = "extension";
            this.extensionDataGridViewTextBoxColumn.HeaderText = "extension";
            this.extensionDataGridViewTextBoxColumn.Name = "extensionDataGridViewTextBoxColumn";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnTest);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmcDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmcDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource tmcDataSetBindingSource;
        private tmcDataSet tmcDataSet;
        private tmcDataSetTableAdapters.tracksTableAdapter tracksTableAdapter;
        private System.Windows.Forms.BindingSource trackersBindingSource;
        private tmcDataSetTableAdapters.trackersTableAdapter trackersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackeridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionDataGridViewTextBoxColumn;
    }
}