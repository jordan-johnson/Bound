using SDL2;

namespace Bound.Event.Application
{
    /// <summary>
    /// The EventHandler class is a low-level event parser. Events are interpreted and pushed 
    /// into a collection of IBoundEvent for high-level parsing.
    /// </summary>
    public class SDLEventParser : ISDLEventParser
    {
        private SDL.SDL_Event _sdlEvent;

        public EventsCollection Events { get; private set; }

        public SDLEventParser()
        {
            Events = new EventsCollection();
        }

        public void PollEvents()
        {
            while(SDL.SDL_PollEvent(out _sdlEvent) != 0)
            {
                switch(_sdlEvent.type)
                {
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                    case SDL.SDL_EventType.SDL_KEYUP:
                        var key = _sdlEvent.key;
                        
                        Events.Add(new KeyChangeEvent(key.keysym.sym, key.state));
                    break;
                    case SDL.SDL_EventType.SDL_QUIT:
                        Events.Add(new ApplicationState(States.Closing));
                    break;
                }
            }
        }

        public void ClearEvents()
        {
            Events.ClearAll();
        }
    }
}