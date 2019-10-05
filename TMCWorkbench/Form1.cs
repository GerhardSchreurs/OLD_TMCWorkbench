using System;
using System.Windows.Forms;
using TMCWorkbench.Events;

namespace TMCWorkbench
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            EventInvoker.OnBrowserControlBrowse += Handle_BrowserControl_OnBrowse;
            EventInvoker.OnListViewControlSelected += Handle_ListViewControl_OnSelected;

            browserControl1.Init();
            listViewControl1.Init();
            musicControl1.Init();

        }

        private void Handle_ListViewControl_OnSelected(object sender, Events.EventArgs.FileInfoEventArgs fileinfoEventArgs)
        {
            toolStripStatusLabel.Text = fileinfoEventArgs.FileInfo.FullName;
            musicControl1.LoadTrack(fileinfoEventArgs.FileInfo.FullName);
        }

        private void Handle_BrowserControl_OnBrowse(object sender, Events.EventArgs.DirectoryInfoEventArgs playEventArgs)
        {
            listViewControl1.BrowseDirectory(playEventArgs.DirectoryInfo);
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
