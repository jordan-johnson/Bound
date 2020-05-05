using System;
using SDL2;

namespace Bound.Utilities.Timing
{
    public class Timer : ITimer
    {
        private UInt64 _current;
        private UInt64 _last;

        public double DeltaTime { get; private set; }

        public Timer()
        {
            _current = SDL.SDL_GetPerformanceCounter();
            _last = 0;

            DeltaTime = 0;
        }

        public void UpdateTime()
        {
            _last = _current;
            _current = SDL.SDL_GetPerformanceCounter();

            DeltaTime = (double)((_current - _last) * 1000 / (double)SDL.SDL_GetPerformanceFrequency());
        }
    }
}