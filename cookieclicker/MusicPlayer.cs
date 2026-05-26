// MusicPlayer.cs
using System;
using System.Security.RightsManagement;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace CookieClicker
{
    internal sealed class MusicPlayer : IDisposable
    {
        private readonly MediaPlayer _p = new MediaPlayer();
        private readonly MediaPlayer _fancyClickPlayer = new MediaPlayer();
        private readonly MediaPlayer _pawClickPlayer = new MediaPlayer();

        public MusicPlayer()
        {

            var fancyClickFull = System.IO.Path.GetFullPath("Assets/Sounds/Effects/fancyClick.wav");
            var fancyClickUri = new Uri(fancyClickFull, UriKind.Absolute);
            _fancyClickPlayer.Open(fancyClickUri);
            _fancyClickPlayer.Volume = 0.5;

            var pawClickFull = System.IO.Path.GetFullPath("Assets/Sounds/Effects/pawClick.wav");
            var pawClickUri = new Uri(pawClickFull, UriKind.Absolute);
            _pawClickPlayer.Open(pawClickUri);
            _pawClickPlayer.Volume = 0.25;

            var full = System.IO.Path.GetFullPath("Assets/Sounds/Music/meow.wav");
            var uri = new Uri(full, UriKind.Absolute);
            _p.Open(uri);
            _p.MediaEnded += (s, e) => _p.Position = TimeSpan.Zero;
            _p.Volume = 0.25;
        }

        public void PlayFancyClick()
        {
            _fancyClickPlayer.Position = TimeSpan.Zero;
            _fancyClickPlayer.Play();
        }

        public void PlayPawClick()
        {
            _pawClickPlayer.Position = TimeSpan.Zero;
            _pawClickPlayer.Play();
        }

        public void Play() => _p.Play();
        public void Pause() => _p.Pause();
        public void Stop()
        {
            _p.Stop();
            _p.Position = TimeSpan.Zero;
        }
        public void Dispose() => _p.Close();
    }
}