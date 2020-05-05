using System;
using System.Collections.Generic;

namespace Bound.Graphics
{
    public interface IDraw
    {
        void Draw(IEnumerable<IDrawable> drawables);
    }
}