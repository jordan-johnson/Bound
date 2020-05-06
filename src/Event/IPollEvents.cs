using System;
using System.Collections.Generic;

namespace Bound.Event
{
    public interface IPollEvents
    {
        EventsCollection Events { get; }
        void PollEvents();
        void ClearEvents();
    }
}