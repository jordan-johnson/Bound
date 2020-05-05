using System;
using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public class MainMenuScene : IScene
    {
        public string Name => "main";

        public IEnumerable<ILayer> Layers => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}