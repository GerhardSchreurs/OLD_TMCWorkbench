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

namespace TMCWorkbench.Controls
{
    public partial class MetaDataControl : UserControl
    {
        public DBManager DB;

        public MetaDataControl()
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

            ctrStyleText.SwitchMode();
            ctrComposerText.SwitchMode();
            ctrScenegroupText.SwitchMode();
        }

        private ModInfo _mod;
        private TMCDatabase.DBModel.Track _data;


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
            get => ctrTracker.GetTracker();
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
            get => ctrStyle.GetStringValue();
            set => ctrStyle.SetStyle(value);
        }

        public int? StyleID
        {
            get 
            {
                var id = ctrStyle.GetIntValue();
                if (id == 0) return null;
                return id;
            }
            set => ctrStyle.SetStyle(value);
        }

        public string StyleText
        {
            get => ctrStyleText.Text;
            set => ctrStyleText.Text = value;
        }

        //COMPOSER
        public string Composer
        {
            get => ctrComposer.GetStringValue();
            set => ctrComposer.SetComposer(value);
        }

        public int? ComposerID
        {
            get
            {
                var id = ctrComposer.GetIntValue();
                if (id == 0) return null;
                return id;
            }
            set => ctrComposer.SetComposer(value);
        }

        public string ComposerText
        {
            get => ctrComposerText.Text;
            set => ctrComposerText.Text = value;
        }

        //SCENEGROUP
        public string SceneGroup
        {
            get => ctrScenegroup.GetStringValue();
            set => ctrScenegroup.SetScenegroup(value);
        }

        public int? ScenegroupID
        {
            get
            {
                var id = ctrScenegroup.GetIntValue();
                if (id == 0) return null;
                return id;
            }
            set => ctrScenegroup.SetScenegroup(value);
        }

        public string ScenegroupText
        {
            get => ctrScenegroupText.Text;
            set => ctrComposerText.Text = value;
        }

        public void LoadData(ModInfo modInfo, TMCDatabase.DBModel.Track track, long duration)
        {
            if (modInfo == null)
            {
                _mod = null;
                throw new ArgumentException("Mod is null");
            }
            else
            {
                _mod = modInfo;
            }

            _data = track;

            if (_data.Md5 != Guid.Empty)
            {
                //Track is in database
                this.FileName = _data.FileName;
                this.TrackTitle = _data.TrackTitle;
                this.Date = _data.Date_track_created;
                this.LengthInMs = _data.Length;
                this.SetSpeedAndTempo(_data.Speed, _data.Tempo);
                this.Bpm = _data.Bpm;
                this.StyleID = _data.FK_style_id;
                this.StyleText = _data.StyleName;
                this.ComposerID = _data.FK_composer_id;
                this.ComposerText = _data.ComposerName;
                this.ScenegroupID = _data.FK_scenegroup_id;
                this.ScenegroupText = _data.ScenegroupName;
                this.Tracker = _data.Tracker.Name;

                //Original values
                this.SetLengthInMsOriginal(duration);
                ctrFileInfo.Original = _mod.FileName;
                ctrDate.Original = _mod.DateCreated;
                ctrSpeed.SetValuesOriginal(_mod.Speed, _mod.Tempo);
                ctrBPM.SetValueOriginal(_mod.EstimatedBPM);
                //TODO TRACKER ORIGINAL
            }
            else
            {
                //NOT IN DB, ONLY LOAD FROM DISK
                this.FileName = _mod.FileName;
                this.TrackTitle = _mod.SongName;
                this.Date = _mod.DateCreated;
                this.LengthInMs = duration;
                this.SetSpeedAndTempo(_mod.Speed, _mod.Tempo);
                this.Bpm = _mod.EstimatedBPM;
                this.Tracker = _mod.Tracker.ToStr();
                this.StyleText = _mod.TrackStyle;
                this.ScenegroupText = "";
                this.ComposerText = "";
                this.ScenegroupText = "";

                if (ctrStyle.SetStyle(_mod.TrackStyle))
                {
                    ctrStyleText.Text = "";
                }

                ctrScenegroup.Reset();
                ctrComposer.Reset();
            }
        }
    }
}
