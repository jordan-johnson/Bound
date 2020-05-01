using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SDL2;
using Bound.Event.Application;
using State = Bound.Event.Application.ApplicationState.States;

namespace Bound.Event.Application
{
    /// <summary>
    /// The EventHandler class is a low-level event parser. Events are interpreted and pushed 
    /// into a collection of IBoundEvent for high-level parsing.
    /// </summary>
    public class SDLEventParser : ISDLEventParser
    {
        private SDL.SDL_Event _sdlEvent;
        private List<IBoundEvent> _events;

        public SDLEventParser()
        {
            _events = new List<IBoundEvent>();
        }

        public void PollEvents()
        {
            while(SDL.SDL_PollEvent(out _sdlEvent) != 0)
            {
                switch(_sdlEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        _events.Add(new ApplicationState(State.Closing));
                    break;
                }
            }
        }

        public void ClearEvents()
        {
            _events.Clear();
        }

        public ReadOnlyCollection<IBoundEvent> GetEvents()
        {
            return _events.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<IBoundEvent> GetEventsOfType<T>() where T : IBoundEvent
        {
            var eventsOfType = _events?.Where(x => x.GetType() == typeof(T));

            return eventsOfType.ToList().AsReadOnly();
        }

        public IBoundEvent GetFirstInstanceOf<T>() where T : IBoundEvent
        {
            return GetEventsOfType<T>().FirstOrDefault();
        }
    }
}