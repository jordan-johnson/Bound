using System;
using System.Collections.Generic;
using Bound.Event;
using Bound.Event.Game;

namespace Bound
{
    public class GameManager : IGameManager
    {
        private IBoundEventParser _eventParser;

        public GameManager()
        {
            _eventParser = new BoundEventParser();
        }

        public void Update(IEnumerable<IBoundEvent> events)
        {
            
        }

        public void Destroy()
        {

        }
    }
}