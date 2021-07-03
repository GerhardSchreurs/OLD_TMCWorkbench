using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModLibrary;
using TMCWorkbench.DB;
using TMCWorkbench;
using TMCWorkbench.Model;
using TMCDatabase.Model;
using TMCDatabase.DBModel;

//TAGS? Favorite? Hoe in de toekomst database updaten?

namespace TMCWorkbench.Controls
{
    public partial class ControlMetaData : UserControl
    {
        public DBManager DB;

        public ControlMetaData()
        {
            InitializeComponent();
        }

        public void Init()
        {
            DB = DBManager.Instance;

            ctrTracker.Init();
            ctrStyle.Init();
            ctrComposer.Init();
            ctrScenegroup.Init();
            ctrTags.Init();
            ctrPlaylists.Init();

            ctrStyleText.SwitchMode();
            ctrComposerText.SwitchMode();
            ctrScenegroupText.SwitchMode();

            //InitTags();
        }

        //private List<C_Track_Tag> _trackTagsWithTag;

        //void InitTags()
        //{
        //    DB.LoadTags();
        //    DB.LoadTrackTagsWithTag();

        //    _trackTagsWithTag = DB.TracksTagsWithTag.ToList();

        //    foreach (var tag in DB.Tags)
        //    {
        //        var box = new CCBoxItem(tag.Name, tag.Tag_id);
        //        ctrTagsOLD.Items.Add(box);
        //    }

        //    ctrTagsOLD.DisplayMember = "Name";
        //}

        //void SelectTags(int trackId)
        //{
        //    //ctrTagsOLD.DeselectAll();

        //    //if (trackId <= 0) return;

        //    var results = _trackTagsWithTag.Where(x => x.FK_track_id == trackId).ToList();
        //    var arr = new int[results.Count];

        //    for (var i = 0; i<arr.Length; i++)
        //    {
        //        arr[i] = results[i].FK_tag_id;
        //    }

        //    ctrTags.IdValues = arr;

        //    //foreach (var tag in _trackTagsWithTag.Where(x => x.FK_track_id == trackId))
        //    //{
        //    //    ctrTagsOLD.SetItemByIdChecked(tag.FK_tag_id, true);
        //    //}
        //}

        //void FillTags(int trackId)
        //{
        //    //if (trackId <= 0) return;

        //    var results = _trackTagsWithTag.Where(x => x.FK_track_id == trackId).ToList();
        //    var arr = new int[results.Count];

        //    for (var i = 0; i < arr.Length; i++)
        //    {
        //        arr[i] = results[i].FK_tag_id;
        //    }

        //    ctrTags.IdValues = arr;
        //}



        //private ModInfo _mod;
        //private TMCDatabase.DBModel.Track _track;


        public string FileName
        {
            get => ctrFileInfo.Text;
            set => ctrFileInfo.Text = value;
        }

        public string TrackTitle { 
            get => ctrTrackTitle.Text;
            set => ctrTrackTitle.Text = value;
        }

        public DateTime? Date
        {
            get => ctrDate.Date;
            set => ctrDate.Date = value;
        }

        public long LengthInMs
        {
            get
            {
                var data = ctrLength.GetValues();
                return Tools.TimeConverter.ConvertToMilliseconds(data.valueA, data.valueB);
            }
            set
            {
                var length = Tools.TimeConverter.ConvertToMinutesAndSeconds(value);
                ctrLength.SetValues(length.Item1, length.Item2);
            }
        }

        public void SetLengthInMsOriginal(long value)
        {
            var length = Tools.TimeConverter.ConvertToMinutesAndSeconds(value);
            ctrLength.SetValuesOriginal(length.Item1, length.Item2);
        }

        public void SetSpeedAndTempo(int speed, int tempo)
        {
            ctrSpeed.SetValues(speed, tempo);
        }

        public int Speed
        {
            get => ctrSpeed.GetValues().valueA;
        }

        public int Tempo
        {
            get => ctrSpeed.GetValues().valueB;
        }

        public int Bpm
        {
            get => ctrBPM.GetValue();
            set => ctrBPM.SetValue(value);
        }

        //TRACKER
        public string Tracker
        {
            get
            {
                if (ctrTracker == null)
                {
                    //HACK: FOR WINFORMS NULL REFERENCE
                    //Cannot perform runtime binding on a null reference
                    return "Unknown";
                }

                return ctrTracker.GetTracker();

            }
            set => ctrTracker.SetTracker(value);
        }


        public int TrackerID
        {
            get => ctrTracker.GetValue();
            set => ctrTracker.SetTracker(value);
        }

        //STYLE
        public string Style
        {
            //get => ctrStyle.GetStringValue();
            get => ctrStyle.TextValue;
            set
            {
                //ctrStyle.SetStyle(value);
                ctrStyle.TextValue = value;
            }
        }

        public int? StyleID
        {
            get 
            {
                //var id = ctrStyle.Value();
                var id = ctrStyle.IdValue;
                if (id == 0) return null;
                return id;
            }
            set
            {
                //ctrStyle.SetStyle(value);
                ctrStyle.IdValue = value;
            }
        }

        public string StyleText
        {
            get => ctrStyleText.Text;
            set => ctrStyleText.Text = value;
        }

        public string GetStyleCalulated()
        {
            return Style.IsNullOrEmpty() ? StyleText : Style;
        }

        //COMPOSER
        public string Composer
        {
            //get => ctrComposer.GetStringValue();
            get => ctrComposer.TextValue;
            set
            {
                //ctrComposer.SetComposer(value);
                ctrComposer.TextValue = value;
            }
        }

        public int? ComposerID
        {
            get
            {
                //var id = ctrComposer.GetIntValue();
                var id = ctrComposer.IdValue;
                if (id == 0) return null;
                return id;
            }
            set
            {
                //ctrComposer.SetComposer(value);
                ctrComposer.IdValue = value;
            }
                
        }

        public string ComposerText
        {
            get => ctrComposerText.Text;
            set => ctrComposerText.Text = value;
        }

        public string GetComposerCalculated()
        {
            return Composer.IsNullOrEmpty() ? ComposerText : Composer;
        }

        //SCENEGROUP
        public string SceneGroup
        {
            //get => ctrScenegroup.GetStringValue();
            //set => ctrScenegroup.SetScenegroup(value);

            get => ctrScenegroup.TextValue;
            set => ctrScenegroup.TextValue = value;

        }

        public double? Score
        {
            get => ctrScore.Value;
            set => ctrScore.Value = value;
        }

        public int? ScenegroupID
        {
            get
            {
                //var id = ctrScenegroup.GetIntValue();
                var id = ctrScenegroup.IdValue;
                if (id == 0) return null;
                return id;
            }
            //set => ctrScenegroup.SetScenegroup(value);
            set => ctrScenegroup.IdValue = value;
        }

        public string ScenegroupText
        {
            get => ctrScenegroupText.Text;
            set => ctrScenegroupText.Text = value;
        }

        public bool IsFavorite
        {
            get => ctrFavorite.Value;
            set => ctrFavorite.Value = value;
        }

        public string GetScenegroupCalulated()
        {
            return SceneGroup.IsNullOrEmpty() ? ScenegroupText : SceneGroup;
        }

        public int[] GetTagIds()
        {
            return ctrTags.GetIdValues();
        }

        public void SetTagIds(int[] ids)
        {
            ctrTags.SetIdValues(ids);
        }

        public int[] GetPlaylistIds()
        {
            return ctrPlaylists.GetIdValues();
        }

        public void SetPlaylistIds(int[] ids)
        {
            ctrPlaylists.SetIdValues(ids);
        }

        public void LoadData(Bag bag)
        {
            var mod = bag.Mod;
            var track = bag.Track;

            ctrStyle.Reset();
            ctrScenegroup.Reset();
            ctrComposer.Reset();

            if (bag.IsInDB)
            {
                //Track is in database
                this.FileName = track.FileName;
                this.TrackTitle = track.TrackTitle;
                this.Date = track.Date_track_created;
                this.LengthInMs = track.Length;
                this.IsFavorite = track.Is_favorite;
                this.SetSpeedAndTempo(track.Speed, track.Tempo);
                this.Bpm = track.Bpm;
                this.StyleID = track.FK_style_id;
                this.StyleText = track.StyleName;
                this.ComposerID = track.FK_composer_id;
                this.ComposerText = track.ComposerName;
                this.ScenegroupID = track.FK_scenegroup_id;
                this.ScenegroupText = track.ScenegroupName;
                this.Tracker = track.Tracker.Name;
                this.Score = track.Score;

                //Original values
                this.SetLengthInMsOriginal(bag.Duration);

                this.SetTagIds(bag.TrackTagIds);
                this.SetPlaylistIds(bag.TrackPlaylistIds);
                //ctrTags.SetIdValues(bag.GetTrackTagsArray());
                //ctrPlaylists.SetIdValues(bag.GetTrackPlaylistsArray());

                if (mod == null) return;

                ctrFileInfo.Original = mod.FileName;
                ctrTrackTitle.Original = mod.SongName;
                ctrDate.Original = mod.DateCreated;
                ctrSpeed.SetValuesOriginal(mod.Speed, mod.Tempo);
                ctrBPM.SetValueOriginal(mod.EstimatedBPM);
                ctrStyle.TextValueOriginal = mod.TrackStyle;
                //this.SelectTags(track.Track_id);
                //TODO TRACKER ORIGINAL
            }
            else
            {
                //NOT IN DB, ONLY LOAD FROM DISK
                this.FileName = mod.FileName;
                this.TrackTitle = mod.SongName;
                this.Date = mod.DateCreated;
                this.LengthInMs = bag.Duration;
                this.SetSpeedAndTempo(mod.Speed, mod.Tempo);
                this.Bpm = mod.EstimatedBPM;
                this.Tracker = mod.Tracker.ToStr();
                this.Style = mod.TrackStyle;
                this.StyleText = mod.TrackStyle;
                this.ComposerText = "";
                this.ScenegroupText = "";

                this.SetTagIds(null);
                this.SetPlaylistIds(null);

                //TODO
                //if (ctrStyle.SetStyle(mod.TrackStyle))
                //{
                //    ctrStyleText.Text = "";
                //}
            }
        }
    }
}
