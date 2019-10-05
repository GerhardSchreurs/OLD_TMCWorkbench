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
using Extensions;

namespace TMCWorkbench.Controls
{
    public partial class MusicControl : UserControl
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        public MusicControl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            Core.Initialize();

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            _mediaPlayer.PositionChanged += _mediaPlayer_PositionChanged;
        }

        public void LoadTrack(string path)
        {
            _mediaPlayer.Stop();
            var media = new Media(_libVLC, path, FromType.FromPath);
            _mediaPlayer.Media = media;
            _mediaPlayer.Play();
        }

        private void _mediaPlayer_PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            var pos = (int)(e.Position * 1000) + 1;

            if (pos > 1) { pos = 1; };
            if (pos < 0) { pos = 0; };

            trackPosition.PerformSafely(() => trackPosition.Value = pos);
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
            _mediaPlayer.PositionChanged -= _mediaPlayer_PositionChanged;
        }

        private void TrackPosition_MouseUp(object sender, MouseEventArgs e)
        {
            _mediaPlayer.PositionChanged -= _mediaPlayer_PositionChanged;
            var f = (float)trackPosition.Value / 1000;
            _mediaPlayer.Position = f;
            _mediaPlayer.PositionChanged += _mediaPlayer_PositionChanged;
        }
    }
}
