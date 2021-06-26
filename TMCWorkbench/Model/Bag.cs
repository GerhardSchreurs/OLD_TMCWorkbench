using ModLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCDatabase.DBModel;
using TMCWorkbench.DB;

namespace TMCWorkbench.Model
{
    public class Bag
    {
        private DBManager _db = DBManager.Instance;
        private Manager _manager = Manager.Instance;
        private List<C_Track_Tag> _trackTags;

        private ModInfo _mod;
        private Track _track;
        public Guid Guid;

        public string PathLoad;
        public string PathSave;

        public long Duration;
        public bool IsInDB;
        public bool IsNewTrack;

        public static void ThrowExceptionIfNull(object obj, string message)
        {
            if (obj == null) throw new NullReferenceException(message);
        }

        public async Task<string> Load(string path, bool fileExists, Guid guid, bool fromDB = false, bool refresh = false)
        {
            var success = string.Empty;

            _mod = null;
            IsInDB = fromDB;
            PathLoad = path;
            IsNewTrack = !fromDB;
            Guid = guid;
            Track = null;
            Duration = 0;

            try
            {
                success = await LoadInner(path, fileExists, refresh);
            }
            catch(Exception ex)
            {
                success = ex.Message;   //TODO, clear vars?
            }

            return success;
        }

        public async Task<string> LoadInner(string path, bool fileExists, bool refresh)
        {
            var success = string.Empty;

            if (fileExists)
            {
                _mod = ModLibrary.ModLibrary.ParseAndGuessStyle(path, _db.TrackStyles);

                if (_mod == null)
                {
                    //This should not happen, we have path, something went wrong in ModLibrary?
                    return $"Mod exists on disk, however got nullreference from ModLibrary: {path}";
                }

                PathLoad = path;
            }

            if (IsInDB)
            {
                if (_db.LoadTrackInfo(Guid))
                {
                    _track = _db.Track;
                }
                else
                { 
                    //Should be in DB!
                    return $"Track should be in DB, but is not: {Guid}";
                }
            } 
            else 
            {
                //Not in DB
                IsInDB = _manager.IsTrackInDB(path);

                if (IsInDB)
                {
                    Guid = Manager.Instance.LastMd5Guid;
                }
            }


            if (_track == null)
            {
                _trackTags = null;
                _track = new Track();
                IsNewTrack = true;
            }
            else
            {
                DBManager.Instance.LoadTrackTagsWithTag(refresh);
                _trackTags = DBManager.Instance.TracksTagsWithTag.Where(x => x.FK_track_id == _track.Track_id).ToList();
            }

            return success;
        }


        //public async Task LoadFromDatabase(Guid guid, bool refresh = false)
        //{
        //    _mod = null;
        //    PathLoad = null;

        //    IsInDB = true;
        //    Guid = guid;

        //    LoadInternal(refresh);
        //}

        //public async Task LoadFromDisk(string path, long duration, bool refresh = false)
        //{
        //    _mod = ModLibrary.ModLibrary.ParseAndGuessStyle(path, _db.TrackStyles);

        //    ThrowExceptionIfNull(_mod, "_mod is null");

        //    PathLoad = path;
        //    IsInDB = _manager.IsTrackInDB(path);

        //    if (IsInDB)
        //    {
        //        Guid = Manager.Instance.LastMd5Guid;
        //    }

        //    LoadInternal(refresh);
        //}


        //private void LoadInternal(bool refresh)
        //{
        //    if (IsInDB && (_db.LoadTrackInfo(Guid)))
        //    {
        //        _track = _db.Track;
        //    }

        //    if (_track == null)
        //    {
        //        _trackTags = null;
        //        _track = new Track();
        //        IsNewTrack = true;
        //    }
        //    else
        //    {
        //        DBManager.Instance.LoadTrackTagsWithTag(refresh);
        //        _trackTags = DBManager.Instance.TracksTagsWithTag.Where(x => x.FK_track_id == _track.Track_id).ToList();
        //    }
        //}



        public ModInfo Mod
        {
            get => _mod;
            set => _mod = value;
        }

        public Track Track
        {
            get => _track;
            set => _track = value;
        }

        public List<C_Track_Tag> TrackTags
        {
            get => _trackTags;
            private set => _trackTags = value;
        }
        
        public int[] GetTrackTagsArray()
        {
            if (_trackTags == null) return null;
            var arr = new int[_trackTags.Count];

            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = _trackTags[i].FK_tag_id;
            }

            return arr;
        }
    }
}
