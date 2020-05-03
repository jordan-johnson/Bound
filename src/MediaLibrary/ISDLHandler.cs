using System;
using System.Collections.Generic;
using Bound.Event;

namespace Bound.MediaLibrary
{
    public interface ISDLHandler
    {
        bool IsRunning { get; }
        double DeltaTime { get; }
        IEnumerable<IBoundEvent> Events { get; }

        void Initialize();
        void PollEvents();
        void ClearEvents();
        void Update();
        void Quit();
    }
}