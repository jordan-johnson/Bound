using System;
using SDL2;
using Bound.Event;
using Bound.Graphics;
using Bound.Graphics.Scene;
using Bound.Utilities.Configuration;
using Bound.Event.Application;
using State = Bound.Event.Application.ApplicationState.States;

namespace Bound
{
    /// <summary>
    /// BoundApplication handles the lifespan and basic functionality of the application, 
    /// such as the window, renderer, configuration, and events.
    /// </summary>
    public class BoundApplication : IApplication
    {
        private IWindow _window;
        private IRenderer _renderer;
        private IConfiguration _config;
        private IEventHandler _eventHandler;
        private IGameManager _game;

        public void Initialize()
        {
            _config = new UserConfiguration();
            _config.Load();
            
            _eventHandler = new Event.EventHandler();

            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            CreateWindow();
            CreateRenderer();
            CreateGameManager();
        }

        public void Run()
        {
            while(_window.IsOpen)
            {
                _eventHandler.PollEvents();

                CheckApplicationState();

                _game.Update(_eventHandler.GetEvents());
                // game manager ...
                _eventHandler.ClearEvents();
            }
        }

        private void CheckApplicationState()
        {
            var state = (ApplicationState)_eventHandler.GetFirstInstanceOf<ApplicationState>();

            if(state == null)
                return;

            switch(state.CurrentState)
            {
                case State.Closing:
                    Console.WriteLine("closing");
                    Quit();
                break;
            }
        }

        private void CreateWindow()
        {
            if(_config == null)
            {
                // log config warning and create new...
            }

            _window = new Window("Bound", _config.WindowWidth, _config.WindowHeight);
            _window.Create();
        }

        private void CreateRenderer()
        {
            if(_window == null || _window.WindowHandler == IntPtr.Zero)
            {
                Console.WriteLine("test");
                // log window creation error and quit...
                Quit();
            }

            _renderer = new Renderer(_window.WindowHandler);
            _renderer.Create();
        }

        private void CreateGameManager()
        {
            _game = new GameManager();
        }

        private void Quit()
        {
            _renderer?.Destroy();
            _window?.Destroy();
            
            SDL.SDL_Quit();
        }
    }
}