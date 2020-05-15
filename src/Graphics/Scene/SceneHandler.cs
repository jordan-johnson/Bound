using System;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using Bound.Event;

namespace Bound.Graphics.Scene
{
    public class SceneHandler : ISceneHandler
    {
        private EventsCollection _events;
        private IScene _currentScene;
        private List<IScene> _scenes;

        public SceneHandler()
        {
            _scenes = new List<IScene>();
        }

        public void AddScene(IScene scene)
        {
            _scenes.Add(scene);

            scene.Initialize();
        }

        public void AddScenes(IEnumerable<IScene> scenes)
        {
            foreach(var scene in scenes)
            {
                AddScene(scene);
            }
        }

        public void SetScene(IScene scene)
        {
            
        }

        public void SetSceneByName(string sceneName)
        {
            var scene = _scenes.FirstOrDefault(x => x.Name == sceneName);

            SetScene(scene);
        }

        public void Update(double deltaTime, EventsCollection events)
        {
            
        }

        public IEnumerable<Drawable> GetDrawables()
        {
            if(_currentScene == null)
                return null;

            var drawables = new List<Drawable>();

            foreach(var layer in _currentScene?.Layers?.OrderBy(x => x.ZAxisOrder))
            {
                drawables.AddRange(layer.Drawables);
            }

            return drawables;
        }
    }
}