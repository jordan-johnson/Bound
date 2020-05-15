using System;

namespace Bound.Graphics
{
    public interface IRenderer
    {
        bool Exists { get; }
        
        void CreateRenderer();
        void Draw();
        void Destroy();
    }
}