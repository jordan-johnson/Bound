using System;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public abstract class BaseScene : IScene
    {
        public abstract String Name { get; }
        public virtual List<Layer> Layers { get; protected set; }

        public virtual void Initialize()
        {
            Layers = new List<Layer>();
        }

        public virtual void Dispose()
        {
            // ...
        }
    }
}