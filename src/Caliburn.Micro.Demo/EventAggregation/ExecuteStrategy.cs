using Autofac.Features.Indexed;
using System;
using System.Reflection;

namespace Caliburn.Micro.Demo.EventAggregation
{
    public class ExecuteStrategy
    {
        private readonly IIndex<string, IExecuteGuard> _registedGuards;

        public ExecuteStrategy(MethodInfo command, Type canExecuteType, IIndex<string, IExecuteGuard> registedGuards)
        {
            Command = command;
            CanExecuteGuard = canExecuteType;
            _registedGuards = registedGuards;
        }

        public bool CanExecute(object message)
        {
            IExecuteGuard resolvedType = null;
            var name = CanExecuteGuard.FullName;
            if (!_registedGuards.TryGetValue(name, out resolvedType))
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

            return resolvedType.CanExecute(message);
        }

        public void Execute(object target, object message)
        {
            Command.Invoke(target, new[] { message });
        }

        public MethodInfo Command { get; }
        public Type CanExecuteGuard { get; }
    }
}
