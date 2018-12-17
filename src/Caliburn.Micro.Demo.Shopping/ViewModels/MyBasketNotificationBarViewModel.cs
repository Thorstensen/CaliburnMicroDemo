using Caliburn.Micro.Demo.Shopping.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro.Demo.EventAggregation;
 
namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class MyBasketNotificationBarViewModel : ViewModelBase, ICanHandle<BasketUpdatedEvent, ShoppingLimitGuard>
    {
        public MyBasketNotificationBarViewModel(IEventAggregator eventAggregator, MyBasketViewModel basket) : base(eventAggregator)
        {
            BasketOverview = basket;
            EventAggregator.Subscribe(this);
        }

        public void Handle(BasketUpdatedEvent message)
        {
            NumberOfItems = message.TotalCountInBasket;
            TotalAmount = message.TotalAmount;
        }

        private MyBasketViewModel _basketOverview;
        public MyBasketViewModel BasketOverview
        {
            get => _basketOverview;
            set
            {
                _basketOverview = value;
                NotifyOfPropertyChange(() => BasketOverview);
            }
        }

        private int _numberOfItems;
        public int NumberOfItems
        {
            get { return _numberOfItems; }
            set
            {
                _numberOfItems = value;
                NotifyOfPropertyChange(() => NumberOfItems);
            }
        }

        private int _totalAmount;
        public int TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                NotifyOfPropertyChange(() => TotalAmount);
            }
        }
    }
}
