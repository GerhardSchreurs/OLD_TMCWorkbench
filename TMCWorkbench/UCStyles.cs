using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCDatabase;
using TMCDatabase.DBModel;
using TMCWorkbench.Dialogs;
//using TMCWorkbench.Dialogs;
using TMCWorkbench.Tools;


namespace TMCWorkbench
{
    public partial class UCStyles : _UCForm
    {
        private TMCWorkbench.DB.DBManager DB = TMCWorkbench.DB.DBManager.Instance;

        private ContextMenu _contextMenuNodeOptions = new ContextMenu();

        private MenuItem _menuItemAdd = new MenuItem("Add");
        private MenuItem _menuItemEdit = new MenuItem("Edit");
        private MenuItem _menuItemDelete = new MenuItem("Delete");
        private Style _row;
        private bool _isDirty;

        List<Style> Styles;

        public UCStyles()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _contextMenuNodeOptions.MenuItems.Add(_menuItemAdd);
            _contextMenuNodeOptions.MenuItems.Add(_menuItemEdit);
            _contextMenuNodeOptions.MenuItems.Add(_menuItemDelete);

            _menuItemAdd.Click += Handle_menuItemAdd_Click;
            _menuItemEdit.Click += Handle_menuItemEdit_Click;
            _menuItemDelete.Click += Handle_menuItemDelete_Click;

            Styles = DB.C.Styles.ToList();
            PopulateTree();

            this.treeView.NodeMouseClick += Handle_TreeView_NodeMouseClick;

            StylesDialog.OnUpdated += Handle_StylesDialog_OnUpdated;
        }

        private void Handle_StylesDialog_OnUpdated(object sender, EventArgs e)
        {
            UpdateTreeView();
        }

        private List<Style> _expanded;

        void UpdateTreeView()
        {
            _expanded = new List<Style>();

            if (_row != null)
            {
                var row = _row;

                //Get parent rows
                while (row.Parent_style_id != null)
                {
                    row = Styles.Where(x => x.Style_id == row.Parent_style_id).First();
                    _expanded.Add(row);
                }

                _expanded.Add(_row);
            }

            Styles = DB.C.Styles.ToList();
            PopulateTree();
            _isDirty = true;
        }

        bool IsInExpanded(Style row)
        {
            if (_expanded == null) { return false; };
            return _expanded.Contains(row);
        }

        private void Handle_menuItemAdd_Click(object sender, EventArgs e)
        {   
            using (var dialog = new Dialogs.StylesDialog(_row, isEdit: false))
            {
                dialog.ShowDialog();
            }
        }

        private void Handle_menuItemDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Some Title", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //do something
                DB.Remove(_row);
                DB.Save();
                UpdateTreeView();
            }
        }

        private void Handle_menuItemEdit_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialogs.StylesDialog(_row, isEdit: true))
            {
                dialog.ShowDialog();
            }
        }

        private bool HasRowChildRows()
        {
            return Styles.Where(x => x.Parent_style_id == _row.Style_id).Any();
        }

        private void Handle_TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return;  }

            _menuItemAdd.Enabled = true;
            _menuItemDelete.Enabled = true;
            _menuItemEdit.Enabled = true;

            var sourceNode = ((TreeView)sender).GetNodeAt(new Point(e.X, e.Y));
            var tag = Converter.ToInt32(sourceNode.Tag);

            if (tag == -1) 
            {
                _row = null;
                _menuItemEdit.Enabled = false;
                _menuItemDelete.Enabled = false;
            }
            else
            {
                _row = Styles.Where(x => x.Style_id == tag).First();

                if (HasRowChildRows())
                {
                    _menuItemDelete.Enabled = false;
                }
            }

            _contextMenuNodeOptions.Show(treeView, e.Location);
        }

        private void PopulateTree()
        {
            this.treeView.Nodes.Clear();

            var rootNode = new TreeNode();
            rootNode.Tag = -1;
            rootNode.Text = "ROOT";
            this.treeView.Nodes.Add(rootNode);

            foreach (var row in Styles.Where(x => x.Parent_style_id == null))
            {
                var node = new TreeNode();
                node.Text = $"[{row.Weight}] {row.Name}";
                node.Tag = row.Style_id;
                //treeRoot.ExpandAll();
                rootNode.Nodes.Add(node);

                foreach (TreeNode childNode in GetChildNodes(row))
                {
                    node.Nodes.Add(childNode);
                }

                if (IsInExpanded(row))
                {
                    node.Expand();
                }
            }

            rootNode.Expand();
        }

        private List<TreeNode> GetChildNodes(Style parentRow)
        {
            int parentID = parentRow.Style_id;
            var nodes = new List<TreeNode>();

            var rows = Styles.Where(x => x.Parent_style_id != null && x.Parent_style_id == parentID);

            foreach (var row in rows)
            {
                var childNode = new TreeNode();
                childNode.Text = $"[{row.Weight}] {row.Name}";
                childNode.Tag = row.Style_id;

                if (row.IsAlt)
                {
                    childNode.ForeColor = Color.Green;
                }


                if (IsInExpanded(row))
                {
                    childNode.Expand();
                }

                foreach (TreeNode node in GetChildNodes(row))
                {
                    childNode.Nodes.Add(node);
                }

                nodes.Add(childNode);
            }

            return nodes;
        }

        private void Handle_btnSave_Click(object sender, EventArgs e)
        {
            //###
            //_data.UpdateData();
        }
    }
}
