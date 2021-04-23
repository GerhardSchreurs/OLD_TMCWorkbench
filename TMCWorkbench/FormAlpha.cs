﻿using System;
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
using System.Threading.Tasks;
using TMCWorkbench.Model;

namespace TMCWorkbench
{
    public partial class FormAlpha : Form
    {
        public DBManager DB = DBManager.Instance;
        private Bag _bag;
        private ModInfo _mod;
        private Track _track;
        private string _lastPath;

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
            DB.LoadTrackstyles();
            toolStripStatusLabel.Text = "Done loading";
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

        private async void Handle_ctrTracks_OnSelected(object sender, string fullName)
        {
            await LoadTrack(fullName);
        }
        #endregion

        #region EVENT_BUTTON
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //TODO refresh ctrOutput
        }

        private void Handle_btnSaveAndContine_Click(object sender, EventArgs e)
        {

        }

        private async void Handle_btnSave_Click(object sender, EventArgs e)
        {
            await SaveTrack();
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

        private async Task LoadTrack(string path)
        {
            toolStripStatusLabel.Text = path;
            long duration = 0;

            if (path != _lastPath)
            {
                await ctrPlayer.LoadTrack(path);

                duration = ctrPlayer.Media.Duration;
                _lastPath = path;
            }

            _bag = new Bag();

            await _bag.Load(path, duration);
            //For easy reference
            _mod = _bag.Mod;
            _track = _bag.Track;

            ctrMetaData.LoadData(_bag);
            InitTextFields();

            EnableTabControl();
            SwitchTabs(true);
        }

        //private async Task LoadTrackOLD(string path)
        //{
        //    toolStripStatusLabel.Text = path;
        //    long duration = 0;

        //    if (path != _lastPath)
        //    {
        //        await ctrPlayer.LoadTrack(path);

        //        duration = ctrPlayer.Media.Duration;
        //        _lastPath = path;
        //    }

        //    duration = ctrPlayer.Media.Duration;

        //    _isInDB = Manager.Instance.IsTrackInDB(path);
        //    _guid = Manager.Instance.LastMd5Guid;
        //    _mod = ModLibrary.ModLibrary.ParseAndGuessStyle(path, DBManager.Instance.TrackStyles);
        //    _track = null;

        //    if (_isInDB && (DB.LoadTrackInfo(_guid)))
        //    {
        //        _track = DB.Track;
        //    }

        //    InitTextFields();

        //    bool newTrack = false;

        //    if (_track == null)
        //    {
        //        _track = new Track();
        //        newTrack = true;
        //    }


        //    //Setup tabs
        //    EnableTabControl();

        //    //if (_mod != null && newTrack)
        //    //{
        //    //    DisableTabDatabase();
        //    //} 
        //    //else if (!newTrack && _mod == null)
        //    //{
        //    //    DisableTabOriginal();
        //    //}

        //    SwitchTabs(true);
        //    ctrMetaData.LoadData(_mod, _track, duration);
        //}

        private void InitTextFields()
        {
            ctrMessage.Clear();
            ctrSamples.Clear();
            ctrInstruments.Clear();

            ctrSamples.TextOrg = _mod.SampleText;
            ctrInstruments.TextOrg = _mod.InstrumentText;
            ctrMessage.TextOrg = _mod.SongText;

            if (_bag.IsInDB == false)
            {
                ctrSamples.TextNew = _mod.SampleText;
                ctrInstruments.TextNew = _mod.InstrumentText;
                ctrMessage.TextNew = _mod.SongText;
            }

            if (_bag.IsInDB)
            {
                ctrSamples.TextNew = _track.SampleText;
                ctrInstruments.TextNew = _track.InstrumentText;
                ctrMessage.TextNew = _track.SongText;
            }

            ctrOutput.Init(_bag, ctrMetaData, "");
        }

   
        private async Task SaveTrack()
        {
            _track.FileName = _mod.FileName;
            _track.Md5 = Manager.Instance.GetFileGuid(_mod.FullName);
            _track.FK_fileextension_id = Manager.Instance.GetFileExtensionID(_mod.FullName);
            _track.SampleText = ctrSamples.TextNew;
            _track.InstrumentText = ctrInstruments.TextNew;
            _track.SongText = ctrMessage.TextNew;
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
            _track.YoutubeTextHeader = ctrOutput.TextHeaderNew;
            _track.YoutubeTextSummary = ctrOutput.TextSummaryNew;
            _track.YoutubeTextFooter = ctrOutput.TextFooterNew;

            _track.YoutubeText = ctrOutput.TextOutput;

            DB.AddOrUpdate(_track);
            DB.Save();

            await LoadTrack(_mod.FullName);

            ctrTracks.MarkInDatabase(_mod.FullName);
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            using (var x = new Dialogs.DoubleStringDialog())
            {
                var result = x.Show("title", "label 1", "label 2", "text a", "text b", "klik mij");


                var y = x.TextA;
                var bla = result;
            }
        }
    }
}
