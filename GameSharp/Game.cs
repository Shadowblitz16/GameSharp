using System;
using System.Numerics;
using ImGuiNET;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using SharpDX.Text;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.SPIRV;
using Veldrid.StartupUtilities;
using WindowState = OpenTK.Windowing.Common.WindowState;

namespace GameSharp
{
    public abstract class Game : IDisposable
    {
        private float _lastDelta;
        private GameConfig _config;
        private GameWindow _window;

        public void Run(GameConfig config)
        {
            _config = config;
            _config.PropertyChanged += (sender, args) =>
            {
                switch (args.PropertyName)
                {
                    case nameof(config.WindowVSync):
                        _window.VSync = config.WindowVSync ? VSyncMode.On : VSyncMode.Off;
                        break;
                    case nameof(config.WindowTitle):
                        _window.Title = config.WindowTitle;
                        break;
                    case nameof(config.WindowWidth):
                    case nameof(config.WindowHeight):
                        if (!_config.WindowResizable) break;
                        _window.Size = new Vector2i((int)config.WindowWidth,(int)config.WindowHeight);
                        break;   
                    case nameof(config.WindowFullscreen):
                        _window.WindowState = config.WindowFullscreen ? WindowState.Fullscreen : WindowState.Normal;
                        break;
                        
                }
            };
            
            var gws = new GameWindowSettings()
            {
                UpdateFrequency = 60,
                RenderFrequency = 60,
            };

            var nws = new NativeWindowSettings()
            {
                Size        = new Vector2i((int)config.WindowWidth,(int)config.WindowHeight),
                Title       = config.WindowTitle,
                WindowState = config.WindowFullscreen ? WindowState.Fullscreen : WindowState.Normal,
            };

            _window = new GameWindow(gws, nws);
            _window.Load += () =>
            {
                _lastDelta = 0.0f;
                OnLoad();
            };

            _window.UpdateFrame += eventArgs =>
            {
                _lastDelta = (float) eventArgs.Time;
                OnStep();
            };
                
            _window.RenderFrame += eventArgs =>
            {
                _lastDelta = (float) eventArgs.Time;
                OnDraw();
            };

            _window.Closed += () =>
            {
                OnQuit();
            };
            _window.Run();
        }
        public virtual void OnLoad()
        {
        }
        public virtual void OnStep()
        {
        }
        public virtual void OnDraw()
        {
        }
        public virtual void OnQuit()
        {
        }

        public void Dispose()
        {
            _window.Close();
        }
    }
}