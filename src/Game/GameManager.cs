using System;
using System.Linq;
using System.Collections.Generic;
using Bound.Event;
using Bound.Event.Game;
using Bound.Event.Application;

namespace Bound.Game
{
    public class GameManager : IGameManager
    {
        private IBoundEventParser _eventParser;

        public GameManager()
        {
            _eventParser = new BoundEventParser();
        }

        public void Update(double deltaTime, IEnumerable<IBoundEvent> events)
        {
            // testing key change event (will be removed)
            foreach(var e in events)
            {
                if(e.GetType() == typeof(KeyChangeEvent))
                {
                    var kce = (KeyChangeEvent)e;

                    Console.WriteLine(kce.KeycodeAsString + "/" + kce.State);
                }
            }
        }

        public void Destroy()
        {

        }
    }
}