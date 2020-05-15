using System;
using Bound.Event;
using Bound.Graphics;
using Bound.Graphics.Scene;
using Bound.Utilities.Configuration;
using Bound.Utilities.Timing;

namespace Bound.Game
{
    public class GameManager : IGameManager
    {
        private IntPtr _context;
        private IConfiguration _configuration;
        private IRenderer _renderer;
        private ITimer _timer;
        private ISceneHandler _sceneHandler;

        public GameManager(IntPtr context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            _renderer = new Renderer(_context);
            _renderer.CreateRenderer();

            _timer = new Timer();
            _sceneHandler = new SceneHandler();
        }

        public void Update(EventsCollection events)
        {
            _sceneHandler.Update(_timer.DeltaTime, events);

            _renderer.Draw();
        }

        public void Quit()
        {
            _renderer?.Destroy();
        }
    }
}