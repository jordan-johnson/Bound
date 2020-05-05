using System;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public interface ISceneHandler
    {
        void AddScene(IScene scene);
        void AddScenes(IEnumerable<IScene> scene);
        void SetScene(IScene scene);
        void SetSceneByName(string sceneName);
        void Update();
    }
}