using System;
using SDL2;

namespace Bound.Event.Application
{
    public class KeyChangeEvent : IBoundEvent
    {
        private byte _state;

        public SDL.SDL_Keycode Keycode { get; private set; }
        public string KeycodeAsString { get; private set; }

        public bool Pressed
        {
            get
            {
                return _state != 0;
            }
        }

        public KeyChangeEvent(SDL.SDL_Keycode key, byte state)
        {
            _state = state;
            Keycode = key;
            KeycodeAsString = SDL.SDL_GetKeyName(key);
        }
    }
}