namespace Caliburn.Micro.Demo.EventAggregation
{
    public class AlwaysTrueGuard : IExecuteGuard
    {
        public bool CanExecute(object command) => true;
    }
}
