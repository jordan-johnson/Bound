using System;

namespace Bound.Startup
{
    public interface IStartup
    {
        void Initialize();
        void Run();
        void Quit();
    }
}