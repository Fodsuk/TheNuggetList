namespace EventAggregator
{
    public interface IEventAggregator
    {
        void SendMessage<T>(T message) where T : IEvent;
        void SendMessage<T>() where T : IEvent, new();
        void AddListener(IListenTo listener);
        void RemoveListener(IListenTo listener);
    }
}