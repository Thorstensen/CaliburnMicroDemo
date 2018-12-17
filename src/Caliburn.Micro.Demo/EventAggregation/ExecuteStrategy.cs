using System;
using System.Reflection;


namespace Caliburn.Micro.Demo.EventAggregation
{
    public class ExecuteStrategy
    {
        public ExecuteStrategy(MethodInfo command, Type canExecuteType)
        {
            Command = command;
            CanExecuteGuard = canExecuteType;
        }

        public bool CanExecute(object message)
        {
            var instance = (IExecuteGuard)Activator.CreateInstance(CanExecuteGuard);
            return instance.CanExecute(message);
        }

        public void Execute(object target, object message)
        {
            Command.Invoke(target, new[] { message });
        }

        public MethodInfo Command { get; }
        public Type CanExecuteGuard { get; }
    }
}
