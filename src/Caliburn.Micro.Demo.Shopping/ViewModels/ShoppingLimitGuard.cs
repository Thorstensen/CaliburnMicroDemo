using Caliburn.Micro.Demo.EventAggregation;
using Caliburn.Micro.Demo.Services;
using Caliburn.Micro.Demo.Shopping.Events;

namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class ShoppingLimitGuard : IExecuteGuard
    {
        private readonly IBasketService _basketService;

        public ShoppingLimitGuard(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public bool CanExecute(object obj)
        {
            var @event = obj as BasketUpdatedEvent;
            return @event.TotalAmount < _basketService.GetMaxBasketSize();
        }
    }
}
