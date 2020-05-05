using System;
using System.Linq;
using System.Collections.Generic;
using Bound.Game;
using Bound.Event;
using Bound.Event.Application;
using Bound.MediaLibrary;
using Bound.Utilities.Configuration;
using State = Bound.Event.Application.ApplicationState.States;

namespace Bound
{
    /// <summary>
    /// BoundApplication connects subsystems for basic application functionality. Such things
    /// would include application configuration, window/renderer creation, event handling, and 
    /// initializing the game manager.
    /// 
    /// It's important to recognize the distinction between this class and the Game Manager (GM).
    /// The GM is a modular subsystem for creating scenes, parsing events (provided by this class), 
    /// and other game-related functionality. BoundApplication is the bootstrap.
    /// </summary>
    public class BoundApplication : IApplication
    {
        private ISDLHandler _sdl;
        private IConfiguration _config;
        private IGameManager _game;

        public void Initialize(bool debugging = false)
        {
            _config = new UserConfiguration(debugging);
            _config.Load();

            _sdl = new SDLHandler(_config);
            _sdl.Initialize();

            _game = new GameManager();
        }

        public void Run()
        {
            while(_sdl.IsRunning)
            {
                _sdl.UpdateTime();
                _sdl.PollEvents();
                _game.Update(_sdl.DeltaTime, _sdl.Events);
                _sdl.Draw(_game.Drawables);

                CheckApplicationState();

                _sdl.ClearEvents();
            }
        }

        private void CheckApplicationState()
        {
            var state = (ApplicationState)_sdl.Events.FirstOrDefault(x => x.GetType() == typeof(ApplicationState));

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

        private void Quit()
        {
            _game?.Destroy();
            _sdl?.Quit();
        }
    }
}