using System;
using System.Collections.Generic;
using Bound.Event;
using Bound.Graphics;
using Bound.Utilities.Timing;

namespace Bound.MediaLibrary
{
    public interface ISDLHandler : IPollEvents, ITimer, IDraw
    {
        bool IsRunning { get; }

        void Initialize();
        void Quit();
    }
}