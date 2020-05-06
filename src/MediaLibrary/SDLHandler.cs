using System;
using System.Collections.Generic;
using SDL2;
using Bound.Event;
using Bound.Event.Application;
using Bound.Graphics;
using Bound.Utilities.Configuration;
using Bound.Utilities.Timing;

namespace Bound.MediaLibrary
{
    public class SDLHandler : ISDLHandler
    {
        private IConfiguration _config;
        private IWindow _window;
        private IRenderer _renderer;
        private ISDLEventParser _eventParser;
        private ITimer _timer;

        public bool IsRunning { get; private set; }
        public double DeltaTime => _timer.DeltaTime;
        public EventsCollection Events => _eventParser.Events;

        public SDLHandler(IConfiguration config)
        {
            _config = config;
            _eventParser = new SDLEventParser();
            _timer = new Timer();
        }

        public void Initialize()
        {
            _config.ThrowIfInvalidConfiguration();

            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            _window = new Window("Bound", _config.WindowWidth, _config.WindowHeight);
            _window.Create();

            _renderer = new Renderer(_window.WindowHandler);
            _renderer.Create();

            IsRunning = _window.WindowHandler != IntPtr.Zero && _renderer.RendererHandler != IntPtr.Zero;
        }

        public void Quit()
        {
            _renderer?.Destroy();
            _window?.Destroy();

            IsRunning = false;
            
            SDL.SDL_Quit();
        }

        public void PollEvents() => _eventParser.PollEvents();
        public void ClearEvents() => _eventParser.ClearEvents();
        public void UpdateTime() => _timer.UpdateTime();
        public void Draw(IEnumerable<IDrawable> drawables) => _renderer.Draw(drawables);
    }
}