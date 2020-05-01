using System;

namespace Bound.Event.Application
{
    public class ApplicationState : IBoundEvent
    {
        public enum States
        {
            Opening,
            Running,
            Closing
        }

        public States CurrentState { get; set; }

        public ApplicationState(States state)
        {
            CurrentState = state;
        }
    }
}