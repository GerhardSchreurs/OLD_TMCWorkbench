using System;
using System.Windows.Forms;
using TMCWorkbench.Events;
using ModLibrary;
using System.Linq;
using TMCWorkbench.DB;
using TMCDatabase.DBModel;
using System.Drawing;

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
            ctrMetaData.Init();

            splitContainer1.Panel2Collapsed = false;

            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += Handle_TabControl_DrawItem;
            tabControl.Selecting += Handle_TabControl_Selecting;
        }

        private void Handle_TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex < 0) return;
            e.Cancel = !e.TabPage.Enabled;
        }

        private void Handle_TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tab = tabControl.TabPages[e.Index];
            var color = Color.Black;
            
            if (tab.Enabled == false)
            {
                color = Color.LightGray;
            }
            else if (tabControl.SelectedTab == tab)
            {
                color = Color.Blue;
            }

            TextRenderer.DrawText(e.Graphics, tab.Text, e.Font, e.Bounds, color);
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

            tabControl.SelectedIndex = 0;
            SwitchTabs(false);
        }

        void EnableTabControl()
        {
            tabDatabase.Enabled = true;
            tabOriginal.Enabled = true;
            tabControl.Refresh();
        }

        void DisableTabDatabase()
        {
            ((Control)tabDatabase).Enabled = false;
            tabControl.Refresh();
        }
        
        void DisableTabOriginal()
        {
            ((Control)tabOriginal).Enabled = false;
            tabControl.Refresh();
        }

        void InitTextFields(ModInfo modInfo, Track track)
        {
            txtSamplesOrg.Text = "";
            txtInstrumentsOrg.Text = "";
            txtMessageOrg.Text = "";
            txtSamplesNew.Text = "";
            txtInstrumentsNew.Text = "";
            txtMessageNew.Text = "";

            if (modInfo != null)
            {
                txtSamplesOrg.Text = modInfo.SampleText;
                txtInstrumentsOrg.Text = modInfo.InstrumentText;
                txtMessageOrg.Text = modInfo.SongText;

                //if (track == null)
                //{
                //    SwitchTabs(false);
                //    DisableTabDatabase();
                //}
            }
            if (track != null)
            {
                txtSamplesNew.Text = track.SampleText;
                txtInstrumentsNew.Text = track.InstrumentText;
                txtMessageNew.Text = track.SongText;

                //SwitchTabs(true);
            }

        }

        private async void Handle_ListViewControl_OnSelected(object sender, Events.EventArgs.FileInfoEventArgs fileinfoEventArgs)
        {
            toolStripStatusLabel.Text = fileinfoEventArgs.FileInfo.FullName;
            await musicControl1.LoadTrack(fileinfoEventArgs.FileInfo.FullName);

            var guid = Manager.Instance.GetFileGuid(fileinfoEventArgs.FileInfo.FullName);
            var isInDb = DB.IsTrackInDB(guid);
            var modInfo = ModLibrary.ModLibrary.ParseAndGuessStyle(fileinfoEventArgs.FileInfo.FullName, DBManager.Instance.TrackStyles);

            Track track = null;

            if (isInDb)
            {
                if (DB.LoadTrackInfo(guid))
                {
                    track = DB.Track;
                }
            }

            InitTextFields(modInfo, track);

            //Setup tabs
            EnableTabControl();

            if (modInfo != null && track == null)
            {
                DisableTabDatabase();
            } 
            else if (track != null && modInfo == null)
            {
                DisableTabOriginal();
            }

            SwitchTabs(track != null);
            ctrMetaData.LoadData(modInfo, track, musicControl1.Media.Duration);
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
                //Original
                tabControl.SelectedTab = tabDatabase;

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
                //Database
                tabControl.SelectedTab = tabOriginal;

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
                SwitchTabs(false);
            } 
            else
            {
                SwitchTabs(true);
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
