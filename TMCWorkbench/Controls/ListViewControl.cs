using Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TMCWorkbench.Events;
using TMCWorkbench.Enums;
using System.Security.Cryptography;
using TMCWorkbench.DB;
using TMCDatabase.Model;

namespace TMCWorkbench.Controls
{
    public partial class ListViewControl : UserControl
    {
        public ListViewControl()
        {
            InitializeComponent();

            listView1.KeyUp += Handle_ListView1_KeyUp;
            listView1.DoubleClick += Handle_ListView1_DoubleClick;
        }

        public void Init()
        {
            //Does nothing atm.
        }

        protected string GetMD5HashFromFile(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }

        private Guid GetGuid(MD5 md5, FileInfo fileInfo)
        {
            Guid id;

            using (var stream = File.OpenRead(fileInfo.FullName))
            {
                var hash = md5.ComputeHash(stream);
                id = new Guid(hash);
                Console.WriteLine(BitConverter.ToString(hash));
            }

            return id;
        }

        private bool IsInDB(MD5 md5, FileInfo fileInfo)
        {
            //var hash = string.Empty;

            //using (var stream = File.OpenRead(fileInfo.FullName))
            //{
            //    hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);

            //    Console.WriteLine(hash);
            //}

            //return true;

            return DBManager.Instance.IsTrackInDB(GetGuid(md5, fileInfo));
            //check if in DB


        }


        public void BrowseDirectory(DirectoryInfo directoryInfo)
        {
            try
            {
                listView1.Items.Clear();
                var i = 0;
                
                using (var md5 = MD5.Create())
                {
                    foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                    {
                        var extensionString = GetStringExtensionFromFileInfo(fileInfo);
                        var extension = GetExtensionFromString(extensionString);


                        if (IsSupportedFile(extension))
                        {
                            var isInDb = IsInDB(md5, fileInfo);

                            ListViewItem.ListViewSubItem sub;

                            var item = new ListViewItem();
                            item.UseItemStyleForSubItems = false;
                            item.Tag = fileInfo;
                            item.Text = isInDb ? "Y" : "N";

                            //Type
                            sub = new ListViewItem.ListViewSubItem();
                            sub.Text = extensionString;
                            sub.ForeColor = GetColorForExtension(extension);
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
                    }
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
            var info = (FileInfo)item.Tag;

            EventInvoker.RaiseOnListViewSelected(this, info);
        }

        string GetStringExtensionFromFileInfo(FileInfo info)
        {
            var ext = Path.GetExtension(info.FullName);

            if (ext.IsNotNullOrEmpty() && ext.Length > 1 && ext.Length <= 4)
            {
                return ext.Substring(1).ToUpper();
            }

            return string.Empty;
        }

        Extension GetExtensionFromString(string extension)
        {
            return (Extension)Enum.Parse(typeof(Extension), extension);
        }

        bool IsSupportedFile(Extension extension)
        {
            return Enum.IsDefined(typeof(Extension), extension);
        }

        int GetSupportedFileIcon(string extension)
        {
            return (int)((Extension)Enum.Parse(typeof(Extension), extension));
        }

        Color GetColorForExtension(Extension extension)
        {
            if (extension == Extension.IT)
                return ColorTranslator.FromHtml("#00b2d8");
            else if (extension == Extension.XM)
                return ColorTranslator.FromHtml("#36cb3a");
            else if (extension == Extension.S3M)
                return ColorTranslator.FromHtml("#8400ea");
            else if (extension == Extension.MOD)
                return ColorTranslator.FromHtml("#cd0000");
            else
                return Color.Gray;
        }
    }
}
