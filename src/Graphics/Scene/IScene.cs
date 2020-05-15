using System;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public interface IScene
    {
        string Name { get; }
        List<Layer> Layers { get; }

        void Initialize();
        void Dispose();
    }
}