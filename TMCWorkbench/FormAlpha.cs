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
using System.Text.RegularExpressions;

namespace TMCWorkbench
{
    public partial class FormAlpha : Form
    {
        public DBManager DB = DBManager.Instance;

        private const string HEADER = "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■";

        private readonly Regex _regRemoveNewLines = new Regex("(\r\n){2,}");
        private readonly Regex _regRemoveSpaces = new Regex("[ ]{1,}");
        private readonly Regex _regRemoveLeadingStringSpace = new Regex("^\\s", RegexOptions.Multiline);

        private readonly Regex _regLimitRemoveNewLines = new Regex("(\r?\n)");


        private ModInfo _mod;
        private Track _track;
        private Guid _guid;
        private bool _isInDB;

        private bool HasMod
        {
            get => _mod != null;
        }

        private bool HasTrack
        {
            get => _track != null && _track.Md5 != Guid.Empty;
        }

        public FormAlpha()
        {
            InitializeComponent();

            PositionForm();

            EventInvoker.OnBrowserControlBrowse += Handle_ctrBrowser_OnBrowse;
            EventInvoker.OnListViewControlSelected += Handle_ctrTracks_OnSelected;

            ctrBrowser.Init();
            ctrTracks.Init();
            ctrPlayer.Init();
            ctrMetaData.Init();

            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += Handle_TabControl_DrawItem;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Loading";
            DB.LoadStyles();
            DB.LoadTrackstyles();
            toolStripStatusLabel.Text = "Done loading";
            tabControl.SelectedIndex = 0;
            SwitchTabs(false);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            PositionFormSave();
        }

        #region EVENT_CONTROLS
        private void Handle_ctrBrowser_OnBrowse(object sender, Events.EventArgs.DirectoryInfoEventArgs playEventArgs)
        {
            ctrTracks.BrowseDirectory(playEventArgs.DirectoryInfo);
        }

        private async void Handle_ctrTracks_OnSelected(object sender, Events.EventArgs.FileInfoEventArgs fileinfoEventArgs)
        {
            toolStripStatusLabel.Text = fileinfoEventArgs.FileInfo.FullName;
            await ctrPlayer.LoadTrack(fileinfoEventArgs.FileInfo.FullName).ConfigureAwait(true);

            _isInDB = Manager.Instance.IsTrackInDB(fileinfoEventArgs.FileInfo.FullName);
            _guid = Manager.Instance.LastMd5Guid;
            _mod = ModLibrary.ModLibrary.ParseAndGuessStyle(fileinfoEventArgs.FileInfo.FullName, DBManager.Instance.TrackStyles);
            _track = null;

            if (_isInDB && (DB.LoadTrackInfo(_guid)))
            {
                _track = DB.Track;
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
            ctrMetaData.LoadData(_mod, _track, ctrPlayer.Media.Duration);

            GenerateYoutubeTexts();
        }
        #endregion

        #region EVENT_BUTTON
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GenerateYoutubeTexts();
        }

        private void Handle_btnSaveAndContine_Click(object sender, EventArgs e)
        {

        }

        private void Handle_btnSave_Click(object sender, EventArgs e)
        {
            UpdateMetaData();
        }

        private void Handle_btnTest_Click(object sender, EventArgs e)
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

        private void Handle_btnBla_Click(object sender, EventArgs e)
        {
            using (var formStyles = new UCStyles())
            {
                formStyles.ShowDialog();
            }
        }
        #endregion 

        #region EVENT_MENU
        private void Handle_stylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new UCStyles())
            {
                form.ShowDialog();
            }
        }

        private void Handle_scenegroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new UCSceneGroups())
            {
                form.ShowDialog();
            }
        }

        private void Handle_composersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new UCComposers())
            {
                form.ShowDialog();
            }
        }
        #endregion

        void InitTextFields()
        {
            ctrMessage.Clear();
            ctrSamples.Clear();
            ctrInstruments.Clear();
            ctrOutput.Clear();

            if (HasMod)
            {
                ctrSamples.TextOrg = _mod.SampleText;
                ctrInstruments.TextOrg = _mod.InstrumentText;
                ctrMessage.TextOrg = _mod.SongText;

                if (HasTrack == false)
                {
                    ctrSamples.TextNew = _mod.SampleText;
                    ctrInstruments.TextNew = _mod.InstrumentText;
                    ctrMessage.TextNew = _mod.SongText;
                }
            }

            if (HasTrack)
            {
                ctrSamples.TextNew = _track.SampleText;
                ctrInstruments.TextNew = _track.InstrumentText;
                ctrMessage.TextNew = _track.SongText;
            }
        }

        private void GenerateYoutubeTexts()
        {
            GenerateHeader();
            GenerateSummary();
        }

        private string GenerateParagraph(string title, string text)
        {
            if (text.IsNullOrEmpty()) return string.Empty;
            return $"{title}{C.BR}{HEADER}{C.BR}{text}{C.BR}{C.BR}";
        }

        private void GenerateSummary()
        {
            var output = new StringBuilder();

            var samples = ctrSamples.TextNew;
            var instruments = ctrInstruments.TextNew;
            var message = ctrMessage.TextNew;

            message = GenerateParagraph("MESSAGE", CleanUpText(message));
            samples = GenerateParagraph("SAMPLES", CleanUpText(samples));
            instruments = GenerateParagraph("INSTRUMENTS", CleanUpText(instruments));

            output.Append(message);
            output.Append(samples);
            output.Append(instruments);

            var text = output.ToString().Trim();

            if (text.Length > C.YOUTUBEMAXLENGTH)
            {
                //TODO:
                //message = _regLimitRemoveNewLines.Replace(message, "");
                throw new Exception("Investigate this!");
            }

            ctrOutput.TextSummaryNew = text;
        }

        private string CleanUpText(string text)
        {
            //First, remove all newlines over 2
            text = _regRemoveNewLines.Replace(text, $"{C.BR}{C.BR}");
            text = text.Replace($"{C.BR}{C.BR}{C.BR}", $"{C.BR}{C.BR}");
            text = _regRemoveSpaces.Replace(text, " ");
            text = _regRemoveLeadingStringSpace.Replace(text, "");

            return text.Trim();
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
            var date = ctrMetaData.Date.HasValue ? ctrMetaData.Date.Value : new DateTime(1900, 1, 1);
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
            ctrOutput.TextHeaderNew = text.ToString();
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

        #region TABS
        private void Handle_TabControl_Selected(object sender, TabControlEventArgs e)
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

        private void EnableTabControl()
        {
            tabDatabase.Enabled = true;
            tabOriginal.Enabled = true;
            tabControl.Refresh();
        }

        private void DisableTabDatabase()
        {
            tabDatabase.Enabled = false;
            tabControl.Refresh();
        }

        private void DisableTabOriginal()
        {
            tabOriginal.Enabled = false;
            tabControl.Refresh();
        }

        private void SwitchTabs(bool showNew)
        {
            if (showNew)
            {
                //Original
                tabControl.SelectedTab = tabDatabase;
            }
            else
            {
                //Database
                tabControl.SelectedTab = tabOriginal;
            }

            ctrMessage.Show(showNew);
            ctrSamples.Show(showNew);
            ctrInstruments.Show(showNew);
            ctrOutput.Show(showNew);
        }
        #endregion TABS

        #region SAVEFORMPOSITION
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
        #endregion SAVEFORMPOSITION
    }
}
