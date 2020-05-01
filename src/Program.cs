using System;

namespace Bound
{
    static class Program
    {
        private static IApplication _application;

        static void Main(string[] args)
        {
            _application = new BoundApplication();
            _application.Initialize();
            _application.Run();
        }
    }
}
