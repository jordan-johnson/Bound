using System;
using System.Collections.Generic;
using SDL2;
using Serilog;

namespace Bound.Graphics
{
    public class Renderer : IRenderer
    {
        private IntPtr _context;
        private IntPtr _rendererHandle;

        public bool Exists => _rendererHandle != IntPtr.Zero;

        public Renderer(IntPtr context)
        {
            _context = context;
        }

        public void CreateRenderer()
        {
            if(_rendererHandle != IntPtr.Zero)
            {
                Log.Warning("Renderer handle already set.");

                return;
            }

            if(_context == IntPtr.Zero)
                throw new NullReferenceException("Renderer could not be created; ApplicationContext handle not found");

            _rendererHandle = SDL.SDL_CreateRenderer(_context, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        
            if(_rendererHandle == IntPtr.Zero)
                throw new NullReferenceException($"Renderer could not be created. SDL Error: {SDL.SDL_GetError()}");
        }

        public void Draw()
        {
            SDL.SDL_RenderClear(_rendererHandle);

            SDL.SDL_RenderPresent(_rendererHandle);
        }

        public void Destroy()
        {
            if(_rendererHandle == IntPtr.Zero)
                return;
                
            SDL.SDL_DestroyRenderer(_rendererHandle);
        }
    }
}