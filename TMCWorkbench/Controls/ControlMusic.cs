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
        private AutoResetEvent _trackExportedEvent;

        private LibVLC _lib_EXPORT;
        private LibVLC _lib_TRACK;
        private MediaPlayer _player_EXPORT;
        private MediaPlayer _player_TRACK;

        private MediaPlayer _mediaPlayerA;
        private MediaPlayer _mediaPlayerB;
        public Media MediaTrack;
        private Media _mediaExporter;

        private string _pathCache = @"c:\Tracks\Cache\temp.wav";
        private string _sout = ":sout=#transcode{acodec=s16l,channels=2,ab=128,samplerate=44100}:standard{access=file,mux=wav,dst=\"c:\\Tracks\\Cache\\temp.wav\"}";

        public ControlMusic()
        {
            InitializeComponent();

            _trackExportedEvent = new AutoResetEvent(false);
        }

        public void Init()
        {
            Core.Initialize();

            _lib_EXPORT = new LibVLC();
            _lib_TRACK = new LibVLC();
            _player_EXPORT = new MediaPlayer(_lib_EXPORT);
            _player_TRACK = new MediaPlayer(_lib_TRACK);

            trackVolume.Value = Properties.Settings.Default.PlayerVolume;
            trackVolume.ValueChanged += Handle_TrackVolume_ValueChanged;

            //TODO: Save settings on quit / unload
        }

        private string _path;

        private static ManualResetEvent resetEvent = new ManualResetEvent(false);

        public long Duration;

        public async Task ProcessAndPlay(string path)
        {
            Debug.WriteLine($"ProcessAndPlay {path}");

            await _taskLock.WaitAsync();
            var fileName = Path.GetFileNameWithoutExtension(path);
            var cachePath = $@"{C.PATHCACHE}\{fileName}.wav";
            var sout = $":sout=#transcode{{acodec=s16l,channels=2,ab=128,samplerate=44100}}:standard{{access=file,mux=wav,dst=\"{cachePath}\"}}";

            Debug.WriteLine($"_taskLock set");

            try
            {
                Debug.WriteLine($"in try");

                //Stop and relase media player
                //_player_TRACK.Stopped -= Handle_TRACK_Stopped;
                //_player_TRACK.EncounteredError -= Handle_TRACK_EncounteredError;

                if (_player_TRACK.IsPlaying)
                {
                    Debug.WriteLine("Track is playing");
                    ThreadPool.QueueUserWorkItem(arg =>
                    {
                        _player_TRACK.Stop();
                        _player_TRACK.Media = null;

                        resetEvent.Set();
                    });

                    Debug.WriteLine("Track is playing -> waiting");
                    resetEvent.WaitOne();
                    Debug.WriteLine("Track is playing -> DONE waiting");
                }

                Debug.WriteLine($"removed position changed");
                _player_TRACK.PositionChanged -= Handle_TRACK_PositionChanged;

                var mediaExport = new Media(_lib_EXPORT, path, FromType.FromPath);
                mediaExport.AddOption(sout);

                _player_EXPORT.Stopped += Handle_EXPORT_Stopped;
                _player_EXPORT.EncounteredError += Handle_EXPORT_EncounteredError;
                _player_EXPORT.Media = mediaExport;
                _player_EXPORT.Play();

                Debug.WriteLine("EXPORTING ->");
                _trackExportedEvent.WaitOne();
                Debug.WriteLine("EXPORTING -> DONE");
                _player_EXPORT.Stopped -= Handle_EXPORT_Stopped;
                _player_EXPORT.EncounteredError -= Handle_EXPORT_EncounteredError;
                //media.Dispose();

                var mediaTrack = new Media(_lib_TRACK, cachePath, FromType.FromPath);
                await mediaTrack.Parse(MediaParseOptions.ParseLocal).ConfigureAwait(true);
                lblTimeTotal.Do(() => lblTimeTotal.Text = DurationToTimeString(mediaTrack.Duration));
                Duration = mediaTrack.Duration;
                _player_TRACK.PositionChanged += Handle_TRACK_PositionChanged;
                _player_TRACK.Media = mediaTrack;
                _player_TRACK.Play();
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
            }

            Debug.WriteLine($"ProcessAndPlay {path} => done");
        }


        public async Task ProcessAndPlayOLD(string path)
        {
            await _taskLock.WaitAsync();

            try
            {
                _player_TRACK.PositionChanged -= Handle_TRACK_PositionChanged;
                //_mediaPlayerTrack.Stopped -= Handle_mediaPlayerTrackInitial_Stopped;

                //Stop Exporter
                //if (_mediaPlayerExporter != null &&  _mediaPlayerExporter.IsPlaying)
                //{
                //    ThreadPool.QueueUserWorkItem(arg =>
                //    {
                //        _mediaPlayerExporter.Stop();
                //        _mediaPlayerExporter.Media = null;
                //        resetEvent.Set();
                //    });

                //    resetEvent.WaitOne();
                //}

                //Stop Track
                if (_player_TRACK != null && _player_TRACK.IsPlaying)
                {
                    ThreadPool.QueueUserWorkItem(arg =>
                    {
                        _player_TRACK.Stop();
                        _player_TRACK.Media = null;

                        resetEvent.Set();
                    });

                    resetEvent.WaitOne();
                }


                //Both mediaplayers should be in stopped state.

                //Delete cached file, to be sure
                File.Delete(_pathCache);

                //Export to wave
                _mediaExporter = new Media(_lib_EXPORT, path, FromType.FromPath);
                _mediaExporter.AddOption(_sout);
                _player_EXPORT.Media = _mediaExporter;
                _player_EXPORT.Stopped += Handle_EXPORT_Stopped;
                _player_EXPORT.EncounteredError += Handle_EXPORT_EncounteredError;
                _player_EXPORT.Play();

                _trackExportedEvent.WaitOne();

                ////This will fire after processing
                _player_EXPORT.Stopped -= Handle_EXPORT_Stopped;
                _player_EXPORT.EncounteredError -= Handle_EXPORT_Stopped;
                _player_EXPORT = null;
                _mediaExporter = null;

                if (MediaTrack != null) MediaTrack.Dispose();

                //Now, we can play the track!
                //https://github.com/ZeBobo5/Vlc.DotNet/issues/542

                MediaTrack = new Media(_lib_EXPORT, _pathCache, FromType.FromPath);
                await MediaTrack.Parse(MediaParseOptions.ParseLocal).ConfigureAwait(true);
                lblTimeTotal.Do(() => lblTimeTotal.Text = DurationToTimeString(MediaTrack.Duration));
                Duration = MediaTrack.Duration;
                //EventInvoker.RaiseOnTrackProcessed(this, MediaTrack.Duration);

                _player_TRACK.Media = MediaTrack;
                MediaTrack.Dispose();
                _player_TRACK.PositionChanged -= Handle_TRACK_PositionChanged;
                _player_TRACK.PositionChanged += Handle_TRACK_PositionChanged;
                _player_TRACK.Play();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GpsControl.StartAsync() : {ex}");
            }
            finally
            {
                _taskLock.Release();
            }

        }

        public void ProcessAndPlayOLDER(string path)
        {
            //_path = path;

            ////Unwire
            //_mediaPlayerTrack.PositionChanged -= Handle_mediaPlayer_PositionChanged;
            //_mediaPlayerTrack.Stopped -= Handle_mediaPlayerTrackInitial_Stopped;

            //if (_mediaPlayerTrack.IsPlaying == false)
            //{
            //    Handle_mediaPlayerTrackInitial_Stopped(null, null);
            //    return;
            //}

            //_mediaPlayerTrack.Stopped += Handle_mediaPlayerTrackInitial_Stopped;

            //ThreadPool.QueueUserWorkItem(_ => _mediaPlayerTrack.Stop());
        }

        private void Handle_mediaPlayerTrackInitial_Stopped(object sender, EventArgs e)
        {
            _player_TRACK.Stopped -= Handle_mediaPlayerTrackInitial_Stopped;
            _player_EXPORT.Stopped -= Handle_mediaPlayerExporterInitial_Stopped;

            if (_player_EXPORT.IsPlaying == false)
            {
                Handle_mediaPlayerExporterInitial_Stopped(null, null);
                return;
            }

            //Stop processor
            _player_EXPORT.Stopped += Handle_mediaPlayerExporterInitial_Stopped;

            ThreadPool.QueueUserWorkItem(_ => _player_EXPORT.Stop());
        }

        private void Handle_mediaPlayerExporterInitial_Stopped(object sender, EventArgs e)
        {
            _player_EXPORT.Stopped -= Handle_mediaPlayerExporterInitial_Stopped;
            
            //Both mediaplayers should be in stopped state.
            if (_mediaExporter != null) _mediaExporter.Dispose();
            if (MediaTrack != null) MediaTrack.Dispose();

            //Delete cached file, to be sure
            File.Delete(_pathCache);

            //Export to wave
            _mediaExporter = new Media(_lib_EXPORT, _path, FromType.FromPath);
            _mediaExporter.AddOption(_sout);
            _player_EXPORT.Media = _mediaExporter;
            _player_EXPORT.Stopped += Handle_EXPORT_Stopped;
            _player_EXPORT.EncounteredError += Handle_EXPORT_EncounteredError;
            _player_EXPORT.Play();
        }

        private void Handle_EXPORT_EncounteredError(object sender, EventArgs e)
        {
            Debug.WriteLine(e);
        }


        private async void Handle_EXPORT_Stopped(object sender, EventArgs e)
        {
            _trackExportedEvent.Set();

            ////This will fire after processing
            //_mediaPlayerExporter.Stopped -= Handle_mediaPlayerExporter_Stopped;

            ////Now, we can play the track!
            ////https://github.com/ZeBobo5/Vlc.DotNet/issues/542

            //MediaTrack = new Media(_libVLC, _path, FromType.FromPath);
            //await MediaTrack.Parse(MediaParseOptions.ParseLocal).ConfigureAwait(true);
            //lblTimeTotal.Do(() => lblTimeTotal.Text = DurationToTimeString(MediaTrack.Duration));

            //EventInvoker.RaiseOnTrackProcessed(this, MediaTrack.Duration);

            //_mediaPlayerTrack.Media = MediaTrack;
            //_mediaPlayerTrack.PositionChanged -= Handle_mediaPlayer_PositionChanged;
            //_mediaPlayerTrack.PositionChanged += Handle_mediaPlayer_PositionChanged;
            //_mediaPlayerTrack.Play();

        }

        private void Handle_TrackVolume_ValueChanged(object sender, EventArgs e)
        {
            _player_TRACK.Volume = trackVolume.Value;

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

            trackPosition.Do(() => trackPosition.Value = pos);
            lblTime.Do(() => lblTime.Text = DurationToTimeString((long)(seconds)));
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            _player_TRACK.Play();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            _player_TRACK.Pause();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _player_TRACK.Stop();
        }

        private void TrackPosition_MouseDown(object sender, MouseEventArgs e)
        {
            _player_TRACK.PositionChanged -= Handle_TRACK_PositionChanged;
            MoveTrackBarToMouseClickLocation(e.X);
        }

        private void TrackPosition_MouseUp(object sender, MouseEventArgs e)
        {
            var f = (float)trackPosition.Value / 1000;

            ThreadPool.QueueUserWorkItem(arg =>
            {
                _player_TRACK.PositionChanged -= Handle_TRACK_PositionChanged;
                _player_TRACK.Position = f;
                _player_TRACK.PositionChanged += Handle_TRACK_PositionChanged;
            });
        }
    }


    //public partial class ControlMusicX : UserControl
    //{
    //    private LibVLC _libVLC;
    //    private MediaPlayer _mediaPlayer;
    //    private MediaPlayer _mediaProcessor;
    //    public Media Media;

    //    public ControlMusicX()
    //    {
    //        InitializeComponent();
    //    }

    //    public void Init()
    //    {
    //        Core.Initialize();

    //        _libVLC = new LibVLC();
    //        _mediaPlayer = new MediaPlayer(_libVLC);
    //        _mediaProcessor = new MediaPlayer(_libVLC);

    //        trackVolume.Value = Properties.Settings.Default.PlayerVolume;
    //        trackVolume.ValueChanged += Handle_TrackVolume_ValueChanged;

    //        Wire();

    //        //TODO: Save settings on quit / unload
    //    }

    //    private void Handle_TrackVolume_ValueChanged(object sender, EventArgs e)
    //    {
    //        _mediaPlayer.Volume = trackVolume.Value;

    //        Properties.Settings.Default.PlayerVolume = trackVolume.Value;
    //        Properties.Settings.Default.Save();
    //    }

    //    private string DurationToTimeString(long duration)
    //    {
    //        var timeSpan = TimeSpan.FromMilliseconds(duration);
    //        return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    //    }

    //    private void MoveTrackBarToMouseClickLocation(int mouseX)
    //    {
    //        // Jump to the clicked location

    //        double dblValue;
    //        dblValue = ((double)mouseX / (double)trackPosition.Width) * (trackPosition.Maximum - trackPosition.Minimum);
    //        trackPosition.Value = Convert.ToInt32(dblValue);
    //    }


    //    private void Wire()
    //    {
    //        _mediaPlayer.PositionChanged += Handle_mediaPlayer_PositionChanged;
    //    }

    //    private async void Handle_mediaProcessor_Stopped(object sender, EventArgs e)
    //    {
    //        Debug.WriteLine($"Handle_mediaProcessor_Stopped. {DateTime.Now.ToString()}");

    //        await Play();
    //    }

    //    private void UnWire()
    //    {
    //        _mediaPlayer.PositionChanged -= Handle_mediaPlayer_PositionChanged;
    //    }

    //    public void ProcessAndPlay(string path)
    //    {
    //        Process(path);
    //    }

    //    private async Task Process(string path)
    //    {
    //        UnWire();
    //        ThreadPool.QueueUserWorkItem(_ => _mediaPlayer.Stop());

    //        Thread.Sleep(100);

    //        File.Delete("c:\\Tracks\\Cache\\temp.wav");

    //        if (File.Exists(path) == false)
    //        {
    //            MessageBox.Show($"File does not exist: {path}");
    //            return;
    //        }

    //        _mediaProcessor.Stopped -= Handle_mediaProcessor_Stopped;
    //        ThreadPool.QueueUserWorkItem(_ => _mediaProcessor.Stop());

    //        Thread.Sleep(100);

    //        if (Media != null) Media.Dispose();

    //        Media = new Media(_libVLC, path, FromType.FromPath);
    //        Media.AddOption(":sout=#transcode{acodec=s16l,channels=2,ab=128,samplerate=44100}:standard{access=file,mux=wav,dst=\"c:\\Tracks\\Cache\\temp.wav\"}");
    //        //Media.AddOption(":sout=#transcode{acodec=mp3,ab=128}:standard{access=file,mux=dummy,dst=\"c:\\Tracks\\Cache\\temp.mp3\"}");

    //        _mediaProcessor.Media = Media;
    //        _mediaProcessor.Stopped += Handle_mediaProcessor_Stopped;
    //        _mediaProcessor.Play();
    //        Debug.WriteLine($"About to play {DateTime.Now.ToString()}");
    //    }

    //    private async Task Play()
    //    {
    //        //MediaPlayer.Stop() Might DEADLOCK, see description in Stop() method.
    //        //https://github.com/ZeBobo5/Vlc.DotNet/issues/542
    //        ThreadPool.QueueUserWorkItem(_ => _mediaPlayer.Stop());

    //        Media = new Media(_libVLC, "c:\\Tracks\\Cache\\temp.wav", FromType.FromPath);
    //        await Media.Parse(MediaParseOptions.ParseLocal).ConfigureAwait(true);
    //        lblTimeTotal.Do(() => lblTimeTotal.Text = DurationToTimeString(Media.Duration));
    //        _mediaPlayer.Media = Media;
    //        Wire();
    //        _mediaPlayer.Play();
    //    }

    //    public async Task ProcessWave(string path)
    //    {
    //        _mediaProcessor.Stopped -= Handle_mediaProcessor_Stopped;
    //        ThreadPool.QueueUserWorkItem(_ => _mediaProcessor.Stop());

    //        if (Media != null)
    //        {
    //            Media.Dispose();
    //        }

    //        Media = new Media(_libVLC, path, FromType.FromPath);
    //        Media.AddOption(":sout=#transcode{acodec=s16l,channels=2,ab=128,samplerate=44100}:standard{access=file,mux=wav,dst=\"c:\\Tracks\\Cache\\temp.wav\"}");
    //        //Media.AddOption(":sout=#transcode{acodec=mp3,ab=128}:standard{access=file,mux=dummy,dst=\"c:\\Tracks\\Cache\\temp.mp3\"}");
    //        _mediaProcessor.Media = Media;
    //        _mediaProcessor.Stopped += Handle_mediaProcessor_Stopped;
    //        _mediaProcessor.Volume = 20;
    //        _mediaProcessor.Play();

    //        Debug.WriteLine("MusicControl LoadTrack STOP");
    //    }

    //    public async Task LoadTrack(string path)
    //    {
    //        Debug.WriteLine("MusicControl LoadTrack START");

    //        //MediaPlayer.Stop() Might DEADLOCK, see description in Stop() method.
    //        //https://github.com/ZeBobo5/Vlc.DotNet/issues/542
    //        ThreadPool.QueueUserWorkItem(_ => _mediaPlayer.Stop());

    //        Debug.WriteLine("MusicControl DINGES");

    //        UnWire();
    //        Debug.WriteLine("MusicControl unwired");

    //        if (Media != null)
    //        {
    //            Media.Dispose();
    //        }

    //        Media = new Media(_libVLC, path, FromType.FromPath);
    //        Debug.WriteLine(" MusicControl Parse START");
    //        await Media.Parse(MediaParseOptions.ParseLocal).ConfigureAwait(true);
    //        Debug.WriteLine(" MusicControl Parse STOP");

    //        lblTimeTotal.Do(() => lblTimeTotal.Text = DurationToTimeString(Media.Duration));

    //        _mediaPlayer.Media = Media;
    //        Wire();
    //        _mediaPlayer.Play();

    //        Debug.WriteLine("MusicControl LoadTrack STOP");
    //    }

    //    private void Handle_mediaPlayer_PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
    //    {
    //        var pos = (int)(e.Position * 1000);

    //        if (pos > 1000) { pos = 1000; };
    //        if (pos < 0) { pos = 0; };

    //        var seconds = (Media.Duration * e.Position);

    //        trackPosition.Do(() => trackPosition.Value = pos);
    //        lblTime.Do(() => lblTime.Text = DurationToTimeString((long)(seconds)));
    //    }

    //    private void BtnPlay_Click(object sender, EventArgs e)
    //    {
    //        _mediaPlayer.Play();
    //    }

    //    private void BtnPause_Click(object sender, EventArgs e)
    //    {
    //        _mediaPlayer.Pause();
    //    }

    //    private void BtnStop_Click(object sender, EventArgs e)
    //    {
    //        _mediaPlayer.Stop();
    //    }

    //    private void TrackPosition_MouseDown(object sender, MouseEventArgs e)
    //    {
    //        _mediaPlayer.PositionChanged -= Handle_mediaPlayer_PositionChanged;
    //        MoveTrackBarToMouseClickLocation(e.X);
    //    }

    //    private void TrackPosition_MouseUp(object sender, MouseEventArgs e)
    //    {
    //        _mediaPlayer.PositionChanged -= Handle_mediaPlayer_PositionChanged;
    //        var f = (float)trackPosition.Value / 1000;
    //        _mediaPlayer.Position = f;
    //        _mediaPlayer.PositionChanged += Handle_mediaPlayer_PositionChanged;
    //    }
    //}
}
