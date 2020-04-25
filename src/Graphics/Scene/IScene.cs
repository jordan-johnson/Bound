using System;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public interface IScene
    {
        string Name { get; }
        List<ILayer> Layers { get; }

        void Initialize();
        void Dispose();
    }
}