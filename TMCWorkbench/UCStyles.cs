using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TMCWorkbench.Dialogs;
using TMCWorkbench.Database;
using TMCWorkbench.Model;
using TMCWorkbench.Tools;

namespace TMCWorkbench
{
    public partial class UCStyles : UCForm
    {
        ContextMenu _contextMenuNodeOptions = new ContextMenu();

        MenuItem _menuItemAdd = new MenuItem("Add");
        MenuItem _menuItemEdit = new MenuItem("Edit");
        MenuItem _menuItemDelete = new MenuItem("Delete");

        TableStyles _data = DB.Instance().TableStyles;

        //tmcDataSetTableAdapters.stylesTableAdapter _adapter;
        //tmcDataSet.stylesDataTable _table;
        //tmcDataSet.stylesRow _row;

        Model.RowStyle _row;

        public UCStyles()
        {
            InitializeComponent();

            _contextMenuNodeOptions.MenuItems.Add(_menuItemAdd);
            _contextMenuNodeOptions.MenuItems.Add(_menuItemEdit);
            _contextMenuNodeOptions.MenuItems.Add(_menuItemDelete);

            _menuItemAdd.Click += Handle_menuItemAdd_Click;
            _menuItemEdit.Click += Handle_menuItemEdit_Click;
            _menuItemDelete.Click += Handle_menuItemDelete_Click;

            //_adapter = new tmcDataSetTableAdapters.stylesTableAdapter();
            //_table = new tmcDataSet.stylesDataTable();
            //_adapter.Fill(_table);

            PopulateTree();

            this.treeView.NodeMouseClick += Handle_TreeView_NodeMouseClick;

            StylesDialog.OnUpdated += Handle_StylesDialog_OnUpdated;
        }

        private void Handle_StylesDialog_OnUpdated(object sender, EventArgs e)
        {
            //_adapter.Adapter.UpdateCommand.CommandText += "; SELECT LAST_INSERT_ID()";
            //var rows = _table.Select("", "", DataViewRowState.Added | DataViewRowState.ModifiedCurrent);

            //var x = _table.NewRow();

            //var id = _adapter.Update(rows);
            //rows[0][0] = id;
            PopulateTree();
            treeView.ExpandAll();
        }

        private void Handle_menuItemAdd_Click(object sender, EventArgs e)
        {
            //using (var dialog = new Dialogs.StylesDialog(_table, _row.style_id, isEdit: false))
            //{
            //    dialog.ShowDialog();
            //}
        }

        private void Handle_menuItemDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Handle_menuItemEdit_Click(object sender, EventArgs e)
        {
            using (var dialog = new Dialogs.StylesDialog(_row, isEdit: true))
            {
                dialog.ShowDialog();
            }
        }

        private void Handle_TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return;  }

            _menuItemAdd.Enabled = true;
            _menuItemDelete.Enabled = true;

            var sourceNode = ((TreeView)sender).GetNodeAt(new Point(e.X, e.Y));

            _row = _data.FindById(Converter.ToInt16(sourceNode.Tag));

            if (_row.Alt_style_id != null)
            {
                _menuItemAdd.Enabled = false;
            }
            else if (_row.Parent_style_id == null)
            {
                _menuItemDelete.Enabled = false;
            }

            _contextMenuNodeOptions.Show(treeView, e.Location);
        }

        private void PopulateTree()
        {
            this.treeView.Nodes.Clear();

            //this.trackersTableAdapter.Fill(this.tmcDataSet.trackers);
            //foreach (var row in _table.Where(x => x.Isparent_style_idNull() && x.Isalt_style_idNull()))
            //{
            //    var treeRoot = new TreeNode();
            //    treeRoot.Text = row.name;
            //    treeRoot.Tag = row.style_id;
            //    treeRoot.ExpandAll();
            //    this.treeView.Nodes.Add(treeRoot);

            //    foreach (TreeNode childNode in GetChildNodes(row.style_id))
            //    {
            //        treeRoot.Nodes.Add(childNode);
            //    }
            //}

            foreach (var row in _data.Rows.Where(x => x.Parent_style_id == null && x.Alt_style_id == null))
            {
                var treeRoot = new TreeNode();
                treeRoot.Text = row.Name;
                treeRoot.Tag = row.Style_id;
                treeRoot.ExpandAll();
                this.treeView.Nodes.Add(treeRoot);

                foreach (TreeNode childNode in GetChildNodes(row.Style_id))
                {
                    treeRoot.Nodes.Add(childNode);
                }
            }
        }

        private List<TreeNode> GetChildNodes(short parentID)
        {
            var nodes = new List<TreeNode>();
            var rows = _data.Rows.Where(x => x.Parent_style_id != null && x.Alt_style_id == null  && x.Parent_style_id == parentID);

            foreach (var row in rows)
            {
                var childNode = new TreeNode();
                childNode.Text = row.Name;
                childNode.Tag = row.Style_id;
                childNode.ExpandAll();

                foreach (TreeNode node in GetChildNodes(row.Style_id))
                {
                    childNode.Nodes.Add(node);

                    foreach (TreeNode altNode in GetAltNodes(Convert.ToInt16(node.Tag)))
                    {
                        node.Nodes.Add(altNode);
                    }
                }

                nodes.Add(childNode);
            }

            return nodes;
        }

        private List<TreeNode> GetAltNodes(short parentID)
        {
            var nodes = new List<TreeNode>();
            var rows = _data.Rows.Where(x => x.Alt_style_id != null && x.Alt_style_id == parentID);

            foreach (var row in rows)
            {
                var childNode = new TreeNode();
                childNode.Text = row.Name;
                childNode.Tag = row.Style_id;
                childNode.ExpandAll();
                childNode.ForeColor = Color.Green;

                nodes.Add(childNode);
            }

            return nodes;
        }
    }
}
