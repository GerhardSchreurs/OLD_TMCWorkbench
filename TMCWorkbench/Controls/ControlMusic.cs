using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using TMCWorkbench;
using System.Diagnostics;
using TMCWorkbench.Events;
using System.Threading;
using System.IO;

namespace TMCWorkbench.Controls
{
    public partial class ControlMusic : UserControl
    {
        private static SemaphoreSlim _taskLock = new SemaphoreSlim(1, 1);
        private static ManualResetEvent resetEvent = new ManualResetEvent(false);
        private LibVLC _libVlc;
        private MediaPlayer _mediaPlayer;
        public Media MediaTrack;

        private string _pathCache = @"c:\Tracks\Cache\temp.wav";


        public ControlMusic()
        {
            InitializeComponent();
        }

        public void Init()
        {
            Core.Initialize();

            _libVlc = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVlc);

            trackVolume.Value = Properties.Settings.Default.PlayerVolume;
            trackVolume.ValueChanged += Handle_TrackVolume_ValueChanged;

            //TODO: Save settings on quit / unload
        }

        private string _path;

        public long Duration;


        public void PauseOrPlay()
        {
            if (_mediaPlayer == null) return;

            if (_mediaPlayer.IsPlaying)
                _mediaPlayer.Pause();
            else
                _mediaPlayer.Play();
        }

        public async Task ProcessAndPlay(string path, bool autoPlay = true)
        {
            Cursor.Current = Cursors.WaitCursor;

            Debug.WriteLine($"ProcessAndPlay {path}");

            await _taskLock.WaitAsync();

            var fileName = Path.GetFileNameWithoutExtension(path);
            var cachePath = $@"{C.PATHTRACKCACHE}\{fileName}.wav";

            Debug.WriteLine($"_taskLock set");

            try
            {
                Debug.WriteLine($"in try");

                if (autoPlay) StopWait();

                await AudioLibrary.Lib.ExportToWaveAsync(path, cachePath);

                if (autoPlay == false) return;

                var mediaTrack = new Media(_libVlc, cachePath, FromType.FromPath);
                await mediaTrack.Parse(MediaParseOptions.ParseLocal).ConfigureAwait(true);
                lblTimeTotal.Do(() => lblTimeTotal.Text = DurationToTimeString(mediaTrack.Duration));
                Duration = mediaTrack.Duration;

                _mediaPlayer.PositionChanged += Handle_TRACK_PositionChanged;
                _mediaPlayer.Media = mediaTrack;
                _mediaPlayer.Play();
                //cache.Dispose();
                Debug.WriteLine("== finito ==");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Debug.WriteLine($"GpsControl.StartAsync() : {ex}");
            }
            finally
            {
                _taskLock.Release();
                Debug.WriteLine($"ProcessAndPlay {path} => release");
                Cursor.Current = Cursors.Default;
            }

            Debug.WriteLine($"ProcessAndPlay {path} => done");
        }

        public void StopWait()
        {
            ThreadPool.QueueUserWorkItem(arg => Stop());
            resetEvent.WaitOne();

            _mediaPlayer.Media = null;
        }

        public void Stop()
        {


            if (_mediaPlayer.IsPlaying)
            {
                Debug.WriteLine("STOP : Track is playing");
                _mediaPlayer.Stop();
                _mediaPlayer.Media = null;
                Debug.WriteLine("STOP : Track is playing -> waiting");
                resetEvent.WaitOne();
                Debug.WriteLine("STOP : Track is playing -> DONE waiting");
            }

            Debug.WriteLine($"STOP : removed position changed");
            _mediaPlayer.PositionChanged -= Handle_TRACK_PositionChanged;
            Debug.WriteLine($"STOP : removed event handler");

            SetTrackPosition(0);
            Debug.WriteLine($"STOP : SetTrackPosition");

            SetTimeLabel(0);
            Debug.WriteLine($"STOP : SetTimeLabel");


            resetEvent.Set();
            //TODO?
            //_player_TRACK.Stopped -= Handle_TRACK_Stopped;
            //_player_TRACK.EncounteredError -= Handle_TRACK_EncounteredError;
        }

        private void Handle_TrackVolume_ValueChanged(object sender, EventArgs e)
        {
            _mediaPlayer.Volume = trackVolume.Value;

            Properties.Settings.Default.PlayerVolume = trackVolume.Value;
            Properties.Settings.Default.Save();
        }

        private string DurationToTimeString(long duration)
        {
            var timeSpan = TimeSpan.FromMilliseconds(duration);
            return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }

        private void MoveTrackBarToMouseClickLocation(int mouseX)
        {
            // Jump to the clicked location

            double dblValue;
            dblValue = ((double)mouseX / (double)trackPosition.Width) * (trackPosition.Maximum - trackPosition.Minimum);
            trackPosition.Value = Convert.ToInt32(dblValue);
        }

        private void Handle_TRACK_PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            var pos = (int)(e.Position * 1000);

            if (pos > 1000) { pos = 1000; };
            if (pos < 0) { pos = 0; };

            var seconds = (Duration * e.Position);

            SetTrackPosition(pos);
            SetTimeLabel(seconds);
        }

        void SetTrackPosition(int position)
        {
            trackPosition.Do(() => trackPosition.Value = position);
        }


        void SetTimeLabel(int seconds)
        {
            lblTime.Do(() => lblTime.Text = DurationToTimeString(seconds));
        }

        void SetTimeLabel(float seconds)
        {
            lblTime.Do(() => lblTime.Text = DurationToTimeString((long)(seconds)));
        }


        private void BtnPlay_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Play();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Pause();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Stop();
        }

        private void TrackPosition_MouseDown(object sender, MouseEventArgs e)
        {
            _mediaPlayer.PositionChanged -= Handle_TRACK_PositionChanged;
            MoveTrackBarToMouseClickLocation(e.X);
        }

        private void TrackPosition_MouseUp(object sender, MouseEventArgs e)
        {
            var f = (float)trackPosition.Value / 1000;

            ThreadPool.QueueUserWorkItem(arg =>
            {
                _mediaPlayer.PositionChanged -= Handle_TRACK_PositionChanged;
                _mediaPlayer.Position = f;
                _mediaPlayer.PositionChanged += Handle_TRACK_PositionChanged;
            });
        }
    }
}
