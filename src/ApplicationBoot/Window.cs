using System;
using SDL2;

namespace Bound.ApplicationBoot
{
    public class Window : IWindow
    {
        public IntPtr WindowHandler { get; private set; }
        public string Title { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

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

            if(WindowHandler == IntPtr.Zero)
                throw new Exception($"Window could not be created! {SDL.SDL_GetError()}");
        }

        public void Destroy()
        {
            if(WindowHandler == IntPtr.Zero)
                return;
                
            SDL.SDL_DestroyWindow(WindowHandler);
        }
    }
}