namespace EventAggregator
{
    public interface IListenTo
    {
    }

    public class IListenTo<T> where T : IEvent
    {
        public interface All : IListenTo
        {
            void Handle(T message);
        }

        public interface SentToMe : IListenTo 
        {
            void Handle(T message);
        }

        public interface ThatSatisfy : IListenTo
        {
            void Handle(T message);
            bool SatisfiedBy(T message);
        }
    }
}