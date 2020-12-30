using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls
{
    public class HistoryTextBoxControl : System.Windows.Forms.TextBox
    {
        bool ignoreChange = true;
        List<string> storageUndo = null;
        List<string> storageRedo = null;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            storageUndo = new List<string>();
            storageRedo = new List<string>();
            ignoreChange = false;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (!ignoreChange)
            {
                this.ClearUndo();
                if (storageUndo.Count > 2048) storageUndo.RemoveAt(0);
                if (storageRedo.Count > 2048) storageRedo.RemoveAt(0);

                storageUndo.Add(this.Text);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Z && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                this.ClearUndo();
                ignoreChange = true;
                this.Undo();
                ignoreChange = false;

                this.SelectionStart = this.Text.Length;
                this.SelectionLength = 0;
            }
            else if (e.KeyCode == Keys.Y && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                this.ClearUndo();
                ignoreChange = true;
                this.Redo();
                ignoreChange = false;

                this.SelectionStart = this.Text.Length;
                this.SelectionLength = 0;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        public void Redo()
        {
            if (storageRedo.Count > 0)
            {
                this.ignoreChange = true;
                this.Text = storageRedo[storageRedo.Count - 1];
                storageUndo.Add(this.Text);
                storageRedo.RemoveAt(storageRedo.Count - 1);
                this.ignoreChange = false;
            }
        }

        public new void Undo()
        {
            if (storageUndo.Count > 0)
            {
                this.ignoreChange = true;
                storageRedo.Add(this.Text);
                this.Text = storageUndo[storageUndo.Count - 1];
                storageUndo.RemoveAt(storageUndo.Count - 1);
                this.ignoreChange = false;
            }
        }
    }
}
