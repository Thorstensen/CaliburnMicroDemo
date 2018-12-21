namespace Caliburn.Micro.Demo.EventAggregation
{
    /// <summary>
    /// Specifies that a class can handle a specific command or event given that condidtions in <typeparamref name="TExecuteGuard"/> is fulfilled
    /// </summary>
    /// <typeparam name="TCommand">Type to subscribe on</typeparam>
    /// <typeparam name="TExecuteGuard">Guard to protect subscribtion method. If always true, use <see cref="AlwaysTrueGuard"/></typeparam>
    public interface ICanHandle<TCommand, TExecuteGuard> where TExecuteGuard : IExecuteGuard 
    {
        /// <summary>
        /// Handle <typeparamref name="TCommand"/>
        /// </summary>
        /// <param name="command"></param>
        void Handle(TCommand command);
    }   
}
