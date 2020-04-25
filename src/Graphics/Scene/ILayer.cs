using System;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public interface ILayer
    {
        string Name { get; }
        int ZAxisOrder { get; }
        List<IDrawable> Drawables { get; }
    }
}