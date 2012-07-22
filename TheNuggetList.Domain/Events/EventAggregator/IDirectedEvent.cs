namespace EventAggregator
{
    public interface IDirectedEvent : IEvent
    {
        object Receiver { get; set; }
    }
}