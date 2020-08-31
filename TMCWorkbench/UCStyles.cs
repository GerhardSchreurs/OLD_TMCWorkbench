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
using TMCDatabase.Model;
//using TMCWorkbench.Dialogs;
using TMCWorkbench.Tools;


namespace TMCWorkbench
{
    public partial class UCStyles : UCForm
    {
        private TMCWorkbench.DB.Manager DB = TMCWorkbench.DB.Manager.Instance;

        private ContextMenu _contextMenuNodeOptions = new ContextMenu();

        private MenuItem _menuItemAdd = new MenuItem("Add");
        private MenuItem _menuItemEdit = new MenuItem("Edit");
        private MenuItem _menuItemDelete = new MenuItem("Delete");

        List<Style> Styles;

        //###
        //TableStyles _data = DB.Instance().TableStyles;
        //Model.RowStyle _row;

        private bool _isDirty;

        public UCStyles()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Styles = DB.C.Styles.ToList();

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

            //###
            //StylesDialog.OnUpdated += Handle_StylesDialog_OnUpdated;
        }

        private void Handle_StylesDialog_OnUpdated(object sender, EventArgs e)
        {
            //_adapter.Adapter.UpdateCommand.CommandText += "; SELECT LAST_INSERT_ID()";
            //var rows = _table.Select("", "", DataViewRowState.Added | DataViewRowState.ModifiedCurrent);

            //var x = _table.NewRow();

            //var id = _adapter.Update(rows);
            //rows[0][0] = id;

            UpdateTreeView();
        }

        void UpdateTreeView()
        {
            PopulateTree();
            treeView.ExpandAll();
            _isDirty = true;
        }

        private void Handle_menuItemAdd_Click(object sender, EventArgs e)
        {   //###
            //using (var dialog = new Dialogs.StylesDialog(_row, isEdit: false))
            //{
            //    dialog.ShowDialog();
            //}
        }

        private void Handle_menuItemDelete_Click(object sender, EventArgs e)
        {
            //###
            //var result = MessageBox.Show("Are you sure?", "Some Title", MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
            //    //do something
            //    _data.DeleteRow(_row);
            //    UpdateTreeView();
            //}
        }

        private void Handle_menuItemEdit_Click(object sender, EventArgs e)
        {
            //###
            //using (var dialog = new Dialogs.StylesDialog(_row, isEdit: true))
            //{
            //    dialog.ShowDialog();
            //}
        }

        private bool HasRowChildRows()
        {
            //###
            //return _data.Rowz.Where
            //    (x => x.Alt_style_id == _row.Style_id || x.Parent_style_id == _row.Style_id)
            //    .Any();

            return false;
        }

        private void Handle_TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return;  }

            _menuItemAdd.Enabled = true;
            _menuItemDelete.Enabled = true;

            var sourceNode = ((TreeView)sender).GetNodeAt(new Point(e.X, e.Y));

            //###
            //_row = _data.FindById(Converter.ToInt16(sourceNode.Tag));

            //if (_row.Alt_style_id != null)
            //{
            //    _menuItemAdd.Enabled = false;
            //}

            //if (HasRowChildRows())
            //{
            //    _menuItemDelete.Enabled = false;
            //}

            //_contextMenuNodeOptions.Show(treeView, e.Location);
        }

        private void PopulateTree()
        {
            this.treeView.Nodes.Clear();


            foreach (var row in Styles.Where(x => x.Parent_style_id == null && x.Alt_style_id == null))
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

            //###
            //foreach (var row in _data.Rowz.Where(x => x.Parent_style_id == null && x.Alt_style_id == null))
            //{
            //    var treeRoot = new TreeNode();
            //    treeRoot.Text = row.Name;
            //    treeRoot.Tag = row.Style_id;
            //    treeRoot.ExpandAll();
            //    this.treeView.Nodes.Add(treeRoot);

            //    foreach (TreeNode childNode in GetChildNodes(row.Style_id))
            //    {
            //        treeRoot.Nodes.Add(childNode);
            //    }
            //}
        }

        private List<TreeNode> GetChildNodes(int parentID)
        {
            var nodes = new List<TreeNode>();

            var rows = Styles.Where(x => x.Parent_style_id != null && x.Alt_style_id == null && x.Parent_style_id == parentID);

            foreach (var row in rows)
            {
                var childNode = new TreeNode();
                childNode.Text = row.Name;
                childNode.Tag = row.Style_id;
                childNode.ExpandAll();

                foreach (TreeNode node in GetChildNodes(row.Style_id))
                {
                    childNode.Nodes.Add(node);

                    foreach (TreeNode altNode in GetAltNodes(Convert.ToInt32(node.Tag)))
                    {
                        node.Nodes.Add(altNode);
                    }
                }

                nodes.Add(childNode);
            }

            return nodes;
        }

        private List<TreeNode> GetAltNodes(int parentID)
        {
            var nodes = new List<TreeNode>();

            var rows = Styles.Where(x => x.Alt_style_id != null && x.Alt_style_id == parentID);

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

        private void Handle_btnSave_Click(object sender, EventArgs e)
        {
            //###
            //_data.UpdateData();
        }
    }
}
