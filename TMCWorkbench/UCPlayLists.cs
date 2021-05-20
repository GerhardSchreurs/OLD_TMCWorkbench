using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCDatabase.DBModel;
using TMCDatabase.Model;
using TMCWorkbench.DB;

namespace TMCWorkbench
{
    public partial class UCPlayLists : _UCForm
    {
        DBManager DB = DBManager.Instance;
        private Playlist _playlist;
        private TrackPlaylist _trackPlaylist;
        private List<Track> _dropDownTracks;
        private List<TrackPlaylist> _trackPlaylists;
        private int _gridPlaylistIndex;

        public UCPlayLists()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DB.LoadPlaylists();
            DB.LoadTracks();
            DB.LoadTracksPlaylists();

            ddlTracks.AutoCompleteMode = AutoCompleteMode.Suggest;
            ddlTracks.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddlTracks.DisplayMember = "TrackTitle";
            ddlTracks.ValueMember = "Track_id";

            BindPlaylists();

            gridPlaylists.Select();
            Handle_gridPlaylists_SelectionChanged(null, null);

            txtSearch.KeyPress += Handle_TxtSearch_KeyPress;
        }

        private void Handle_TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSearch.PerformClick();
            }
        }

        private void BindPlaylists(string query = "")
        {
            List<Playlist> datasource;

            if (query.IsNullOrEmpty())
                datasource = DB.Playlists.OrderByDescending(x => x.Playlist_id).ToList();
            else
            {
                datasource = DB.Playlists.Where(x => x.Name.ToLow().Contains(query.ToLow())).OrderByDescending(x => x.Playlist_id).ToList();
                txtSearch.SelectAll();
                txtSearch.Focus();
            }

            gridPlaylists.SelectionChanged -= Handle_gridPlaylists_SelectionChanged;

            gridPlaylists.DataSource = null;
            gridPlaylists.DataSource = datasource;
            gridPlaylists.ClearSelection();

            if (gridPlaylists.Rows.Count < _gridPlaylistIndex)
            {
                _gridPlaylistIndex = 0;
            }

            if (gridPlaylists.Rows.Count == 0) return;

            gridPlaylists.Rows[_gridPlaylistIndex].Selected = true;
            gridPlaylists.CurrentCell = gridPlaylists.Rows[_gridPlaylistIndex].Cells[0];
            gridPlaylists.SelectionChanged += Handle_gridPlaylists_SelectionChanged;

            Handle_gridPlaylists_SelectionChanged(null, null);
        }

        private void BindTracks()
        {
            gridTracks.SelectionChanged -= Handle_gridTracks_SelectionChanged;
            gridTracks.DataSource = null;

            if (_playlist != null)
            {
                RetrieveData(_playlist.Playlist_id);

                gridTracks.DataSource = _trackPlaylists;
                gridTracks.ClearSelection();

                ddlTracks.DataSource = _dropDownTracks;
            }

            gridTracks.SelectionChanged += Handle_gridTracks_SelectionChanged;
        }

        private void RetrieveData(int id)
        {
            _dropDownTracks = new List<Track>();

            var trackPlaylists = DB.TracksPlaylists.Where(x => x.FK_playlist_id == id);
            var tracks = new List<Track>();
            _trackPlaylists = new List<TrackPlaylist>();

            foreach (var trackPlaylist in trackPlaylists)
            {
                _trackPlaylists.Add(new TrackPlaylist(trackPlaylist, true));
                tracks.Add(trackPlaylist.Track);
            }

            foreach (var track in DB.Tracks.OrderByDescending(x => x.Track_id))
            {
                if (!tracks.Contains(track))
                {
                    _dropDownTracks.Add(track);
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gridPlaylists.SelectionChanged -= Handle_gridPlaylists_SelectionChanged;
            gridTracks.SelectionChanged -= Handle_gridTracks_SelectionChanged;
            txtSearch.KeyPress -= Handle_TxtSearch_KeyPress;
            base.OnFormClosed(e);
        }

        void UpdateControls()
        {
            //No controls to update yet
            BindTracks();
        }

        private void Handle_gridPlaylists_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPlaylists.SelectedRows.Count == 0) return;

            _gridPlaylistIndex = gridPlaylists.SelectedRows[0].Index;
            _playlist = gridPlaylists.SelectedRows[0].DataBoundItem as Playlist;

            UpdateControls();
        }

        private void Handle_gridTracks_SelectionChanged(object sender, EventArgs e)
        {
            if (gridTracks.SelectedRows.Count == 0) return;

            _trackPlaylist = gridTracks.SelectedRows[0].DataBoundItem as TrackPlaylist;
        }

        private void Handle_btnAddPlaylist_Click(object sender, EventArgs e)
        {
            if (txtAddPlaylist.Text.Length <= 0) return;

            using (var form = new Dialogs.PlaylistDialog())
            {
                var result = form.Show(txtAddPlaylist.Text, "");

                if (result == DialogResult.OK)
                {
                    var playlist = new Playlist();
                    playlist.Name = form.Name;
                    playlist.Description = form.Description;
                    playlist.YoutubeId = form.YoutubeId;
                    playlist.IsActive = form.IsActive;
                    DB.Add(playlist, true);

                    BindPlaylists();
                }
            }
        }

        private void Handle_gridPlaylists_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            var rowsSelected = gridPlaylists.SelectedRows.Count;

            var result = MessageBox.Show("Are you sure?", $"You are about to delete {rowsSelected} row(s) from playlist", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                for (var i = rowsSelected - 1; i >= 0; i--)
                {
                    var row = gridPlaylists.SelectedRows[i].DataBoundItem as Playlist;
                    DB.Remove(row);
                }
            }

            DB.Save();
            DB.LoadPlaylists(true);
            BindPlaylists();
        }

        private void Handle_gridTracks_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            var rowsSelected = gridTracks.SelectedRows.Count;

            var result = MessageBox.Show("Are you sure?", $"You are about to delete {rowsSelected} row(s) from tracks TODO", MessageBoxButtons.OKCancel);
            var tracks = new List<Track>();

            if (result == DialogResult.OK)
            {
                for (var i = rowsSelected - 1; i >= 0; i--)
                {
                    var row = gridTracks.SelectedRows[i].DataBoundItem as TrackPlaylist;
                    tracks.Add(row.GetTrack());
                }
            }

            if (tracks.Count > 0)
            {
                DB.RemoveTrackFromPlaylist(_playlist, tracks);

                DB.Save();
                DB.LoadTracksPlaylists(true);
                BindTracks();
            }
        }

        private void Handle_btnAddTrack_Click(object sender, EventArgs e)
        {
            if (!ddlTracks.SelectedValue.IsNumeric()) return;

            DB.AddTrackToPlaylist(_playlist.Playlist_id, ddlTracks.SelectedValue.ToInt());
            DB.Save();
            DB.LoadPlaylists();
            DB.LoadTracksPlaylists(true);
            BindTracks();

            gridPlaylists.Select();
        }

        private void Handle_gridPlaylists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var rowsSelected = gridPlaylists.SelectedRows.Count;
            if (rowsSelected != 1) return;

            var row = gridPlaylists.SelectedRows[0].DataBoundItem as Playlist;

            using (var form = new Dialogs.PlaylistDialog())
            {
                var result = form.Show(row.Name, row.Description, row.IsActive, row.Playlist_id, row.YoutubeId);

                if (result == DialogResult.OK)
                {
                    row.Name = form.Name;
                    row.Description = form.Description;
                    row.YoutubeId = form.YoutubeId;
                    row.IsActive = form.IsActive;

                    DB.Save();
                    DB.LoadTracks();
                    DB.LoadTracksPlaylists(true);
                    BindTracks();

                    gridPlaylists.Select();
                }
            }

        }

        private void Handle_btnSearch_Click(object sender, EventArgs e)
        {
            BindPlaylists(txtSearch.Text);
        }
    }
}
