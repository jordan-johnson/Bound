using System;
using System.Collections.Generic;
using Bound.Event;

namespace Bound.Graphics.Scene
{
    public interface ISceneHandler
    {
        void AddScene(IScene scene);
        void AddScenes(IEnumerable<IScene> scene);
        void SetScene(IScene scene);
        void SetSceneByName(string sceneName);
        void Update(double deltaTime, EventsCollection events);
        IEnumerable<Drawable> GetDrawables();
    }
}