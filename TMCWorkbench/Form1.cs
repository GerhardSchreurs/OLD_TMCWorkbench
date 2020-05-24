using System;
using System.Windows.Forms;
using TMCWorkbench.Events;
using ModLibrary;

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

            splitContainer1.Panel2Collapsed = false;
        }

        private async void Handle_ListViewControl_OnSelected(object sender, Events.EventArgs.FileInfoEventArgs fileinfoEventArgs)
        {
            toolStripStatusLabel.Text = fileinfoEventArgs.FileInfo.FullName;
            await musicControl1.LoadTrack(fileinfoEventArgs.FileInfo.FullName);

            var modInfo = ModLibrary.ModLibrary.Parse(fileinfoEventArgs.FileInfo.FullName);


            txtSamples.Text = modInfo.SampleText;
            txtMessage.Text = modInfo.SongText;
            txtInstruments.Text = modInfo.InstrumentText;

            txtSamples.ClearUndo();
            txtMessage.ClearUndo();
            txtInstruments.ClearUndo();

            ctrFileInfo.Filename = modInfo.FileName;
            ctrDate.Date = modInfo.DateCreated;
        }


        private void Handle_BrowserControl_OnBrowse(object sender, Events.EventArgs.DirectoryInfoEventArgs playEventArgs)
        {
            listViewControl1.BrowseDirectory(playEventArgs.DirectoryInfo);
        }
    }
}
