using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Caliburn.Micro.Demo.EventAggregation
{
    public class Handler
    {
        private readonly WeakReference _subscribedDataContext;
        private readonly IComponentContext _componentContext;
        private Dictionary<Type, ExecuteStrategy> _supportedHandlers = new Dictionary<Type, ExecuteStrategy>(); 

        public Handler(object subscriber, IComponentContext componentContext)
        {
            _subscribedDataContext = new WeakReference(subscriber);
           
            var interfaces = subscriber.GetType().GetTypeInfo().ImplementedInterfaces
                              .Where(i => i.GetTypeInfo().Name.Equals(typeof(ICanHandle<,>).Name));

            foreach (var @interface in interfaces)
            {
                var command = @interface.GenericTypeArguments[0];
                var canExecute = @interface.GenericTypeArguments[1];

                var executeMethod = @interface.GetRuntimeMethod("Handle", new[] { command });

                if (executeMethod != null)
                {
                    var executeStrategy = new ExecuteStrategy(executeMethod, canExecute, componentContext);
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

        public bool Matches(object instance)
        {
            return _subscribedDataContext.Target == instance;
        }

        public bool IsDead => _subscribedDataContext.Target == null;
    }
}
