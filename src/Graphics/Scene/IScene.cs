using System;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public interface IScene
    {
        string Name { get; }
        IEnumerable<ILayer> Layers { get; }

        void Initialize();
        void Dispose();
    }
}