using TMCWorkbench;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TMCWorkbench.Events;
using TMCWorkbench.Enums;
using System.Security.Cryptography;
using TMCWorkbench.DB;
using TMCDatabase.DBModel;
using TMCWorkbench.Helpers;

namespace TMCWorkbench.Controls
{
    public partial class ControlListView : UserControl
    {
        public ControlListView()
        {
            InitializeComponent();

            listView1.KeyUp += Handle_ListView1_KeyUp;
            listView1.DoubleClick += Handle_ListView1_DoubleClick;
        }

        public void Init()
        {
            //Does nothing atm.
        }

        public void MarkInDatabase(string fullName, Guid guid)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Name == fullName)
                {
                    item.Text = "Y";
                    item.Tag = new ListViewItemTag()
                    {
                        IsInDB = true,
                        Path = fullName,
                        Guid = guid
                    };
                }
            }
        }

        public void BrowseDirectory(DirectoryInfo directoryInfo)
        {
            try
            {
                listView1.Items.Clear();

                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                {
                    var extensionString = GeneralHelper.GetStringExtensionFromFileInfo(fileInfo);

                    if (GeneralHelper.IsSupportedFile(extensionString) == false) continue;
                    var extension = GeneralHelper.GetExtensionFromString(extensionString);
                    if (GeneralHelper.IsSupportedFile(extension) == false) continue; //Unnecessary

                    var isInDb = Manager.Instance.IsTrackInDB(fileInfo);
                    var guid = Manager.Instance.LastMdSuccess ? Manager.Instance.LastMd5Guid : Guid.Empty;

                    var tag = new ListViewItemTag()
                    {
                        IsInDB = isInDb,
                        Path = fileInfo.FullName,
                        Guid = guid
                    };

                    ListViewItem.ListViewSubItem sub;

                    var item = new ListViewItem();
                    item.Name = tag.Path;
                    item.UseItemStyleForSubItems = false;
                    item.Tag = tag;
                    item.Text = isInDb ? "Y" : "N";

                    //Type
                    sub = new ListViewItem.ListViewSubItem();
                    sub.Text = extensionString;
                    sub.ForeColor = GeneralHelper.GetColorForExtension(extension);
                    item.SubItems.Add(sub);

                    //Type
                    //var item = new ListViewItem();
                    //item.UseItemStyleForSubItems = false;
                    //item.Tag = fileInfo;
                    //item.Text = extensionString;
                    //item.ForeColor = GetColorForExtension(extension);

                    //Name
                    sub = new ListViewItem.ListViewSubItem();
                    sub.Text = fileInfo.Name;
                    item.SubItems.Add(sub);

                    //Created
                    sub = new ListViewItem.ListViewSubItem();
                    sub.Text = File.GetLastWriteTime(fileInfo.FullName).ToShortDateString();
                    item.SubItems.Add(sub);

                    //Modified
                    sub = new ListViewItem.ListViewSubItem();
                    sub.Text = File.GetLastAccessTime(fileInfo.FullName).ToShortDateString();
                    item.SubItems.Add(sub);

                    listView1.Items.Add(item);
                }

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                if (ex is System.NullReferenceException || ex is System.UnauthorizedAccessException)
                {
                    // Do Nothing.
                }

            }
        }

        private void Handle_ListView1_DoubleClick(object sender, EventArgs e)
        {
            PlaySelectedItemTrack();
        }

        private void Handle_ListView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PlaySelectedItemTrack();
            }
        }

        void PlaySelectedItemTrack()
        {
            var item = listView1.SelectedItems[0];
            var tag = item.Tag as ListViewItemTag;

            EventInvoker.RaiseOnBrowserListViewSelected(this, tag.Path, tag.IsInDB, tag.Guid);
        }
    }
}
