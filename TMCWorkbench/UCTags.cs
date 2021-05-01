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
    public partial class UCTags : _UCForm
    {
        DBManager DB = DBManager.Instance;
        private Tag _tag;
        private TrackTag _trackTag;
        private List<Track> _dropDownTracks;
        private List<TrackTag> _trackTags;
        private int _gridTagIndex;

        public UCTags()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DB.LoadTags();
            DB.LoadTracks();
            DB.LoadTracksTags();

            ddlTracks.AutoCompleteMode = AutoCompleteMode.Suggest;
            ddlTracks.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddlTracks.DisplayMember = "TrackTitle";
            ddlTracks.ValueMember = "Track_id";

            BindTags();

            gridTags.Select();
            Handle_gridTags_SelectionChanged(null, null);

            txtSearch.KeyPress += Handle_TxtSearch_KeyPress;
        }

        private void Handle_TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSearch.PerformClick();
            }
        }

        private void BindTags(string query = "")
        {
            List<Tag> datasource;

            if (query.IsNullOrEmpty())
                datasource = DB.Tags.OrderByDescending(x => x.Tag_id).ToList();
            else
            {
                datasource = DB.Tags.Where(x => x.Name.ToLow().Contains(query.ToLow())).OrderByDescending(x => x.Tag_id).ToList();
                txtSearch.SelectAll();
                txtSearch.Focus();
            }

            gridTags.SelectionChanged -= Handle_gridTags_SelectionChanged;

            gridTags.DataSource = null;
            gridTags.DataSource = datasource;
            gridTags.ClearSelection();

            if (gridTags.Rows.Count < _gridTagIndex)
            {
                _gridTagIndex = 0;
            }

            if (gridTags.Rows.Count == 0) return;

            gridTags.Rows[_gridTagIndex].Selected = true;
            gridTags.CurrentCell = gridTags.Rows[_gridTagIndex].Cells[0];
            gridTags.SelectionChanged += Handle_gridTags_SelectionChanged;

            Handle_gridTags_SelectionChanged(null, null);
        }

        private void BindTracks()
        {
            gridTracks.SelectionChanged -= Handle_gridTracks_SelectionChanged;
            gridTracks.DataSource = null;

            if (_tag != null)
            {
                RetrieveData(_tag.Tag_id);

                gridTracks.DataSource = _trackTags;
                gridTracks.ClearSelection();

                ddlTracks.DataSource = _dropDownTracks;
            }

            gridTracks.SelectionChanged += Handle_gridTracks_SelectionChanged;
        }

        private void RetrieveData(int id)
        {
            _dropDownTracks = new List<Track>();

            var trackTags = DB.TracksTags.Where(x => x.FK_tag_id == id);
            var tracks = new List<Track>();
            _trackTags = new List<TrackTag>();

            foreach (var trackTag in trackTags)
            {
                _trackTags.Add(new TrackTag(trackTag, true));
                tracks.Add(trackTag.Track);
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
            gridTags.SelectionChanged -= Handle_gridTags_SelectionChanged;
            gridTracks.SelectionChanged -= Handle_gridTracks_SelectionChanged;
            txtSearch.KeyPress -= Handle_TxtSearch_KeyPress;
            base.OnFormClosed(e);
        }

        void UpdateControls()
        {
            //No controls to update yet
            BindTracks();
        }

        private void Handle_gridTags_SelectionChanged(object sender, EventArgs e)
        {
            if (gridTags.SelectedRows.Count == 0) return;

            _gridTagIndex = gridTags.SelectedRows[0].Index;
            _tag = gridTags.SelectedRows[0].DataBoundItem as Tag;

            UpdateControls();
        }

        private void Handle_gridTracks_SelectionChanged(object sender, EventArgs e)
        {
            if (gridTracks.SelectedRows.Count == 0) return;

            _trackTag = gridTracks.SelectedRows[0].DataBoundItem as TrackTag;
        }

        private void Handle_btnAddTag_Click(object sender, EventArgs e)
        {
            if (txtAddTag.Text.Length <= 0) return;

            using (var form = new Dialogs.DoubleStringDialog())
            {
                var result = form.Show("Add new tag", "Name", "Description", txtAddTag.Text, "", "Add");

                if (result == DialogResult.OK)
                {
                    var tag = new Tag();
                    tag.Name = form.TextA;
                    tag.Description = form.TextB;
                    DB.Add(tag, true);

                    BindTags();
                }
            }
        }

        private void Handle_gridTags_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            var rowsSelected = gridTags.SelectedRows.Count;

            var result = MessageBox.Show("Are you sure?", $"You are about to delete {rowsSelected} row(s) from tags", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                for (var i = rowsSelected - 1; i >= 0; i--)
                {
                    var row = gridTags.SelectedRows[i].DataBoundItem as Tag;
                    DB.Remove(row);
                }
            }

            DB.Save();
            DB.LoadTags(true);
            BindTags();
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
                    var row = gridTracks.SelectedRows[i].DataBoundItem as TrackTag;
                    tracks.Add(row.GetTrack());
                }
            }

            if (tracks.Count > 0)
            {
                DB.RemoveTrackFromTag(_tag, tracks);

                DB.Save();
                DB.LoadTracksTags(true);
                BindTracks();
            }
        }

        private void Handle_btnAddTrack_Click(object sender, EventArgs e)
        {
            if (!ddlTracks.SelectedValue.IsNumeric()) return;

            DB.AddTrackToTag(_tag.Tag_id, ddlTracks.SelectedValue.ToInt());
            DB.Save();
            DB.LoadTags();
            DB.LoadTracksTags(true);
            BindTracks();

            gridTags.Select();
        }

        private void Handle_gridTags_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var rowsSelected = gridTags.SelectedRows.Count;
            if (rowsSelected != 1) return;

            var row = gridTags.SelectedRows[0].DataBoundItem as Tag;
            
            using (var form = new Dialogs.DoubleStringDialog())
            {
                var result = form.Show("Edit tag", "Name", "Description", row.Name, row.Description, "Edit");

                if (result == DialogResult.OK)
                {
                    row.Name = form.TextA;
                    row.Description = form.TextB;
                    DB.Save();
                    DB.LoadTracks();
                    DB.LoadTracksTags(true);
                    BindTracks();

                    gridTags.Select();
                }
            }

        }

        private void Handle_btnSearch_Click(object sender, EventArgs e)
        {
            BindTags(txtSearch.Text);
        }
    }
}
