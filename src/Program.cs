using System;
using Bound.Startup;

namespace Bound
{
    static class Program
    {
        private static IStartup _applicationBoot;

        static void Main(string[] args)
        {
            _applicationBoot = new BoundStartup();
            _applicationBoot.Initialize();
            _applicationBoot.Run();
        }
    }
}
