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
using System.Threading.Tasks;
using TMCWorkbench.Model;
using System.IO;
using TMCWorkbench.Controls;

namespace TMCWorkbench
{
    public partial class FormAlpha : Form
    {
        public DBManager DB = DBManager.Instance;
        private Bag _bag;
        private ModInfo _mod;
        private Track _track;
        private string _lastPath;
        private string _statusText;
        private bool _statusHasError;

        public FormAlpha()
        {
            InitializeComponent();

            PositionForm();

            EventInvoker.OnBrowserControlBrowse += Handle_ctrBrowser_OnBrowse;
            EventInvoker.OnListViewBrowserControlSelected += Handle_ctrListView_OnSelected;
            EventInvoker.OnListViewTrackControlSelected += Handle_ctrTrack_OnListViewTrackControlSelected;

            ctrBrowser.Init();
            ctrListView.Init();
            ctrPlayer.Init();
            ctrMetaData.Init();
            ctrTracks.Init();

            //TODO
            ctrTracks.ListView.MouseMove += Handle_ListView_MouseMove;

            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += Handle_TabControl_DrawItem;
        }

        private void Handle_ListView_MouseMove(object sender, MouseEventArgs e)
        {
            //https://stackoverflow.com/questions/1045621/getting-the-item-under-mouse-cursor-in-a-listview-control
            //TODO
            Console.WriteLine($"{e.X} {e.Y}");
        }

        private readonly string[] CMD_KEY_CONTROLS = new string[] { "tabControl", "ctrBrowser", "ctrPlayer", "ctrListView", "ctrTracks" };

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                if ((CMD_KEY_CONTROLS.Contains(this.ActiveControl.Name)) == false) 
                    return base.ProcessCmdKey(ref msg, keyData);

                ctrPlayer.PauseOrPlay();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(C.PATHTRACKCACHE);
            Directory.CreateDirectory(C.PATHTRACKSTORE);

            SetStatusText("Loading");
            DB.LoadTrackstyles();
            SetStatusText("Done loading");
        }

        private void AppendStatusText(string text, bool isError = false, bool restart = false)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                if (restart)
                {
                    toolStripStatusLabel.Text = text;
                    toolStripStatusLabel.ForeColor = Color.Black;
                    return;
                }

                toolStripStatusLabel.Text += $" | {text}";
                
                if (isError)
                {
                    toolStripStatusLabel.ForeColor = Color.Red;
                }
            }));
        }

        void UpdateStatusText()
        {
            SetStatusText(_statusText, _statusHasError);
            _statusHasError = false;
            _statusText = "";
        }

        void SetStatusText(string status, bool asError = false)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                if (asError)
                    toolStripStatusLabel.ForeColor = Color.Red;

                toolStripStatusLabel.ForeColor = Color.Black;
                toolStripStatusLabel.Text = status;
            }));
        }
         
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            PositionFormSave();

            //TODO Dispose player
            try
            {
                ctrPlayer.StopWait();
                ctrPlayer.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Can't stop player: {ex}");
            }

            try
            {
                //Clear cache
                Directory.Delete(C.PATHTRACKCACHE, true);
                Directory.CreateDirectory(C.PATHTRACKCACHE);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Can't reset cache dir: {ex}");
            }
        }

        #region EVENT_CONTROLS
        private void Handle_ctrBrowser_OnBrowse(object sender, Events.EventArgs.DirectoryInfoEventArgs playEventArgs)
        {
            ctrListView.BrowseDirectory(playEventArgs.DirectoryInfo);
        }

        private async void Handle_ctrListView_OnSelected(object sender, string fileName, bool isInDB, Guid guid)
        {
            //await LoadTrackFromDisk(fullName);
            await LoadTrack(fileName, isInDB, guid);
        }

        private async void Handle_ctrTrack_OnListViewTrackControlSelected(object sender, int trackId, Guid guid, string fileName)
        {
            var file = $@"{C.PATHTRACKSTORE}\{guid}_{fileName}";
            //await LoadTrackFromDatabase(file, trackId, guid);
            await LoadTrack(file, true, guid);
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

        private void Handle_tagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new UCTags())
            {
                form.ShowDialog();
            }
        }

        private void Handle_playlistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new UCPlayLists())
            {
                form.ShowDialog();
            }
        }
        #endregion

        private async Task LoadTrack(string path, bool fromDB, Guid guid, bool autoPlay = true)
        {
            if (path == _lastPath) return;

            ctrPlayer.StopWait();

            var fileExists = File.Exists(path);
            var loadingText = $"Loading: {path}";

            if (fromDB)
                loadingText += $" -- {guid}";

            if (fileExists)
                PlayerShow();
            else
                PlayerHide();

            SetStatusText(loadingText, !fileExists);

            _bag = new Bag();

            var status = await _bag.Load(path, fileExists, guid, fromDB);

            if (status.IsNotNullOrEmpty())
            {
                //Something serious happened
                MessageBox.Show(status);
                return;
            }

            if (fileExists)
            {
                await ctrPlayer.ProcessAndPlay(path, autoPlay);
                _bag.Duration = ctrPlayer.Duration;
                _lastPath = path;
            }

            //For easy reference
            _mod = _bag.Mod;
            _track = _bag.Track;

            ctrMetaData.LoadData(_bag);
            InitTextFields();

            EnableTabControl();
            SwitchTabs(true);

            SetStatusText($"Loaded: {path}");
        }

        private bool PlayerIsHidden()
        {
            return tableRightControls.RowStyles[2].Height == 0;
        }

        private bool PlayerIsShowing()
        {
            return tableRightControls.RowStyles[2].Height == 80;
        }

        private void PlayerHide()
        {
            if (PlayerIsShowing())
                tableRightControls.Do(() => tableRightControls.RowStyles[2].Height = 0);
        }

        private void PlayerShow()
        {
            if (PlayerIsHidden())
                tableRightControls.Do(() => tableRightControls.RowStyles[2].Height = 80);
        }


        //private async Task LoadTrackFromDatabase(string path, int trackId, Guid guid)
        //{
        //    SetStatusText($"Loading: {path}");
        //    ctrPlayer.StopWait();
        //    tableRightControls.Do(() => tableRightControls.RowStyles[2].Height = 0);

        //    _bag = new Bag();
        //    await _bag.LoadFromDatabase(guid, true);

        //    _mod = null;
        //    LoadTrackInner(path);
        //}

        //private async Task LoadTrackFromDisk(string path)
        //{
        //    SetStatusText($"Loading: {path}");
        //    tableRightControls.Do(() => tableRightControls.RowStyles[2].Height = 80);

        //    long duration = 0;

        //    if (path != _lastPath)
        //    {
        //        Debug.WriteLine($"Firing up {path}");

        //        //await ctrPlayer.LoadTrack(path);
        //        await ctrPlayer.ProcessAndPlay(path);

        //        duration = ctrPlayer.Duration;
        //        _lastPath = path;
        //    }

        //    _bag = new Bag();

        //    await _bag.LoadFromDisk(path, duration, true);
        //    //For easy reference
        //    _mod = _bag.Mod;

        //    LoadTrackInner(path);
        //}

        //void LoadTrackInner(string path)
        //{
        //    _track = _bag.Track;

        //    ctrMetaData.LoadData(_bag);
        //    InitTextFields();

        //    EnableTabControl();
        //    SwitchTabs(true);

        //    SetStatusText($"Loaded: {path}");
        //}

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

            if (_mod != null)
            {
                ctrSamples.TextOrg = _mod.SampleText;
                ctrInstruments.TextOrg = _mod.InstrumentText;
                ctrMessage.TextOrg = _mod.SongText;

                if (_bag.IsInDB == false)
                {
                    ctrSamples.TextNew = _mod.SampleText;
                    ctrInstruments.TextNew = _mod.InstrumentText;
                    ctrMessage.TextNew = _mod.SongText;
                }
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
            var status = "Updated:";

            if (_bag.IsInDB == false)
            {
                status = "Saved:";

                _track.FileName = _mod.FileName;
                _track.Md5 = Manager.Instance.GetFileGuid(_mod.FullName);
                _track.FK_fileextension_id = Manager.Instance.GetFileExtensionID(_mod.FullName);
                _track.Date_track_created = ctrMetaData.Date;
                _track.Date_track_modified = _mod.DateModified;
            }

            _track.SampleText = ctrSamples.TextNew;
            _track.InstrumentText = ctrInstruments.TextNew;
            _track.SongText = ctrMessage.TextNew;
            _track.Is_favorite = ctrMetaData.IsFavorite;
            _track.TrackTitle = ctrMetaData.TrackTitle;
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

            //Tags
            DB.UpdateTrackTags(_track.Track_id, ctrMetaData.GetTagIds());
            DB.UpdateTrackPlaylists(_track.Track_id, ctrMetaData.GetPlaylistIds());

            DB.AddOrUpdate(_track);
            DB.Save();

            AppendStatusText($"{status} {_track.FileName} in database", false, true);

            if (_mod != null && _bag.IsInDB == false)
            {
                var pathSource = _mod.FileInfo.FullName;
                var pathTarget = $@"{C.PATHTRACKSTORE}\{_track.Md5.ToUpr()}_{_mod.FileName}";

                if (File.Exists(pathTarget) == false)
                {
                    try
                    {
                        File.Copy(pathSource, pathTarget, true);
                        AppendStatusText($"Copied {pathSource} to {pathTarget}");
                    }
                    catch (Exception sex)
                    {
                        MessageBox.Show($"Succesfully? saved file, but couldn't copy from {pathSource} to {pathTarget}\n{sex}");
                    }
                }
            }

            if (_mod == null)
            {
                AppendStatusText("NOT ON DISK", true);
            }
            else
            {
                await LoadTrack(_mod.FullName, true, _track.Md5);
                ctrListView.MarkInDatabase(_mod.FullName, _track.Md5);
                ctrTracks.Search();
            }


            //ctrMetaData.Refresh(true);
            //await LoadTrackFromDisk(_mod.FullName);

            AppendStatusText("DONE");
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

        private async void Handle_massInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ctrListView.ListView.Items)
            {
                var tag = (ListViewItemTag)item.Tag;

                if (tag.IsInDB) continue;

                await LoadTrack(tag.Path, false, tag.Guid, false);
                await Task.Delay(100);
                await SaveTrack();
                await Task.Delay(100);
            }

        }
    }
}
