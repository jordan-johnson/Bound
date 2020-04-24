using System;
using SDL2;
using Bound.Graphics;

namespace Bound.Startup
{
    public class BoundStartup : IStartup
    {
        private IWindow _window;

        public void Initialize()
        {
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            _window = new Window("Bound", 1280, 720);
            _window.Create();
        }

        public void Run()
        {
            while(_window.IsOpen)
            {
                _window.PollEvents();
            }

            Quit();
        }

        public void Quit()
        {
            _window.CloseWindow();
            
            SDL.SDL_Quit();
        }
    }
}