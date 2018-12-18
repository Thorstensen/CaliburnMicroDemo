using Autofac;
using Caliburn.Micro.Demo.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Caliburn.Micro.Demo.EventAggregation
{
    public class ExtendedEventAggregator : EventAggregator
    {
        private readonly List<Handler> _handlers;
        private readonly IComponentContext _componentContext;

        public ExtendedEventAggregator(IComponentContext componentContext)
        {
            _componentContext = componentContext;
            _handlers = new List<Handler>();
        }

        public override void Subscribe(object subscriber)
        {
            var handler = new Handler(subscriber, _componentContext);
            lock (_handlers)
            {
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
