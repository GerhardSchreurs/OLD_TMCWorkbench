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

namespace TMCWorkbench.Controls
{
    public partial class MusicControl : UserControl
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        public Media Media;

        public MusicControl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            Core.Initialize();

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            trackVolume.Value = Properties.Settings.Default.PlayerVolume;
            trackVolume.ValueChanged += Handle_TrackVolume_ValueChanged;

            Wire();

            //TODO: Save settings on quit / unload
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

        private void Wire()
        {
            _mediaPlayer.PositionChanged += Handle_mediaPlayer_PositionChanged;
        }

        private void UnWire()
        {
            _mediaPlayer.PositionChanged -= Handle_mediaPlayer_PositionChanged;
        }

        public async Task LoadTrack(string path)
        {
            Debug.WriteLine("MusicControl LoadTrack START");
            UnWire();
            Debug.WriteLine("MusicControl unwired");

            //MediaPlayer.Stop() Might DEADLOCK, see description in Stop() method.
            //https://github.com/ZeBobo5/Vlc.DotNet/issues/542
            ThreadPool.QueueUserWorkItem(_ => _mediaPlayer.Stop());
            Debug.WriteLine("MusicControl DINGES");

            if (Media != null)
            {
                Media.Dispose();
            }

            Media = new Media(_libVLC, path, FromType.FromPath);
            Debug.WriteLine(" MusicControl Parse START");
            await Media.Parse(MediaParseOptions.ParseLocal).ConfigureAwait(true);
            Debug.WriteLine(" MusicControl Parse STOP");

            lblTimeTotal.Do(() => lblTimeTotal.Text = DurationToTimeString(Media.Duration));

            _mediaPlayer.Media = Media;
            Wire();
            _mediaPlayer.Play();

            Debug.WriteLine("MusicControl LoadTrack STOP");
        }

        private void Handle_mediaPlayer_PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            var pos = (int)(e.Position * 1000);

            if (pos > 1000) { pos = 1000; };
            if (pos < 0) { pos = 0; };

            var seconds = (Media.Duration * e.Position);

            trackPosition.Do(() => trackPosition.Value = pos);
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
            _mediaPlayer.PositionChanged -= Handle_mediaPlayer_PositionChanged;
        }

        private void TrackPosition_MouseUp(object sender, MouseEventArgs e)
        {
            _mediaPlayer.PositionChanged -= Handle_mediaPlayer_PositionChanged;
            var f = (float)trackPosition.Value / 1000;
            _mediaPlayer.Position = f;
            _mediaPlayer.PositionChanged += Handle_mediaPlayer_PositionChanged;
        }
    }
}
