using System;
using System.Collections.Generic;
using Bound.Event;

namespace Bound.Game
{
    public interface IGameManager
    {
        void Update(double deltaTime, IEnumerable<IBoundEvent> events);
        void Destroy();
    }
}