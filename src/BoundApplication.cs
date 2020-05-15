using System;
using Serilog;
using Bound.Game;
using Bound.ApplicationBoot;
using Bound.Utilities.Configuration;
using Bound.Utilities.Logging;
using Bound.Event;
using Bound.Event.Application;

namespace Bound
{
    /// <summary>
    /// Creates basic application functionality i.e. application context (window), configuration, 
    /// logging, and a game manager.
    /// </summary>
    public class BoundApplication : IApplication
    {
        private IBoundLogger _logger;
        private IConfiguration _config;
        private IApplicationContext _context;
        private IGameManager _game;
        private ISDLEventParser _sdlEventParser;

        /// <summary>
        /// Initialize essential systems for application.
        /// </summary>
        public void Initialize(bool debugging)
        {
            _logger = new BoundLogger(debugging);

            try
            {
                _config = new UserConfiguration(debugging);
                _config.Initialize();

                _context = new ApplicationContext(_config);
                _context.CreateContext();

                _sdlEventParser = new SDLEventParser();
                _game = new GameManager(_context.ContextHandle, _config);
            }
            catch(Exception e)
            {
                Log.Fatal("Application could not be initialized! {e}", e);
            }
        }

        /// <summary>
        /// Application loop.
        /// 
        /// Parsed SDL events are fed into IGameManager's Update method.
        /// </summary>
        public void Run()
        {
            if(_context == null || _game == null)
                return;
                
            while(_context.IsRunning)
            {
                _sdlEventParser.PollEvents();

                _game.Update(_sdlEventParser.ParsedEvents);

                if(IsApplicationClosing())
                    Quit();

                _sdlEventParser.ClearEvents();
            }
        }

        /// <summary>
        /// Request game to quit, and destroy the ApplicationContext.
        /// </summary>
        private void Quit()
        {
            _game?.Quit();
            _context?.Destroy();
        }

        /// <summary>
        /// Checks parsed events for application closing event.
        /// </summary>
        private bool IsApplicationClosing()
        {
            return _sdlEventParser.ParsedEvents.GetFirstInstanceOfType<ApplicationClosingEvent>() != null;
        }
    }
}