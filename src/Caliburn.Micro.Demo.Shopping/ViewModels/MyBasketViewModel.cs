using Caliburn.Micro.Demo.EventAggregation;
using Caliburn.Micro.Demo.Shopping.Commands;
using Caliburn.Micro.Demo.Shopping.Contracts;
using Caliburn.Micro.Demo.Shopping.Events;
using System.Collections.ObjectModel;
using System.Linq;

namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class MyBasketViewModel : ViewModelBase, ICanHandle<AddItemToBasketCommand, CanHandleAddItemsToBaskedCommand>
    {
        public MyBasketViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            EventAggregator.Subscribe(this);
        }

        public void Handle(AddItemToBasketCommand message)
        {
            Basket.Add(message.Item);
            EventAggregator.PublishOnUIThread(new BasketUpdatedEvent(Basket.Count, (int)Basket.Sum(b => b.Price)));
        }
    
        private ObservableCollection<IForSaleItem> _basket = new ObservableCollection<IForSaleItem>();
        public ObservableCollection<IForSaleItem> Basket
        {
            get { return _basket; }
            set
            {
                _basket = value;
                NotifyOfPropertyChange(() => Basket);
            }
        }
    }
}
