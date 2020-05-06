using System;
using System.Linq;
using System.Collections.Generic;

namespace Bound.Event
{
    public class EventsCollection
    {
        private List<IBoundEvent> _events;

        public EventsCollection()
        {
            _events = new List<IBoundEvent>();
        }

        public void Add(IBoundEvent boundEvent)
        {
            _events?.Add(boundEvent);
        }

        public void Add(IEnumerable<IBoundEvent> boundEvents)
        {
            _events?.AddRange(boundEvents);
        }

        public IEnumerable<IBoundEvent> GetAll()
        {
            return _events.AsReadOnly();
        }

        public IEnumerable<IBoundEvent> GetByType<T>()
        {
            var eventsOfType = _events?.Where(x => x.GetType() == typeof(T));

            return eventsOfType;
        }

        public IBoundEvent GetFirstInstanceOfType<T>()
        {
            var eventType = _events?.FirstOrDefault(x => x.GetType() == typeof(T));

            return eventType;
        }

        public void ClearAll()
        {
            _events.Clear();
        }

        public void RemoveAllOfType<T>()
        {
            _events.RemoveAll(x => x.GetType() == typeof(T));
        }
    }
}