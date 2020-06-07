using System;
using System.Windows.Forms;
using TMCWorkbench.Events;
using TMCWorkbench.Database;
using ModLibrary;

namespace TMCWorkbench
{
    public partial class FormMain : Form
    {
        private DB _db =  Database.DB.Instance();

        public FormMain()
        {
            InitializeComponent();

            EventInvoker.OnBrowserControlBrowse += Handle_BrowserControl_OnBrowse;
            EventInvoker.OnListViewControlSelected += Handle_ListViewControl_OnSelected;

            browserControl1.Init();
            listViewControl1.Init();
            musicControl1.Init();

            splitContainer1.Panel2Collapsed = false;
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Loading";
            await _db.GetDataTables();
            toolStripStatusLabel.Text = "Done loading";
        }

        private async void Handle_ListViewControl_OnSelected(object sender, Events.EventArgs.FileInfoEventArgs fileinfoEventArgs)
        {
            toolStripStatusLabel.Text = fileinfoEventArgs.FileInfo.FullName;
            await musicControl1.LoadTrack(fileinfoEventArgs.FileInfo.FullName);

            var modInfo = ModLibrary.ModLibrary.Parse(fileinfoEventArgs.FileInfo.FullName);
            var tupleTime = Tools.MillisecondsConverter.ConvertToMinutesAndSeconds(musicControl1.Media.Duration);

            txtSamples.Text = modInfo.SampleText;
            txtMessage.Text = modInfo.SongText;
            txtInstruments.Text = modInfo.InstrumentText;

            txtSamples.ClearUndo();
            txtMessage.ClearUndo();
            txtInstruments.ClearUndo();

            ctrFileInfo.Filename = modInfo.FileName;
            ctrDate.Date = modInfo.DateCreated;

            ctrLength.ValueA = tupleTime.Item1;
            ctrLength.ValueB = tupleTime.Item2;

            ctrSpeed.ValueA = modInfo.Speed;
            ctrSpeed.ValueB = modInfo.Tempo;

            ctrBPM.BPM = modInfo.EstimatedBPM;
        }

        private void Handle_BrowserControl_OnBrowse(object sender, Events.EventArgs.DirectoryInfoEventArgs playEventArgs)
        {
            listViewControl1.BrowseDirectory(playEventArgs.DirectoryInfo);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //using (var formTest = new FormTest())
            //{
            //    formTest.ShowDialog();
            //}

            DB.Instance().TableStyles.Rows[0].Name = "woehaa";
            DB.Instance().TableStyles.DeleteRowById(64);

            var row = DB.Instance().TableStyles.NewRow();

            row.Name = "new";
            row.Weight = -1;

            DB.Instance().TableStyles.AddRow(row);

            DB.Instance().TableStyles.UpdateData();

        }

        private void btnBla_Click(object sender, EventArgs e)
        {
            using (var formStyles = new UCStyles())
            {
                formStyles.ShowDialog();
            }
        }
    }
}
