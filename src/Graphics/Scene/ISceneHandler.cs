using System;

namespace Bound.Graphics.Scene
{
    public interface ISceneHandler
    {
        void AddScene(IScene scene);
        void SetScene(IScene scene);
        void SetSceneByName(string sceneName);
        void Update();
    }
}