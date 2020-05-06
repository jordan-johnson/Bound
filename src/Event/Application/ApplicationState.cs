using System;

namespace Bound.Event.Application
{
    public enum States
    {
        Opening,
        Running,
        Closing
    }

    public class ApplicationState : IBoundEvent
    {
        public States CurrentState { get; set; }

        public ApplicationState(States state)
        {
            CurrentState = state;
        }
    }
}