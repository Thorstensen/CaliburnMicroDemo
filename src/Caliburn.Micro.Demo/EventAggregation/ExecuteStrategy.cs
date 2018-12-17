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
            object resolvedType = null;
            var name = CanExecuteGuard.FullName;
            if(!_componentContext.TryResolveNamed(name, typeof(IExecuteGuard), out resolvedType))
            {
                try
                {
                    resolvedType = (IExecuteGuard)Activator.CreateInstance(CanExecuteGuard);
                }
                catch (Exception e)
                {
                    throw new Exception($"Cannot locate {name} in container nor create an instance of it. See inner exception:", e);
                }
            }

            return ((IExecuteGuard)resolvedType).CanExecute(message);
        }

        public void Execute(object target, object message)
        {
            Command.Invoke(target, new[] { message });
        }

        public MethodInfo Command { get; }
        public Type CanExecuteGuard { get; }
    }
}
