using Bound.Event;

namespace Bound.Game
{
    public interface IGameManager
    {
        void Update(EventsCollection events);
        void Quit();
    }
}