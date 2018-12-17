using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Caliburn.Micro.Demo.EventAggregation
{
    public class ExtendedEventAggregator1 : EventAggregator
    {
        private List<Handler1> _handlers = new List<Handler1>();

        public override void Subscribe(object subscriber)
        {
            var handler = new Handler1(subscriber);
            _handlers.Add(handler);
        }

        public override void Publish(object message, Action<System.Action> marshal)
        {
            Handler1[] _toNotify;
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
    }

    public class Handler1
    {
        private readonly WeakReference _subscribedDataContext;
        private Dictionary<Type, ExecuteStrategy> _supportedHandlers = new Dictionary<Type, ExecuteStrategy>(); 

        public Handler1(object subscriber)
        {
            _subscribedDataContext = new WeakReference(subscriber);

            var interfaces = subscriber.GetType().GetTypeInfo().ImplementedInterfaces
                              .Where(i => i.GetTypeInfo().Name.Equals(typeof(ICanHandle<,>).Name));

            foreach(var @interface in interfaces)
            {
                var command = @interface.GenericTypeArguments[0];
                var canExecute = @interface.GenericTypeArguments[1];

                var executeMethod = @interface.GetRuntimeMethod("Handle", new[] { command });
                
                if(executeMethod != null)
                {
                    var executeStrategy = new ExecuteStrategy(executeMethod, canExecute);
                    _supportedHandlers[command] = executeStrategy;
                }
            }
        }

        public void Handle(object message)
        {
            var handlers = _supportedHandlers.Where(handler => handler.Key.GetTypeInfo().IsAssignableFrom(message.GetType().GetTypeInfo()));
            foreach(var handler in handlers)
            {
                var executeStrategy = handler.Value;
                if (executeStrategy.CanExecute(message))
                {
                    executeStrategy.Execute(_subscribedDataContext.Target, message);
                }
            }
        }

        public bool IsDead => _subscribedDataContext.Target == null;
    }
}
