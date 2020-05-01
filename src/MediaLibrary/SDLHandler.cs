using System;
using System.Collections.Generic;
using SDL2;
using Bound.Event;
using Bound.Event.Application;
using Bound.Graphics;
using Bound.Utilities.Configuration;

namespace Bound.MediaLibrary
{
    public class SDLHander : ISDLHandler
    {
        private IConfiguration _config;
        private IWindow _window;
        private IRenderer _renderer;
        private ISDLEventParser _eventParser;

        public bool IsRunning { get; private set; }

        public IEnumerable<IBoundEvent> Events
        {
            get
            {
                return _eventParser.GetEvents();
            }
        }

        public SDLHander(IConfiguration config)
        {
            _config = config;
            _eventParser = new SDLEventParser();
        }

        public void Initialize()
        {
            if(_config == null || _config.WindowHeight == 0 || _config.WindowHeight == 0)
            {
                // log error

                return;
            }

            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            _window = new Window("Bound", _config.WindowWidth, _config.WindowHeight);
            _window.Create();

            if(_window == null || _window.WindowHandler == IntPtr.Zero)
            {
                // log error

                return;
            }

            _renderer = new Renderer(_window.WindowHandler);
            _renderer.Create();

            IsRunning = _window.WindowHandler != IntPtr.Zero && _renderer.RendererHandler != IntPtr.Zero;
        }

        public void PollEvents() => _eventParser.PollEvents();
        public void ClearEvents() => _eventParser.ClearEvents();

        public void Quit()
        {
            _renderer?.Destroy();
            _window?.Destroy();

            IsRunning = false;
            
            SDL.SDL_Quit();
        }
    }
}