using System;

namespace Bound.ApplicationBoot
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