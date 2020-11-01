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
using Extensions;

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

                ctrFileInfo.Do(() => ctrFileInfo.Text = track.FileName);
                ctrTrackTitle.Do(() => ctrTrackTitle.Text = track.TrackTitle);
                ctrDate.Do(() => ctrDate.Date = track.Date_created);
                ctrLength.Do(() => ctrLength.SetValues(timeDB.Item1, timeDB.Item2));
                ctrSpeed.Do(() => ctrSpeed.SetValues(track.Speed, track.Tempo));
                ctrBPM.Do(() => ctrBPM.SetValue(track.Bpm));
                ctrStyle.Do(() => ctrStyle.SetStyle(track.FK_style_id));
                ctrStyleText.Do(() => ctrStyleText.Text = track.StyleName);
                ctrComposer.Do(() => ctrComposer.SetComposer(track.FK_composer_id));
                ctrComposerText.Do(() => ctrComposerText.Text = track.ComposerName);
                ctrScenegroup.Do(() => ctrScenegroup.SetScenegroup(track.FK_scenegroup_id));
                ctrScenegroupText.Do(() => ctrScenegroupText.Text = track.ScenegroupName);

                ctrFileInfo.Do(() => ctrFileInfo.Original = modInfo.FileName);
                ctrDate.Do(() => ctrDate.Original = modInfo.DateCreated);
                ctrLength.Do(() => ctrLength.SetValuesOriginal(time.Item1, time.Item2));
                ctrSpeed.Do(() => ctrSpeed.SetValuesOriginal(modInfo.Speed, modInfo.Tempo));
                ctrBPM.Do(() => ctrBPM.SetValueOriginal(modInfo.EstimatedBPM));
            }
            else
            {
                //NOT IN DB, ONLY LOAD FROM DISK
                ctrFileInfo.Do(() => ctrFileInfo.Text = modInfo.FileName);
                ctrDate.Do(() => ctrDate.Date = modInfo.DateCreated);
                ctrLength.Do(() => ctrLength.SetValues(time.Item1, time.Item2));
                ctrSpeed.Do(() => ctrSpeed.SetValues(modInfo.Speed, modInfo.Tempo));
                ctrBPM.Do(() => ctrBPM.SetValue(modInfo.EstimatedBPM));

                ctrStyleText.Do(() => ctrStyleText.Text = modInfo.TrackStyle);
                ctrScenegroupText.Do(() => ctrScenegroupText.Text = "");
                ctrComposerText.Do(() => ctrComposerText.Text = "");
                ctrScenegroupText.Do(() => ctrScenegroupText.Text = "");

                ctrStyle.Do(() =>
                {
                    if (ctrStyle.SetStyle(modInfo.TrackStyle))
                    {
                        ctrStyleText.Text = "";
                    }
                });
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
