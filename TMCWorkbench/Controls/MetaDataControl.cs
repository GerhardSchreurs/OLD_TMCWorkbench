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

            ctrStyle.Init();
            ctrComposer.Init();
            ctrScenegroup.Init();

            ctrStyleText.SwitchMode();
            ctrComposerText.SwitchMode();
            ctrScenegroupText.SwitchMode();
        }

        public void LoadData(ModInfo modInfo, TMCDatabase.DBModel.Track track, long duration)
        {
            if (modInfo == null) return;

            var time = Tools.MillisecondsConverter.ConvertToMinutesAndSeconds(duration);
            if (track != null)
            {
                var timeDB = Tools.MillisecondsConverter.ConvertToMinutesAndSeconds(track.Length);

                ctrFileInfo.Text = track.FileName;
                ctrTrackTitle.Text = track.TrackTitle;
                ctrDate.Date = track.Date_created;
                ctrLength.SetValues(timeDB.Item1, timeDB.Item2);
                ctrSpeed.SetValues(track.Speed, track.Tempo);
                ctrBPM.SetValue(track.Bpm);
                ctrStyle.SetStyle(track.FK_style_id);
                ctrStyleText.Text = track.StyleName;
                ctrComposer.SetComposer(track.FK_composer_id);
                ctrComposerText.Text = track.ComposerName;
                ctrScenegroup.SetScenegroup(track.FK_scenegroup_id);
                ctrScenegroupText.Text = track.ScenegroupName;

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
                ctrDate.Date = modInfo.DateCreated;
                ctrLength.SetValues(time.Item1, time.Item2);
                ctrSpeed.SetValues(modInfo.Speed, modInfo.Tempo);
                ctrBPM.SetValue(modInfo.EstimatedBPM);

                ctrStyleText.Text = modInfo.TrackStyle;
                ctrScenegroupText.Text = "";
                ctrComposerText.Text = "";
                ctrScenegroupText.Text = "";

                if (ctrStyle.SetStyle(modInfo.TrackStyle))
                {
                    ctrStyleText.Text = "";
                }
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
