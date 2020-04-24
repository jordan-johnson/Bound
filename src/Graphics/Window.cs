using System;
using SDL2;

namespace Bound.Graphics
{
    public class Window : IWindow
    {
        private SDL.SDL_Event _eventHandler;

        public IntPtr WindowHandler { get; private set; }
        public string Title { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool IsOpen { get; private set; }

        public Window(string title, int width, int height)
        {
            Title = title;
            Width = width;
            Height = height;
            WindowHandler = IntPtr.Zero;
        }

        public void Create()
        {
            if(Title == null || Width == 0 || Height == 0)
                return;

            WindowHandler = SDL.SDL_CreateWindow(
                Title, 
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                Width,
                Height,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
            );

            IsOpen = WindowHandler != IntPtr.Zero;
        }

        public void PollEvents()
        {
            while(SDL.SDL_PollEvent(out _eventHandler) != 0)
            {
                switch(_eventHandler.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        IsOpen = false;
                    break;
                }
            }
        }

        public void CloseWindow()
        {
            SDL.SDL_DestroyWindow(WindowHandler);
        }
    }
}