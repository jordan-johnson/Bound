using System;
using SDL2;

namespace Bound.Graphics
{
    public interface IDrawable
    {
        IntPtr Texture { get; }
        SDL.SDL_Rect Crop { get; }
        SDL.SDL_Rect Position { get; }
    }
}