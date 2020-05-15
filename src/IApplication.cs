using System;
using Bound.Event.Application;

namespace Bound
{
    public interface IApplication
    {
        void Initialize(bool debugging);
        void Run();
    }
}