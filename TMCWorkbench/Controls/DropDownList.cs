using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls
{
    public class DropDownList : ComboBox
    {
        public DropDownList() : base()
        {
            //WORKAROUND
            //https://stackoverflow.com/questions/3064780/winforms-combobox-dropdown-and-autocomplete-window-both-appear
            this.KeyDown += Handle_KeyDown;
            this.Disposed += Handle_Disposed;

            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void Handle_KeyDown(object sender, KeyEventArgs e)
        {
            DroppedDown = false;
        }

        private void Handle_Disposed(object sender, EventArgs e)
        {
            KeyDown -= Handle_KeyDown;
            base.Dispose();
        }
    }
}
