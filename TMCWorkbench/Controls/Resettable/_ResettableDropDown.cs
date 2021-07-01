using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class _ResettableDropDown : _ResettablePanel
    {
        public _ResettableDropDown()
        {
            InitializeComponent();

            //WORKAROUND
            //https://stackoverflow.com/questions/3064780/winforms-combobox-dropdown-and-autocomplete-window-both-appear
            this.ddList.KeyDown += Handle_DdList_KeyDown;
            this.Disposed += Handle_ResettableDropDown_Disposed;
        }

        private void Handle_ResettableDropDown_Disposed(object sender, EventArgs e)
        {
            this.ddList.KeyDown -= Handle_DdList_KeyDown;
        }

        private void Handle_DdList_KeyDown(object sender, KeyEventArgs e)
        {
            ddList.DroppedDown = false;
        }

        public int GetValue()
        {
            return this.ddList.SelectedValue.ToInt();
        }
    }
}
