namespace Caliburn.Micro.Demo.EventAggregation
{
    /// <summary>
    /// Specifices if a command or event can be executed.
    /// </summary>
    public interface IExecuteGuard
    {
        /// <summary>
        /// If true is returned, <see cref="ICanHandle{TCommand, TExecuteGuard}.Handle(TCommand)"/> will be executed
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True or false wheter the <paramref name="obj"/> fulfills the conditions given by the implementation</returns>
        bool CanExecute(object obj);
    }
}
