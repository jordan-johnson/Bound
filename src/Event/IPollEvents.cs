using System;
using System.Collections.Generic;

namespace Bound.Event
{
    public interface IPollEvents
    {
        IEnumerable<IBoundEvent> Events { get; }
        void PollEvents();
        void ClearEvents();
    }
}