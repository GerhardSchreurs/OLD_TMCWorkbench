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
using TMCDatabase.Model;
using TMCWorkbench.Tools;

namespace TMCWorkbench.Dialogs
{
    public partial class StylesDialog : Form
    {
        private TMCWorkbench.DB.DBManager DB = TMCWorkbench.DB.DBManager.Instance;

        public delegate void DataUpdatedEventHandler(object sender, EventArgs e);
        public static event DataUpdatedEventHandler OnUpdated;
        
        private bool _isEdit;
        private Style _row;

        private void RaiseOnUpdated()
        {
            OnUpdated?.Invoke(this, new EventArgs());
        }

        public StylesDialog(Style row, bool isEdit = false)
        {
            InitializeComponent();

            _isEdit = isEdit;
            _row = row;
            radStyle.Checked = true;

            if (isEdit)
            {
                this.btnAction.Text = "Save";
                txtName.Text = _row.Name;
                txtWeight.Text = _row.Weight.ToString();

                if (_row.IsAlt)
                {
                    radAlt.Checked = true;
                }
                else
                {
                    radStyle.Checked = true;
                }
            }
            else
            {
                //add
                this.btnAction.Text = "Add";
            }
        }

        private void Process(Style row)
        {
            row.Name = txtName.Text;

            sbyte weight = -1;

            if (txtWeight.Text.IsNotNullOrEmpty())
            {
                row.Weight = Converter.ToSByte(txtWeight.Text);
            }

            row.IsAlt = radAlt.Checked;
            row.Weight = weight;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (_isEdit)
            {
                Process(_row);
                //_row.DataRowState = DataRowState.Modified;
            }
            else
            {
                //var row = _db.TableStyles.NewRow();
                var row = new Style();

                if (_row == null)
                {
                    //Do nothing
                }
                else
                {
                    row.ParentStyle = _row;

                    if (radAlt.Checked)
                    {
                        row.IsAlt = true;
                    }
                }

                Process(row);
                DB.Add(row);

                //_db.TableStyles.AddRow(row);
            }

            DB.Save();
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
