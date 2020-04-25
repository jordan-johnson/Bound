using System;
using System.Linq;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public class SceneHandler : ISceneHandler
    {
        private IScene _currentScene;
        private List<IDrawable> _drawables;
        private List<IScene> _scenes;

        public SceneHandler(List<IDrawable> drawables)
        {
            _scenes = new List<IScene>();
            _drawables = drawables;
        }

        public void AddScene(IScene scene)
        {
            _scenes.Add(scene);

            scene.Initialize();
        }

        public void SetScene(IScene scene)
        {
            if(_scenes.Contains(scene))
            {
                DisposeCurrentScene();
                SetDrawablesUsingLayers(scene);

                _currentScene = scene;
            }
            else
            {
                // TODO: log unknown source of scene, scene needs to be setup first
            }
        }

        public void SetSceneByName(string sceneName)
        {
            var scene = _scenes.FirstOrDefault(x => x.Name == sceneName);

            SetScene(scene);
        }

        public void Update()
        {
            
        }

        private void DisposeCurrentScene()
        {
            _drawables.Clear();

            _currentScene.Dispose();
        }

        private void SetDrawablesUsingLayers(IScene scene)
        {
            foreach(var layer in scene.Layers.OrderBy(x => x.ZAxisOrder))
            {
                _drawables.AddRange(layer.Drawables);
            }
        }
    }
}