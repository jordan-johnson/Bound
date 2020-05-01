using System;

namespace Bound.Graphics
{
    public interface IWindow
    {
        IntPtr WindowHandler { get; }
        string Title { get; }
        int Width { get; }
        int Height { get; }
        
        void Create();
        void Destroy();
    }
}