using System;
using System.Linq;
using System.Collections.Generic;
using Bound.Event;
using Bound.Event.Game;
using Bound.Event.Application;
using Bound.Graphics;
using Bound.Graphics.Scene;

namespace Bound.Game
{
    public class GameManager : IGameManager
    {
        private IBoundEventParser _eventParser;
        private ISceneHandler _sceneHandler;

        public IEnumerable<IDrawable> Drawables { get; private set; }

        public GameManager()
        {
            Drawables = new List<IDrawable>();
            _eventParser = new BoundEventParser();
            _sceneHandler = new SceneHandler();

            // _sceneHandler.AddScenes(new IScene[] {
            //     new MainMenuScene()
            // });
        }

        public void Update(double deltaTime, IEnumerable<IBoundEvent> events)
        {
            
        }

        public void Destroy()
        {

        }
    }
}