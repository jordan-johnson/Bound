using System;
using SDL2;

namespace Bound.Graphics
{
    public struct Drawable
    {
        public IntPtr Texture;
        public SDL.SDL_Rect Crop;
        public SDL.SDL_Rect Position;
    }
}