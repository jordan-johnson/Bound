using System;
using System.Linq;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public class SceneHandler : ISceneHandler
    {
        private IScene _currentScene;
        private List<IScene> _scenes;

        public SceneHandler()
        {
            _scenes = new List<IScene>();
        }

        public void AddScene(IScene scene)
        {
            // assign scene id ...
            
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
            // _drawables.Clear();

            _currentScene.Dispose();
        }

        private void SetDrawablesUsingLayers(IScene scene)
        {
            foreach(var layer in scene.Layers.OrderBy(x => x.ZAxisOrder))
            {
                // _drawables.AddRange(layer.Drawables);
            }
        }
    }
}