using Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.Model;
using TMCWorkbench.Tools;

namespace TMCWorkbench.Dialogs
{
    public partial class StylesDialog : Form
    {
        public delegate void DataUpdatedEventHandler(object sender, EventArgs e);
        public static event DataUpdatedEventHandler OnUpdated;

        private void RaiseOnUpdated()
        {
            OnUpdated?.Invoke(this, new EventArgs());
        }

        private bool _isEdit;
        private Model.RowStyle _row;
        private Database.DB _db = Database.DB.Instance();

        public StylesDialog(Model.RowStyle row, bool isEdit = false)
        {
            InitializeComponent();

            _isEdit = isEdit;
            _row = row;

            if (isEdit)
            {
                this.btnAction.Text = "Save";
                txtName.Text = _row.Name;
                txtWeight.Text = _row.Weight.ToString();
            }
            else
            {
                //add
                this.btnAction.Text = "Add";
            }
        }

        private void Process(Model.RowStyle row)
        {
            row.Name = txtName.Text;

            sbyte weight = -1;

            if (txtWeight.Text.IsNotNullOrEmpty())
            {
                row.Weight = Converter.ToSByte(txtWeight.Text);
            }

            row.Weight = weight;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (_isEdit)
            {
                Process(_row);
                _row.DataRowState = DataRowState.Modified;
            }
            else
            {
                //var row = _db.TableStyles.NewRow();
                //if (_row.Parent_style_id == null)
                //{
                //    row.Parent_style_id = _row.Style_id;
                //}
                //else
                //{
                //    row.Alt_style_id = _row.Style_id;
                //}

                var row = _db.TableStyles.NewRow();

                if (_row.Parent_style_id == null && _row.Alt_style_id == null)
                {
                    //This is a new basegroup, do nothing
                }
                else if (_row.Parent_style_id != null)
                {
                    row.Parent_style_id = _row.Style_id;
                }
                else if (_row.Alt_style_id != null)
                {
                    row.Alt_style_id = _row.Alt_style_id;
                }

                Process(row);

                _db.TableStyles.AddRow(row);
            }

            RaiseOnUpdated();
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
