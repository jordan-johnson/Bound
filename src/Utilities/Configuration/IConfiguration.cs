using System;

namespace Bound.Utilities.Configuration
{
    public interface IConfiguration
    {
        int WindowWidth { get; }
        int WindowHeight { get; }

        void Initialize();
        void ThrowIfInvalidConfiguration();
    }
}