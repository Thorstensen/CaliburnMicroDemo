using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.EventAggregation
{
    //public class ExtendedEventAggregator : EventAggregator
    //{
    //    private List<Handler> _handlers = new List<Handler>();

    //    public override void Subscribe(object subscriber)
    //    {
    //        var viewModel = subscriber;
    //        base.Subscribe(subscriber);
    //    }

    //    public void SubscribeOn<TEvent>(object subscriber, Expression<Func<TEvent, bool>> predicate)
    //    {
    //        var compliedPredicate = predicate.Compile();
    //        var handler = new Handler(subscriber, typeof(TEvent), compliedPredicate);
    //        _handlers.Add(handler);
    //    }

    //    public override void Publish(object message, Action<System.Action> marshal)
    //    {
    //        foreach(var handler in _handlers)
    //        {
    //            handler.Handle(message.GetType(), message);
    //        }
    //    }
    //}

    //public class Handler
    //{
    //    private readonly WeakReference _subscriber;
    //    private readonly Func<object, bool> _predicate;
    //    private readonly object _type;
    //    private readonly Dictionary<Type, Tuple<Func<object, bool>, MethodInfo>> _supportedHandlers = new Dictionary<Type, Tuple<Func<object, bool>, MethodInfo>>();

    //    public Handler(object subscriber, Type type, Func<object, bool> predicate) 
    //    {
    //        _subscriber = new WeakReference(subscriber);
    //        _predicate = predicate;
    //        _type = type;

    //        var interfaces = subscriber.GetType()
    //                                .GetTypeInfo()
    //                                .ImplementedInterfaces.Where(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandle<>));

    //        foreach(var @interface in interfaces)
    //        {
    //            var argument = @interface.GetTypeInfo().GenericTypeArguments[0];
    //            var method = @interface.GetRuntimeMethod("Handle", new[] { type });

    //            if(method != null)
    //            {
    //                _supportedHandlers[type] = new Tuple<Func<object, bool>, MethodInfo>(predicate, method);
    //            }
    //        }
    //    }

    //    public Task Handle(Type messageType, object message)
    //    {
    //        var target = _subscriber.Target;
    //        var castTo = Convert.ChangeType(message, messageType);
    //        var tasks = _supportedHandlers
    //            .Where(handler => handler.Key.GetTypeInfo().IsAssignableFrom(messageType.GetTypeInfo()) &&
    //                              handler.Value.Item1.Invoke(castTo))
    //            .Select(pair => pair.Value.Item2.Invoke(target, new[] { message }))
    //            .Select(result => (Task)result)
    //            .ToList();

    //        return Task.WhenAll(tasks);
    //    }
    //}
}
