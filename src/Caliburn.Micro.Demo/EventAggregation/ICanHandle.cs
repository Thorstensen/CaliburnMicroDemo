namespace Caliburn.Micro.Demo.EventAggregation
{
    public interface ICanHandle<TCommand, TExecuteGuard> where TExecuteGuard : IExecuteGuard 
    {
        void Handle(TCommand command);
    }
}
