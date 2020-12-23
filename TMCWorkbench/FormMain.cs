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

namespace TMCWorkbench
{
    public partial class FormMain : Form
    {
        public DBManager DB = DBManager.Instance;

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
            }
            if (_track != null)
            {
                txtSamplesNew.Text = _track.SampleText;
                txtInstrumentsNew.Text = _track.InstrumentText;
                txtMessageNew.Text = _track.SongText;
            }
        }

        private void GenerateSummary()
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

            var fileName = ctrMetaData.ctrFileInfo.Text;
            var title = ctrMetaData.ctrTrackTitle.Text;
            var style = ctrMetaData.ctrStyle.GetValue();
            var date = ctrMetaData.ctrDate.Date.HasValue ? ctrMetaData.ctrDate.Date.Value : new DateTime(1900,1,1);
            var composer = ctrMetaData.ctrComposer.GetValue();
            var scenegroup = ctrMetaData.ctrScenegroup.GetValue();
            var tracker = _mod.Tracker.GetValue();
            var bpm = _mod.EstimatedBPM; //TODO: TRACK

            if (style.IsNullOrEmpty())
            {
                style = ctrMetaData.ctrStyleText.Text;
            }
            if (composer.IsNullOrEmpty())
            {
                composer = ctrMetaData.ctrComposerText.Text;
            }
            if (scenegroup.IsNullOrEmpty())
            {
                scenegroup = ctrMetaData.ctrScenegroupText.Text;
            }

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
                //if ("aeiouAEIOU".IndexOf(style.Substring(0,1), StringComparison.InvariantCulture) >= 0)
                //{
                //    an = "an";
                //}

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
            ctrSummary.Text = text.ToString();
            





            //Generate text
            //var title = track == null ? modInfo.SongName : track.TrackTitle;
            //title = track == null ? $"{title} ({modInfo.FileName})" : $"{title} ({track.FileName})";
            //title = $"{title} is a";


            //if (track != null)
            //{
            //    //So we 
            //}
        }

        private ModInfo _mod;
        private Track _track;
        private Guid _guid;
        private bool _isInDB;

        private async void Handle_ListViewControl_OnSelected(object sender, Events.EventArgs.FileInfoEventArgs fileinfoEventArgs)
        {
            toolStripStatusLabel.Text = fileinfoEventArgs.FileInfo.FullName;
            await musicControl1.LoadTrack(fileinfoEventArgs.FileInfo.FullName).ConfigureAwait(true);

            _guid = Manager.Instance.GetFileGuid(fileinfoEventArgs.FileInfo.FullName);
            _isInDB = DB.IsTrackInDB(_guid);
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

            //Setup tabs
            EnableTabControl();

            if (_mod != null && _track == null)
            {
                DisableTabDatabase();
            } 
            else if (_track != null && _mod == null)
            {
                DisableTabOriginal();
            }

            SwitchTabs(_track != null);
            ctrMetaData.LoadData(_mod, _track, musicControl1.Media.Duration);

            GenerateSummary();
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

        private void btnSave_Click(object sender, EventArgs e)
        {

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
    }
}
