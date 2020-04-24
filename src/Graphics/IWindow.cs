using System;

namespace Bound.Graphics
{
    public interface IWindow
    {
        IntPtr WindowHandler { get; }
        string Title { get; }
        int Width { get; }
        int Height { get; }
        bool IsOpen { get; }

        void Create();
        void PollEvents();
        void CloseWindow();
    }
}