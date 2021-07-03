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

            InitControls();
            Search();
        }

        void InitControls()
        {
            ddlFormat.DataSource = _listTrackers;

            InitStylesDDL();
            InitComposerDLL();
        }

        void InitComposerDLL()
        {
            foreach(var composer in _db.Composers)
            {
                var item = new CCBoxItem(composer.Name, composer.Composer_id);
                ddlComposer.Items.Add(item);
            }

            ddlComposer.Items.Insert(0, new CCBoxItem("", 0));
        }

        void InitStylesDDL()
        {
            foreach(var style in _db.Styles.Where(x => x.IsAlt == false))
            {
                var item = new CCBoxItem(style.Name, style.Style_id);
                ddlStyles.Items.Add(item);
            }
        }

        int GetBoxValue(ComboBox box)
        {
            if (box == null || box.SelectedItem == null) return 0;
            return ((CCBoxItem)box.SelectedItem).Value;
        }


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
