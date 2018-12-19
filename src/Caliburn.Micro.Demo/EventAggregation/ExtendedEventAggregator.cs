using Autofac;
using Autofac.Features.Indexed;
using Caliburn.Micro.Demo.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Caliburn.Micro.Demo.EventAggregation
{
    public class ExtendedEventAggregator : EventAggregator
    {
        private readonly List<Handler> _handlers;
        private readonly IIndex<string, IExecuteGuard> _registeredGuards;

        public ExtendedEventAggregator(IIndex<string, IExecuteGuard> registeredGuards)
        {
            _registeredGuards = registeredGuards;
            _handlers = new List<Handler>();
        }

        public override void Subscribe(object subscriber)
        {
            var handler = new Handler(subscriber, _registeredGuards);
            lock (_handlers)
            {
                if (_handlers.Any(existingHandler => existingHandler.ReferencedHashcode.Equals(handler.ReferencedHashcode)))
                    throw new ArgumentException($"Handler {handler} is already added to the subscription list. " +
                        $"This is potentially caused by calling 'Subscribe' several times on the same object.");
                _handlers.Add(handler);
            }
        }

        public override void Publish(object message, Action<System.Action> marshal)
        {
            Handler[] _toNotify;
            lock (_handlers)
            {
                _toNotify = _handlers.ToArray();
            }

            marshal(() =>
            {
                foreach (var handle in _toNotify)
                    handle.Handle(message);

                var dead = _toNotify.Where(i => i.IsDead).ToList();
                if (dead.Any())
                {
                    lock (_handlers)
                    {
                        dead.Apply(x => _handlers.Remove(x));
                    }
                }
            });
        }

        public override void Unsubscribe(object subscriber)
        {
            Guard.Against.Null(subscriber);
            
            lock (_handlers)
            {
                var found = _handlers.FirstOrDefault(x => x.Matches(subscriber));

                if (found != null)
                {
                    _handlers.Remove(found);
                }
            }
        }
    }
}