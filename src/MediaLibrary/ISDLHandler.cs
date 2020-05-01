using System;
using System.Collections.Generic;
using Bound.Event;

namespace Bound.MediaLibrary
{
    public interface ISDLHandler
    {
        bool IsRunning { get; }
        IEnumerable<IBoundEvent> Events { get; }

        void Initialize();
        void PollEvents();
        void ClearEvents();
        void Quit();
    }
}