using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMCWorkbench.Dialogs
{
    public partial class PlaylistDialog : DialogBase
    {
        public PlaylistDialog()
        {
            InitializeComponent();
        }

        public int _id;

        public int Id
        {
            set
            {
                _id = value;
                txtId.Text = value.ToStr();
            }
            get => _id;
        }

        public string YoutubeId
        {
            get => txtYoutubeId.Text;
            set => txtYoutubeId.Text = value;
        }

        public new string Name
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        public string Description
        {
            get => txtDescription.Text;
            set => txtDescription.Text = value;
        }

        public bool IsActive
        {
            get => chkIsActive.Checked;
            set => chkIsActive.Checked = value;
        }

        public DialogResult Show(string name, string description, bool isActive = true, int id = -1, string youtubeid = null)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            Id = id;
            YoutubeId = youtubeid;

            return (ShowDialog());
        }
    }
}
