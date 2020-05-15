namespace Bound.Event
{
    public interface ISDLEventParser
    {
        EventsCollection ParsedEvents { get; }

        void PollEvents();
        void ClearEvents();
    }
}