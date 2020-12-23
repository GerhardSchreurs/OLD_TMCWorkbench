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

        public void LoadData(ModInfo modInfo, TMCDatabase.DBModel.Track data, long duration)
        {
            if (modInfo == null) return;

            var time = Tools.MillisecondsConverter.ConvertToMinutesAndSeconds(duration);

            if (data != null)
            {
                var timeDB = Tools.MillisecondsConverter.ConvertToMinutesAndSeconds(data.Length);

                ctrFileInfo.Text = data.FileName;
                ctrTrackTitle.Text = data.TrackTitle;
                ctrDate.Date = data.Date_created;
                ctrLength.SetValues(timeDB.Item1, timeDB.Item2);
                ctrSpeed.SetValues(data.Speed, data.Tempo);
                ctrBPM.SetValue(data.Bpm);
                ctrStyle.SetStyle(data.FK_style_id);
                ctrStyleText.Text = data.StyleName;
                ctrComposer.SetComposer(data.FK_composer_id);
                ctrComposerText.Text = data.ComposerName;
                ctrScenegroup.SetScenegroup(data.FK_scenegroup_id);
                ctrScenegroupText.Text = data.ScenegroupName;
                ctrTracker.SetTracker(data.Tracker.Name);

                ctrFileInfo.Original = modInfo.FileName;
                ctrDate.Original = modInfo.DateCreated;
                ctrLength.SetValuesOriginal(time.Item1, time.Item2);
                ctrSpeed.SetValuesOriginal(modInfo.Speed, modInfo.Tempo);
                ctrBPM.SetValueOriginal(modInfo.EstimatedBPM);
            }
            else
            {
                //NOT IN DB, ONLY LOAD FROM DISK
                ctrFileInfo.Text = modInfo.FileName;
                ctrTrackTitle.Text = modInfo.SongName;
                ctrDate.Date = modInfo.DateCreated;
                ctrLength.SetValues(time.Item1, time.Item2);
                ctrSpeed.SetValues(modInfo.Speed, modInfo.Tempo);
                ctrBPM.SetValue(modInfo.EstimatedBPM);
                ctrTracker.SetTracker(modInfo.Tracker.ToStr());

                ctrStyleText.Text = modInfo.TrackStyle;
                ctrScenegroupText.Text = "";
                ctrComposerText.Text = "";
                ctrScenegroupText.Text = "";

                if (ctrStyle.SetStyle(modInfo.TrackStyle))
                {
                    ctrStyleText.Text = "";
                }

                ctrScenegroup.Reset();
                ctrComposer.Reset();
            }



            //lblTest.Text = modInfo.TrackStyle;

            //txtSamplesOrg.Text = modInfo.SampleText;
            //txtMessageOrg.Text = modInfo.SongText;
            //txtInstrumentsOrg.Text = modInfo.InstrumentText;

            //txtSamplesOrg.ClearUndo();
            //txtMessageOrg.ClearUndo();
            //txtInstrumentsOrg.ClearUndo();

            //if (isInDb)
            //{
            //    if (DB.LoadTrackInfo(guid) == false) return;

            //    var track = DB.Track;

            //    txtSamplesNew.Text = track.SampleText;
            //    txtMessageNew.Text = track.SongText;
            //    txtInstrumentsNew.Text = track.InstrumentText;

            //    //ctrFileInfoNew.Text = track.FileName;
            //    //ctrDateNew.Date = track.Date_created;

            //    //ctrLengthNew.ValueA = 0;
            //    //ctrLengthNew.ValueB = 0;

            //    //ctrSpeedNew.ValueA = track.Speed;
            //    //ctrSpeedNew.ValueB = track.Tempo;

            //    //ctrBPMNew.BPM = track.Bpm;

            //    //ctrStyleNew.SetStyle(track.Style?.Name);
            //    //ctrComposerNew.SetComposer(track.FK_composer_id);


            //}
        }
    }
}
