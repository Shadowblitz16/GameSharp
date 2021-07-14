using System.ComponentModel;
using System.Runtime.CompilerServices;
using GameSharp.Annotations;

namespace GameSharp
{
    public class GameConfig : INotifyPropertyChanged
    {
        private bool   _windowVSync;
        private string _windowTitle;
        private uint   _windowWidth;
        private uint   _windowHeight;
        private bool   _windowResizable;
        private bool   _windowFullscreen;


        public bool WindowVSync
        {
            get => _windowVSync;
            set
            {
                if (value == _windowVSync) return;
                _windowVSync = value;
                OnPropertyChanged();
            }
        }

        public string WindowTitle
        {
            get => _windowTitle;
            set
            {
                if (value == _windowTitle) return;
                _windowTitle = value;
                OnPropertyChanged();
            }
        }

        public uint WindowWidth
        {
            get => _windowWidth;
            set
            {
                if (value == _windowWidth) return;
                _windowWidth = value;
                OnPropertyChanged();
            }
        }

        public uint WindowHeight
        {
            get => _windowHeight;
            set
            {
                if (value == _windowHeight) return;
                _windowHeight = value;
                OnPropertyChanged();
            }
        }

        public bool WindowResizable
        {
            get => _windowResizable;
            set
            {
                if (value == _windowResizable) return;
                _windowResizable = value;
                OnPropertyChanged();
            }
        }

        public bool WindowFullscreen
        {
            get => _windowFullscreen;
            set
            {
                if (value == _windowFullscreen) return;
                _windowFullscreen = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}