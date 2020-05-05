using System;
using System.Collections.Generic;
using Bound.Event;
using Bound.Graphics;

namespace Bound.Game
{
    public interface IGameManager
    {
        IEnumerable<IDrawable> Drawables { get; }
        void Update(double deltaTime, IEnumerable<IBoundEvent> events);
        void Destroy();
    }
}