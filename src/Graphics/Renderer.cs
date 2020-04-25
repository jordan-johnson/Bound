using System;
using System.Collections.Generic;
using SDL2;

namespace Bound.Graphics
{
    public class Renderer : IRenderer
    {
        private IWindow _window;

        public IntPtr RendererHandler { get; private set; }
        public List<IDrawable> Drawables { get; private set; }

        public Renderer(IWindow window)
        {
            _window = window;

            RendererHandler = IntPtr.Zero;
            Drawables = new List<IDrawable>();
        }

        public void Create()
        {
            if(_window == null || _window.WindowHandler == IntPtr.Zero)
                return;

            RendererHandler = SDL.SDL_CreateRenderer(_window.WindowHandler, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        }

        public void Draw()
        {
            foreach(var drawable in Drawables)
            {
                SDL.SDL_Rect crop = drawable.Crop;
                SDL.SDL_Rect pos = drawable.Position;
                SDL.SDL_RenderCopy(RendererHandler, drawable.Texture, ref crop, ref pos);
            }
        }
    }
}