using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TMCWorkbench;
using TMCWorkbench.Events;

namespace TMCWorkbench.Controls
{
    public partial class ControlBrowser : UserControl
    {
        ContextMenu _contextMenuNodeOptions = new ContextMenu();

        MenuItem _menuItemRefresh = new MenuItem("Refresh");
        MenuItem _menuItemClear = new MenuItem("Clear");
        MenuItem _menuItemSet = new MenuItem("Set as parent");

        DirectoryInfo _targetDirecoryInfo;

        bool IsPathASubDirectory = true;

        public ControlBrowser()
        {
            InitializeComponent();

            _contextMenuNodeOptions.MenuItems.Add(_menuItemRefresh);
            _contextMenuNodeOptions.MenuItems.Add(_menuItemClear);
            _contextMenuNodeOptions.MenuItems.Add(_menuItemSet);

            _menuItemRefresh.Click += Handle_menuItemRefresh_Click;
            _menuItemClear.Click += Handle_menuItemClear_Click;
            _menuItemSet.Click += Handle_menuItemSet_Click;
        }

        public void Init()
        {
            PopulateTreeView();
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
        }

        private void Handle_menuItemRefresh_Click(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        private void Handle_menuItemSet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PathFolderBase = _targetDirecoryInfo.FullName;
            Properties.Settings.Default.Save();

            PopulateTreeView();
        }

        private void Handle_menuItemClear_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PathFolderBase = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3);
            Properties.Settings.Default.Save();

            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            var path = Properties.Settings.Default.PathFolderBase;

            if (path.IsNullOrEmpty())
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3);
            }

            if (path.ToUpper() == Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3).ToUpper())
            {
                IsPathASubDirectory = false;
            }
            else
            {
                IsPathASubDirectory = true;
            }

            var directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
            {
                MessageBox.Show($"{path} not found");
                return;
            }

            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes.Clear();
            }

            var rootNode = new TreeNode(directoryInfo.Name);
            rootNode.Tag = directoryInfo;
            GetDirectories(directoryInfo.GetDirectories(), rootNode, IsPathASubDirectory);
            treeView1.Nodes.Add(rootNode);

            EventInvoker.RaiseOnBrowse(this, directoryInfo);
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo, bool parseFully)
        {
            foreach (DirectoryInfo subDir in subDirs)
            {
                if (subDir.Name.StartsWith("$"))
                {
                    continue;
                }
                try
                {
                    subDir.GetDirectories();
                    subDir.GetFiles();
                }
                catch (UnauthorizedAccessException ex)
                {
                    // do something and return
                    continue;
                }

                var node = new TreeNode(subDir.Name, 0, 0);
                node.Tag = subDir;
                node.ImageKey = "folder";
                nodeToAddTo.Nodes.Add(node);

                if (parseFully == false)
                {
                    continue;
                }

                DirectoryInfo[] subSubDirs;

                try
                {
                    subSubDirs = subDir.GetDirectories();
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories(subSubDirs, node, true);
                    }
                }
                catch (System.UnauthorizedAccessException)
                {
                    subSubDirs = new DirectoryInfo[0];
                }
            }
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var sourceNode = ((TreeView)sender).GetNodeAt(new Point(e.X, e.Y));
                _targetDirecoryInfo = ((DirectoryInfo)sourceNode.Tag);
                _contextMenuNodeOptions.Show(treeView1, e.Location);

                return;
            }

            try
            {
                var info = (DirectoryInfo)e.Node.Tag;

                EventInvoker.RaiseOnBrowse(this, info);

                if (e.Node.Nodes.Count > 0)
                {
                    /*Do Nothing.*/
                    Console.WriteLine("Doing Nothing");
                }
                else
                {
                    GetDirectories(info.GetDirectories(), e.Node, IsPathASubDirectory); e.Node.Expand();
                }
            }
            catch (Exception ex)
            {

                if (ex is System.NullReferenceException || ex is System.UnauthorizedAccessException)
                {
                    // Do Nothing.
                }
            }
        }
    }
}
