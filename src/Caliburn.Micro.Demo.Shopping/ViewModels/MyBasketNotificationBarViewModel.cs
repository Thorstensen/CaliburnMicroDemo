using Caliburn.Micro.Demo.Shopping.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class MyBasketNotificationBarViewModel : ViewModelBase, IHandle<BasketUpdatedEvent>
    {


        public MyBasketNotificationBarViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {

        }

        public void Handle(BasketUpdatedEvent message)
        {
            NumberOfItems = message.TotalCountInBasket;
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
    }
}
