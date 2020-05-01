using System;
using System.Collections.Generic;
using SDL2;

namespace Bound.Graphics
{
    public class Renderer : IRenderer
    {
        private IntPtr _windowHandler;

        public IntPtr RendererHandler { get; private set; }
        public List<IDrawable> Drawables { get; private set; }

        public Renderer(IntPtr windowHandler)
        {
            _windowHandler = windowHandler;

            RendererHandler = IntPtr.Zero;
            Drawables = new List<IDrawable>();
        }

        public void Create()
        {
            if(_windowHandler == IntPtr.Zero)
                return;

            RendererHandler = SDL.SDL_CreateRenderer(_windowHandler, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
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

        public void Destroy()
        {
            SDL.SDL_DestroyRenderer(RendererHandler);
        }
    }
}