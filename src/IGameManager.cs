using System;
using System.Collections.Generic;
using Bound.Event;

namespace Bound
{
    public interface IGameManager
    {
        void Update(IEnumerable<IBoundEvent> events);
        void Destroy();
    }
}