using System;
using System.Windows.Forms;
using TMCWorkbench.Events;
using ModLibrary;
using System.Linq;
using TMCWorkbench.DB;
using TMCDatabase.DBModel;
using System.Drawing;
using TMCWorkbench;
using System.Text;
using TMCWorkbench.Extensions;
using TMCWorkbench.Properties;
using System.Diagnostics;

namespace TMCWorkbench
{
    public partial class FormMain : Form
    {
        public DBManager DB = DBManager.Instance;

        private ModInfo _mod;
        private Track _track;
        private Guid _guid;
        private bool _isInDB;

        public FormMain()
        {
            InitializeComponent();

            PositionForm();

            EventInvoker.OnBrowserControlBrowse += Handle_BrowserControl_OnBrowse;
            EventInvoker.OnListViewControlSelected += Handle_ListViewControl_OnSelected;

            browserControl1.Init();
            listViewControl1.Init();
            musicControl1.Init();
            ctrMetaData.Init();
            chkPreferSamples.Checked = true;

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
            tabDatabase.Enabled = false;
            tabControl.Refresh();
        }
        
        void DisableTabOriginal()
        {
            tabOriginal.Enabled = false;
            tabControl.Refresh();
        }

        void InitTextFields()
        {
            txtSamplesOrg.Text = "";
            txtInstrumentsOrg.Text = "";
            txtMessageOrg.Text = "";
            txtSamplesNew.Text = "";
            txtInstrumentsNew.Text = "";
            txtMessageNew.Text = "";

            if (_mod != null)
            {
                txtSamplesOrg.Text = _mod.SampleText;
                txtInstrumentsOrg.Text = _mod.InstrumentText;
                txtMessageOrg.Text = _mod.SongText;

                if (_track == null)
                {
                    txtSamplesNew.Text = _mod.SampleText;
                    txtInstrumentsNew.Text = _mod.InstrumentText;
                    txtMessageNew.Text = _mod.SongText;
                }
            }
            if (_track != null)
            {
                txtSamplesNew.Text = _track.SampleText;
                txtInstrumentsNew.Text = _track.InstrumentText;
                txtMessageNew.Text = _track.SongText;
            }
        }

        private void GetSampleText()
        {

        }

        private void GenerateTexts()
        {
            GenerateHeader();
            GenerateSummary();
        }

        private void GenerateSummary()
        {

        }


        private void GenerateHeader()
        {
            //Artificial Sun(ARTIFSUN.IT) is a 120 bpm Impulse Tracker Noise track that was created in 1997
            //C djnonsens of eXploitation.

            //Acid Rain (ACIDRAIN.IT) is a 140 bpm alternative Impulse tracker track that was created in 1998.
            //© djnonsens of eXploitation.

            //Acid Rain (ACIDRAIN.IT) is an impulse tracker alternative track at 140 bpm that was created in 1998.
            //© djnonsens of eXploitation.

            //Acid Rain(ACIDRAIN.IT) is a 140 bpm Impulse tracker rave style track. 
            //© 1998 - djnonsens of eXploitation.

            //Alisia went home(ALISIA.MOD) is a 125 bpm Protracker track that was created in 1997.
            //© Unknown.

            var fileName = ctrMetaData.FileName;
            var title = ctrMetaData.TrackTitle;
            var style = ctrMetaData.GetStyleCalulated();
            var date = ctrMetaData.Date.HasValue ? ctrMetaData.Date.Value : new DateTime(1900,1,1);
            var composer = ctrMetaData.GetComposerCalculated();
            var scenegroup = ctrMetaData.GetScenegroupCalulated();
            var tracker = ctrMetaData.Tracker;
            var bpm = ctrMetaData.Bpm;

            var text = new StringBuilder();
            
            if (title.IsNullOrEmpty())
            {
                text.Append($"{fileName} ");
            }
            else
            {
                text.Append($"{title} ({fileName}) ");
            }

            text.Append($"is a {bpm} bpm ");
            
            if (style.IsNotNullOrEmpty())
            {
                text.Append($"{style} ");
            }

            text.Append($"track.");
            text.AppendLine();
            text.Append($"© {date.Year} - ");

            if (composer.IsNotNullOrEmpty() && scenegroup.IsNotNullOrEmpty())
            {
                text.Append($"{composer} of {scenegroup}.");
            }
            else if (composer.IsNotNullOrEmpty())
            {
                text.Append($"{composer}.");
            }
            else if (scenegroup.IsNotNullOrEmpty())
            {
                text.Append($"{scenegroup}.");
            }
            else
            {
                text.Append("Unknown.");
            }

            text.Append($" Tracked with {tracker}.");
            ctrHeader.Text = text.ToString();
        }

        private async void Handle_ListViewControl_OnSelected(object sender, Events.EventArgs.FileInfoEventArgs fileinfoEventArgs)
        {
            toolStripStatusLabel.Text = fileinfoEventArgs.FileInfo.FullName;
            await musicControl1.LoadTrack(fileinfoEventArgs.FileInfo.FullName).ConfigureAwait(true);

            _isInDB = Manager.Instance.IsTrackInDB(fileinfoEventArgs.FileInfo.FullName);
            _guid = Manager.Instance.LastMd5Guid;
            _mod = ModLibrary.ModLibrary.ParseAndGuessStyle(fileinfoEventArgs.FileInfo.FullName, DBManager.Instance.TrackStyles);
            _track = null;

            if (_isInDB)
            {
                if (DB.LoadTrackInfo(_guid))
                {
                    _track = DB.Track;
                }
            }

            InitTextFields();

            bool newTrack = false;

            if (_track == null)
            {                
                _track = new Track();
                newTrack = true;
            }

            //Setup tabs
            EnableTabControl();

            //if (_mod != null && newTrack)
            //{
            //    DisableTabDatabase();
            //} 
            //else if (!newTrack && _mod == null)
            //{
            //    DisableTabOriginal();
            //}

            SwitchTabs(true);
            ctrMetaData.LoadData(_mod, _track, musicControl1.Media.Duration);

            GenerateTexts();
        }

        private void UpdateMetaData()
        {
            _track.FileName = ctrMetaData.FileName;
            _track.Md5 = Manager.Instance.GetFileGuid(ctrMetaData.FileName);
            _track.TrackTitle = ctrMetaData.TrackTitle;
            _track.Date_track_created = ctrMetaData.Date;
            _track.Date_track_modified = _mod.DateModified;
            _track.Length = ctrMetaData.LengthInMs;
            _track.Speed = ctrMetaData.Speed.ToSht();
            _track.Tempo = ctrMetaData.Tempo.ToSht();
            _track.Bpm = ctrMetaData.Bpm.ToSht();
            _track.FK_tracker_id = ctrMetaData.TrackerID;
            _track.FK_style_id = ctrMetaData.StyleID;
            _track.FK_composer_id = ctrMetaData.ComposerID;
            _track.FK_scenegroup_id = ctrMetaData.ScenegroupID;
            _track.StyleName = ctrMetaData.StyleText;
            _track.ComposerName = ctrMetaData.ComposerText;
            _track.ScenegroupName = ctrMetaData.ScenegroupText;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateMetaData();
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

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            PositionFormSave();
        }

        private void PositionFormSave()
        {
            // only save the WindowState if Normal or Maximized
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                case FormWindowState.Maximized:
                    Settings.Default.WindowState = this.WindowState;
                    break;

                default:
                    Settings.Default.WindowState = FormWindowState.Normal;
                    break;
            }

            // reset window state to normal to get the correct bounds
            // also make the form invisible to prevent distracting the user
            this.Visible = false;
            this.WindowState = FormWindowState.Normal;

            Settings.Default.WindowPosition = this.DesktopBounds;
            Settings.Default.Save();
        }

        private void PositionForm()
        {
            //https://stackoverflow.com/questions/937298/restoring-window-size-position-with-multiple-monitors
            // this is the default
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.WindowsDefaultBounds;

            // check if the saved bounds are nonzero and visible on any screen
            if (Settings.Default.WindowPosition != Rectangle.Empty &&
                IsVisibleOnAnyScreen(Settings.Default.WindowPosition))
            {
                // first set the bounds
                this.StartPosition = FormStartPosition.Manual;
                this.DesktopBounds = Settings.Default.WindowPosition;

                // afterwards set the window state to the saved value (which could be Maximized)
                this.WindowState = Settings.Default.WindowState;
            }
            else
            {
                // this resets the upper left corner of the window to windows standards
                this.StartPosition = FormStartPosition.WindowsDefaultLocation;

                // we can still apply the saved size
                var size = Settings.Default.WindowPosition.Size;

                if (size == Size.Empty)
                {
                    //TODO: TEST
                    size = new Size(Width, Height);
                }

                this.Size = size;
            }
        }

        private static bool IsVisibleOnAnyScreen(Rectangle rect)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.IntersectsWith(rect))
                {
                    return true;
                }
            }

            return false;
        }

        private void btnSaveAndContine_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshSummary_Click(object sender, EventArgs e)
        {
            GenerateHeader();
        }
    }
}
