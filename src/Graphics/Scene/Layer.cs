using System.Collections.Generic;

namespace Bound.Graphics.Scene
{
    public struct Layer
    {
        public string Name;
        public int ZAxisOrder;
        public List<Drawable> Drawables;
    }
}