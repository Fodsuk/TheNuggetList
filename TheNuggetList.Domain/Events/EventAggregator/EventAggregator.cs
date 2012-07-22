using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EventAggregator
{
    public class EventAggregator : IEventAggregator
    {
        private readonly SynchronizationContext _context;
        private readonly List<IListenTo> _listeners = new List<IListenTo>();
        private readonly object _locker = new object();

        public EventAggregator(SynchronizationContext context)
        {
            _context = context;
        }
        
        public void SendMessage<T>(T message) where T : IEvent
        {
            SendAction(() => All().CallOnEach<IListenTo<T>.All>(x =>
            {
                x.Handle(message);
            }));

            SendAction(() => All().CallOnEach<IListenTo<T>.ThatSatisfy>(x =>
            {
                if (x.SatisfiedBy(message))  
                    x.Handle(message);
            }));

            var directedMessage = message as IDirectedEvent;
            if (directedMessage != null)
            {
                SendAction(() => All().FirstOrDefault(x => directedMessage.Receiver.Equals(x))
                    .CallOn<IListenTo<T>.SentToMe>(x => x.Handle(message)));
            }
        }

        public void SendMessage<T>() where T : IEvent, new()
        {
            SendMessage(new T());
        }

        public void AddListener(IListenTo listener)
        {
            WithinLock(() =>
            {
                if (_listeners.Contains(listener)) 
                    return;

                _listeners.Add(listener);
            });
        }

        public void RemoveListener(IListenTo listener)
        {
            WithinLock(() => _listeners.Remove(listener));
        }
        

        private IEnumerable<IListenTo> All()
        {
            lock (_locker)
            {
                return _listeners;
            }
        }

        private void WithinLock(Action action)
        {
            lock (_locker)
            {
                action();
            }
        }

        private void SendAction(Action action)
        {
            _context.Send(state => action(), null);
        }
    }
}
