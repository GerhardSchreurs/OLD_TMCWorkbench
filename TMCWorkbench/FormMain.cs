using System;
using System.Windows.Forms;
using TMCWorkbench.Events;
using ModLibrary;
using System.Linq;
using TMCWorkbench.DB;

namespace TMCWorkbench
{
    public partial class FormMain : Form
    {
        public DBManager DB = DBManager.Instance;

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
            DB.LoadStyles();
            DB.LoadTrackstyles();
            toolStripStatusLabel.Text = "Done loading";

            txtSamplesOrg.Dock = DockStyle.Fill;
            txtSamplesNew.Dock = DockStyle.Fill;

            txtInstrumentsOrg.Dock = DockStyle.Fill;
            txtInstrumentsNew.Dock = DockStyle.Fill;

            txtMessageOrg.Dock = DockStyle.Fill;
            txtMessageNew.Dock = DockStyle.Fill;

            tabControl.SelectedIndex = 1;
        }

        private async void Handle_ListViewControl_OnSelected(object sender, Events.EventArgs.FileInfoEventArgs fileinfoEventArgs)
        {
            toolStripStatusLabel.Text = fileinfoEventArgs.FileInfo.FullName;
            await musicControl1.LoadTrack(fileinfoEventArgs.FileInfo.FullName);

            var guid = Manager.Instance.GetFileGuid(fileinfoEventArgs.FileInfo.FullName);
            var isInDb = DB.IsTrackInDB(guid);
            var modInfo = ModLibrary.ModLibrary.ParseAndGuessStyle(fileinfoEventArgs.FileInfo.FullName, DBManager.Instance.TrackStyles);
            var tupleTime = Tools.MillisecondsConverter.ConvertToMinutesAndSeconds(musicControl1.Media.Duration);
            //lblTest.Text = modInfo.TrackStyle;

            txtSamplesOrg.Text = modInfo.SampleText;
            txtMessageOrg.Text = modInfo.SongText;
            txtInstrumentsOrg.Text = modInfo.InstrumentText;

            txtSamplesOrg.ClearUndo();
            txtMessageOrg.ClearUndo();
            txtInstrumentsOrg.ClearUndo();

            ctrFileInfo.Text = modInfo.FileName;
            ctrDate.Date = modInfo.DateCreated;
            ctrLength.ValueA = tupleTime.Item1;
            ctrLength.ValueB = tupleTime.Item2;
            ctrSpeed.ValueA = modInfo.Speed;
            ctrSpeed.ValueB = modInfo.Tempo;
            ctrBPM.BPM = modInfo.EstimatedBPM;
            ctrStyle.Init();
            ctrStyle.SetStyle(modInfo.TrackStyle);

            
            if (isInDb)
            {
                if (DB.LoadTrackInfo(guid) == false) return;

                var track = DB.Track;

                txtSamplesNew.Text = track.SampleText;
                txtMessageNew.Text = track.SongText;
                txtInstrumentsNew.Text = track.InstrumentText;

                //ctrFileInfoNew.Text = track.FileName;
                //ctrDateNew.Date = track.Date_created;

                //ctrLengthNew.ValueA = 0;
                //ctrLengthNew.ValueB = 0;

                //ctrSpeedNew.ValueA = track.Speed;
                //ctrSpeedNew.ValueB = track.Tempo;

                //ctrBPMNew.BPM = track.Bpm;

                //ctrStyleNew.SetStyle(track.Style?.Name);
                //ctrComposerNew.SetComposer(track.FK_composer_id);


            }
   
        }

        private void Handle_BrowserControl_OnBrowse(object sender, Events.EventArgs.DirectoryInfoEventArgs playEventArgs)
        {
            listViewControl1.BrowseDirectory(playEventArgs.DirectoryInfo);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //var manager = new DB.DatabaseManager();

            //using (var context = new DatabaseContext())
            //{
            //    manager.SetupDB(context);

            //    //SetupDB(context);
            //    //LoadStuff(context);
            //    //PrintTable(context.Styles);
            //}

            using (var formTest = new FormTest())
            {
                formTest.ShowDialog();
            }
        }

        private void btnBla_Click(object sender, EventArgs e)
        {
            using (var formStyles = new UCStyles())
            {
                formStyles.ShowDialog();
            }
        }

        private void SwitchTabs(bool showNew)
        {
            if (showNew)
            {
                //NEW
                txtInstrumentsOrg.Visible = false;
                txtInstrumentsNew.Visible = true;

                txtMessageOrg.Visible = false;
                txtMessageNew.Visible = true;

                txtSamplesOrg.Visible = false;
                txtSamplesNew.Visible = true;

                //pnlMetaOrg.Visible = false;
                //pnlMetaNew.Visible = true;
            }
            else
            {
                //OLD
                txtInstrumentsOrg.Visible = true;
                txtInstrumentsNew.Visible = false;

                txtMessageOrg.Visible = true;
                txtMessageNew.Visible = false;

                txtSamplesOrg.Visible = true;
                txtSamplesNew.Visible = false;

                //pnlMetaOrg.Visible = true;
                //pnlMetaNew.Visible = false;

            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                SwitchTabs(true);
            } 
            else
            {
                SwitchTabs(false);
            }
        }

        private void stylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new UCStyles())
            {
                form.ShowDialog();
            }
        }

        private void scenegroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new UCSceneGroups())
            {
                form.ShowDialog();
            }
        }

        private void composersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new UCComposers())
            {
                form.ShowDialog();
            }
        }
    }
}
