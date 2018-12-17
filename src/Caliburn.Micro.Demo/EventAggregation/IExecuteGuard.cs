namespace Caliburn.Micro.Demo.EventAggregation
{
    public interface IExecuteGuard
    {
        bool CanExecute(object obj);
    }
}
