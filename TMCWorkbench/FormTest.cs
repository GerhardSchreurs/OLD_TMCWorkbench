using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.Tools;

namespace TMCWorkbench
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //var db = Tools.DatabaseManager.Instance();

            //if (db.IsConnect())
            //{
            //    MessageBox.Show("Success");
            //    db.Connection.Close();
            //}

            var x = new Database.Executor(Properties.Private.Default.ConnectionString);
            x.DataSetCreate("MyDataSet");
            x.DataSetQueryAdd("SELECT * FROM trackers");
            x.DataSetFill();

            var ds = x.DataSet;
            var table = ds.Tables[0];

            var row = table.NewRow();

            row[0] = "5";
            row[1] = "Test";
            row[2] = "tst";

            table.Rows.Add(row);

            x.DataSetSave();


            //var table = x.GetDataTable("SELECT * From trackers");
            //x.DataSetSave();

            //MessageBox.Show(table.Rows.Count.ToString());
            //x.Dispose();

        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tmcDataSet.trackers' table. You can move, or remove it, as needed.
            this.trackersTableAdapter.Fill(this.tmcDataSet.trackers);

        }
    }
}
