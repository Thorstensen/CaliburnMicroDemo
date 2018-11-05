using Caliburn.Micro.Demo.Contracts;
using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using System.Linq;
using Caliburn.Micro.Demo.Shopping.ViewModels;

namespace Caliburn.Micro.Demo.Host.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IEventAggregator _aggregator;

        public ShellViewModel(IEventAggregator aggregator, IEnumerable<IStore> stores, MyBasketViewModel basketModel, 
            MyBasketNotificationBarViewModel notificationbar)
        {
            _aggregator = aggregator;
            Stores = new ObservableCollection<IStore>(stores);
            Basket = basketModel;
            NotificationBar = notificationbar;
        }

        private ObservableCollection<IStore> _stores;
        public ObservableCollection<IStore> Stores
        {
            get { return _stores; }
            set
            {
                _stores = value;
                NotifyOfPropertyChange(() => Stores);
            }
        }

        public object Basket { get; set; }
        public object NotificationBar { get; set; }
    }
}
