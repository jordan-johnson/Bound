using System;

namespace Bound.Utilities.Timing
{
    public interface ITimer
    {
        double DeltaTime { get; }

        void UpdateTime();
    }
}