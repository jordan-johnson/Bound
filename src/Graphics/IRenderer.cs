using System;
using System.Collections.Generic;
using SDL2;

namespace Bound.Graphics
{
    public interface IRenderer : IDraw
    {
        IntPtr RendererHandler { get; }
        List<IDrawable> Drawables { get; }

        void Create();
        void Destroy();
    }
}