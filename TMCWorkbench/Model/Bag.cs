using ModLibrary;
using System;
using System.Collections.Generic;
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

        private ModInfo _mod;
        private Track _track;
        public Guid Guid;

        public string PathLoad;
        public string PathSave;
        public long Duration;
        public bool IsInDB;
        public bool IsNewTrack;

        public void ThrowExceptionIfNull(Object obj, string message)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public async Task Load(string path, long duration)
        {
            _mod = ModLibrary.ModLibrary.ParseAndGuessStyle(path, _db.TrackStyles);

            ThrowExceptionIfNull(_mod, "_mod is null");

            PathLoad = path;
            IsInDB = _manager.IsTrackInDB(path);

            if (IsInDB)
            {
                Guid = Manager.Instance.LastMd5Guid;
            }

            if (IsInDB && (_db.LoadTrackInfo(Guid)))
            {
                _track = _db.Track;
            }

            if (_track == null)
            {
                _track = new Track();
                IsNewTrack = true;
            }
        }

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
    }
}
