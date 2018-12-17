using Autofac;
using System;
using System.Reflection;


namespace Caliburn.Micro.Demo.EventAggregation
{
    public class ExecuteStrategy
    {
        private readonly IComponentContext _componentContext;

        public ExecuteStrategy(MethodInfo command, Type canExecuteType, IComponentContext componentContext)
        {
            Command = command;
            CanExecuteGuard = canExecuteType;
            _componentContext = componentContext;
        }

        public bool CanExecute(object message)
        {
            var type = _componentContext.Resolve(CanExecuteGuard) as IExecuteGuard;
            if (type == null)
                throw new Exception($"{CanExecuteGuard.FullName} does not implement interface {nameof(IExecuteGuard)}");
            
            return type.CanExecute(message);
        }

        public void Execute(object target, object message)
        {
            Command.Invoke(target, new[] { message });
        }

        public MethodInfo Command { get; }
        public Type CanExecuteGuard { get; }
    }
}
