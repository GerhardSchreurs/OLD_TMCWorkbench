using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCDatabase.Extensions;
using TMCDatabase.Model;
using TMCWorkbench.Events;
using TMCWorkbench.Helpers;
using TMCWorkbench.Tools;
using TMCWorkbench.Utility;

namespace TMCWorkbench.Controls
{
    public partial class ControlTracks : UserControl
    {
        readonly List<string> _listTrackers = new List<string>() { "ALL", "IT", "XM", "S3M", "MOD" };
        private ViewTracksTable _table;
        private DB.DBManager _db = DB.DBManager.Instance;

        public ListView ListView
        {
            get => listView;
        }

        public ControlTracks()
        {
            InitializeComponent();

            listView.DoubleClick += Handle_ListView_DoubleClick;

            EventInvoker.OnCachedEntityRefreshed += Handle_EventInvoker_OnCachedEntityRefreshed;
        }

        private void Handle_EventInvoker_OnCachedEntityRefreshed(object sender, string entityName)
        {
            if (entityName != nameof(_db.Styles)) return;
            
            InitStylesDDL();

            Console.WriteLine("x");
        }

        private void Handle_ListView_DoubleClick(object sender, EventArgs e)
        {
            var item = listView.SelectedItems[0];
            var trackId = item.Tag.ToInt();
            var row = _table.Rows.Where(x => x.Track_id == trackId).First();
            var guid = row.Md5;
            var fileName = row.FileName;

            EventInvoker.RaiseOnTrackListViewSelected(this, trackId, guid, fileName);
        }

        public void Init()
        {
            _db.LoadStyles();
            _db.LoadComposers();
            _db.LoadSceneGroups();
            _db.LoadTags();
            _db.LoadTrackers();
            _db.LoadPlaylists();

            InitControls();

            Search();
        }

        void InitControls()
        {
            ddlFormat.DataSource = _listTrackers;

            InitStylesDDL();
            InitComposerDDL();
            InitScenegroupDDL();
            InitTagsDDL();
            InitTrackersDDL();
            InitPlaylistDDL();
            InitDateDDLs();
        }

        void InitDateDDLs()
        {
            var startDate = new DateTime(1990, 1, 1);
            var endDate = new DateTime(DateTime.Now.Year + 1, 12, 31);

            ctrDateCreated1.Init(startDate, endDate);
            ctrDateCreated2.Init(startDate, endDate);
            ctrDateSaved1.Init(startDate, endDate);
            ctrDateSaved2.Init(startDate, endDate);
        }

        void InitStylesDDL()
        {
            foreach (var entity in _db.Styles.Where(x => x.IsAlt == false))
            {
                var item = new CCBoxItem(entity.Name, entity.Style_id);
                ddlStyles.Items.Add(item);
            }
        }

        void InitPlaylistDDL()
        {
            foreach (var entity in _db.Playlists)
            {
                var item = new CCBoxItem(entity.Name, entity.Playlist_id);
                ddlPlaylist.Items.Add(item);
            }

            ddlPlaylist.Items.Insert(0, new CCBoxItem("", 0));
        }

        void InitComposerDDL()
        {
            foreach(var entity in _db.Composers)
            {
                var item = new CCBoxItem(entity.Name, entity.Composer_id);
                ddlComposer.Items.Add(item);
            }

            ddlComposer.Items.Insert(0, new CCBoxItem("", 0));
        }

        void InitScenegroupDDL()
        {
            foreach (var entity in _db.SceneGroups)
            {
                var item = new CCBoxItem(entity.Name, entity.Scenegroup_id);
                ddlScenegroup.Items.Add(item);
            }

            ddlScenegroup.Items.Insert(0, new CCBoxItem("", 0));
        }

        void InitTagsDDL()
        {
            foreach (var entity in _db.Tags)
            {
                var item = new CCBoxItem(entity.Name, entity.Tag_id);
                ddlTags.Items.Add(item);
            }
        }

        void InitTrackersDDL()
        {
            foreach (var entity in _db.Trackers)
            {
                var item = new CCBoxItem(entity.Name, entity.Tracker_id);
                ddlTrackers.Items.Add(item);
            }
        }

        int GetBoxValue(ComboBox box)
        {
            if (box == null || box.SelectedItem == null) return 0;
            return ((CCBoxItem)box.SelectedItem).Value;
        }

        public bool IsFirstSearch = true;

        public void Search(bool forceRefresh = false)
        {
            var builder = new SearchQueryExecutor();

            builder.SearchFileName(ctrFileName.Text);
            builder.SearchTrackTitle(ctrTrackTitle.Text);
            builder.SearchMetaData(ctrMetaData.Text);
            builder.SearchFormat(ddlFormat.SelectedIndex);
            builder.SearchStyles(ddlStyles.GetCheckedItemIds());

            if (ddlComposer.SelectedIndex == -1 && ddlComposer.Text.IsNotNullOrEmpty())
                builder.SearchComposerByName(ddlComposer.Text);
            else
                builder.SearchComposerById(GetBoxValue(ddlComposer));

            if (ddlScenegroup.SelectedIndex == -1 && ddlScenegroup.Text.IsNotNullOrEmpty())
                builder.SearchScenegroupByName(ddlScenegroup.Text);
            else
                builder.SearchScenegroupById(GetBoxValue(ddlScenegroup));

            builder.SearchTags(ddlTags.GetCheckedItemIds());

            builder.SearchTrackers(ddlTrackers.GetCheckedItemIds());

            builder.SearchDateTrackCreated(ctrDateCreated1.DateSelectedLow, ctrDateCreated2.DateSelectedHigh);
            builder.SearchDateDatabaseStored(ctrDateSaved1.DateSelectedLow, ctrDateSaved2.DateSelectedHigh);
            builder.SearchScore(ctrScore.Result, ctrScore.Modifier);



            //Retrieve data


            var data = builder.ExecuteAndRetrieve();
            _table = new ViewTracksTable(data);

            if (forceRefresh == false && listView.Items.Count > 0 && _table.Rows.Count > 0)
            {
                int listViewID = Converter.ToInt32(listView.Items[0].Tag);
                int dataID = _table.Rows[0].Track_id;

                if (listViewID == dataID) return; //No need to update
            }

            listView.Items.Clear();

            for (var i = 0; i < _table.Rows.Count; i++)
            {
                GenerateRow(i);
            }

            if (IsFirstSearch == false)
                EventInvoker.RaiseOnSearchDone(this, builder.ExecutionTimeMS);

            IsFirstSearch = false;
        }

        void GenerateRow(int index)
        {
            var row = _table.Rows[index];

            //colID
            var item = new ListViewItem();
            item.UseItemStyleForSubItems = false;
            item.Tag = row.Track_id;
            item.Text = row.Track_id.ToString("D5");

            ListViewItem.ListViewSubItem sub;

            //colType
            sub = new ListViewItem.ListViewSubItem();
            sub.Text = GeneralHelper.GetExtensionNameFromInt(row.FK_filextension_id);
            sub.ForeColor = GeneralHelper.GetColorForExtension(row.FK_filextension_id);
            //FK_filextension_id
            //sub.ForeColor = GetColorForExtension(extension);
            item.SubItems.Add(sub);

            //colFileName
            sub = new ListViewItem.ListViewSubItem();
            sub.Text = row.FileName;
            item.SubItems.Add(sub);

            //colName
            sub = new ListViewItem.ListViewSubItem();
            sub.Text = row.TrackTitle;
            item.SubItems.Add(sub);

            //colStyle
            sub = new ListViewItem.ListViewSubItem();
            sub.Text = row.Style ?? row.StyleName;
            item.SubItems.Add(sub);

            //colDateSave
            sub = new ListViewItem.ListViewSubItem();
            sub.Text = row.Date_created.ToShortDateString();
            item.SubItems.Add(sub);

            listView.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void Handle_btnSearch_Click(object sender, EventArgs e)
        {
            Search(true);
        }
    }
}
