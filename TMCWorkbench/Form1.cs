using Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TMCWorkbench.Events;
using TMCWorkbench.Events.EventArgs;
using TMCWorkbench.Model.Enums;

namespace TMCWorkbench
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            EventInvoker.OnBrowse += Handle_EventInvoker_OnBrowse;

            browserControl1.Init();
            musicControl1.Init();

            listView1.KeyUp += Handle_ListView1_KeyUp;
            listView1.DoubleClick += Handle_ListView1_DoubleClick;
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

            toolStripStatusLabel.Text = info.FullName;

            musicControl1.LoadTrack(info.FullName);
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

        private void Handle_EventInvoker_OnBrowse(object sender, BrowseEventArgs playEventArgs)
        {
            //MessageBox.Show(playEventArgs.DirectoryInfo.FullName);

            try
            {
                var info = playEventArgs.DirectoryInfo;

                //TreeNode newSelected = e.Node;
                listView1.Items.Clear();

                //foreach (DirectoryInfo dir in info.GetDirectories())
                //{
                //    item = new ListViewItem(dir.Name, 0);
                //    subItems = new ListViewItem.ListViewSubItem[]
                //    {
                //        new ListViewItem.ListViewSubItem(item, "Directory"), new ListViewItem.ListViewSubItem(item,  dir.LastAccessTime.ToShortDateString())
                //    };
                //    item.SubItems.AddRange(subItems);
                //    listView1.Items.Add(item);
                //}

                foreach (FileInfo fileInfo in info.GetFiles())
                {
                    var extensionString = GetStringExtensionFromFileInfo(fileInfo);
                    var extension = GetExtensionFromString(extensionString);

                    //if (IsSupportedFile(extension))
                    //{
                    //    item = new ListViewItem(file.Name);
                    //    item.Tag = file;

                    //    var x = new ListViewItem("la");
                    //    x.Text = "bla";


                    //    subItems = new ListViewItem.ListViewSubItem[]
                    //    {
                    //        new ListViewItem.ListViewSubItem(item, extension),
                    //        new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString())
                    //    };

                    //    //item.SubItems.AddRange(subItems);
                    //    listView1.Items.Add(item);
                    //}

                    if (IsSupportedFile(extension))
                    {
                        ListViewItem.ListViewSubItem sub;

                        //Type
                        var item = new ListViewItem();
                        item.UseItemStyleForSubItems = false;
                        item.Tag = fileInfo;
                        item.Text = extensionString;
                        item.ForeColor = GetColorForExtension(extension);

                        //Name
                        sub = new ListViewItem.ListViewSubItem();
                        sub.Text = fileInfo.Name;
                        item.SubItems.Add(sub);

                        //Created
                        sub = new ListViewItem.ListViewSubItem();
                        sub.Text = File.GetCreationTime(info.FullName).ToShortDateString();
                        item.SubItems.Add(sub);

                        //Modified
                        sub = new ListViewItem.ListViewSubItem();
                        sub.Text = File.GetLastWriteTime(info.FullName).ToShortDateString();
                        item.SubItems.Add(sub);

                        listView1.Items.Add(item);


                        //var x = new ListViewItem.ListViewSubItem();
                        //x.Text = "hallo";
                        //x.BackColor = Color.Red;

                        //listViewItem.SubItems.Add(x);
                        //listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem().Text = "deze");
                        //listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem().Text = "wereld");

                        //listView1.Items.Add(listViewItem);


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

  

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "choose track";
            var result = dialog.ShowDialog();

            musicControl1.LoadTrack(dialog.FileName);
        }
    }
}
