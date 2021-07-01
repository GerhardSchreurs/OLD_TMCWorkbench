using System;
using System.Collections.Generic;
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
        public ListView ListView
        {
            get => listView;
        }

        public ControlTracks()
        {
            InitializeComponent();

            listView.KeyUp += Handle_ListView_KeyUp;
            listView.DoubleClick += Handle_ListView_DoubleClick;
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

        private void Handle_ListView_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private ViewTracksTable _table;

        public void Init()
        {
            Search();
        }

        public void Search()
        {
            var builder = new SearchQueryExecutor();

            if (ctrFileName.Text.IsNotNullOrEmpty())
                builder.SearchFileName(ctrFileName.Text);
            if (ctrTrackTitle.Text.IsNotNullOrEmpty())
                builder.SearchTrackTitle(ctrTrackTitle.Text);
            if (ctrMetaData.Text.IsNotNullOrEmpty())
                builder.SearchMetaData(ctrMetaData.Text);

            var data = builder.ExecuteAndRetrieve();
            _table = new ViewTracksTable(data);

            if (listView.Items.Count > 0 && _table.Rows.Count > 0)
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
            Search();
        }
    }
}
