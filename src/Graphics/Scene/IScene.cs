using System;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public interface IScene
    {
        int? Id { get; }
        string Name { get; }
        IEnumerable<ILayer> Layers { get; }

        void Initialize();
        void Dispose();
    }
}