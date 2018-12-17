namespace Caliburn.Micro.Demo
{
    public abstract class ViewModelBase : PropertyChangedBase
    {
        protected readonly IEventAggregator EventAggregator;

        public ViewModelBase(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        ~ViewModelBase()
        {
            EventAggregator.Unsubscribe(this);
        }
    }
}
