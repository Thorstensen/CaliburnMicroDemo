using Caliburn.Micro.Demo.EventAggregation;
using Caliburn.Micro.Demo.Shopping.Events;

namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class ShoppingLimitGuard : IExecuteGuard
    {
        public bool CanExecute(object obj)
        {
            var @event = obj as BasketUpdatedEvent;
            return @event.TotalAmount < 25000;
        }
    }
}
