using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCWorkbench.DB;

namespace TMCWorkbench.Controls.Resettable
{
    public partial class ResettableCheckBoxDropDownPlaylists : ResettableCheckBoxDropDown, IRefreshableInit
    {
        private UCPlayLists _form;

        public ResettableCheckBoxDropDownPlaylists()
        {
            InitializeComponent();
        }

        public void Init(bool refresh = false)
        {
            if (_form == null) _form = new UCPlayLists();

            DBManager.Instance.LoadPlaylists(refresh);

            var selectQuery = from playlist in DBManager.Instance.Playlists
                              select new { playlist.Name, playlist.Playlist_id };

            Init(_form, selectQuery, "Name", "Playlist_id");
        }
    }
}
