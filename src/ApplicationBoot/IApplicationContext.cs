using System;

namespace Bound.ApplicationBoot
{
    public interface IApplicationContext
    {
        bool IsRunning { get; }
        IntPtr ContextHandle { get; }
        
        void CreateContext();
        void Destroy();
    }
}