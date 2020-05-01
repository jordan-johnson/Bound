using System;
using System.Collections.ObjectModel;

namespace Bound.Event.Application
{
    public interface ISDLEventParser
    {
        void PollEvents();
        void ClearEvents();
        ReadOnlyCollection<IBoundEvent> GetEvents();
        ReadOnlyCollection<IBoundEvent> GetEventsOfType<T>() where T : IBoundEvent;
        IBoundEvent GetFirstInstanceOf<T>() where T : IBoundEvent;
    }
}