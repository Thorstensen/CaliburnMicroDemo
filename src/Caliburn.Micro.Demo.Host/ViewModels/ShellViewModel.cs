using Caliburn.Micro.Demo.Contracts;
using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using System.Linq;
using Caliburn.Micro.Demo.Shopping.ViewModels;
using System.Timers;
using Caliburn.Micro.Demo.Shopping.Events;
using System;
using Caliburn.Micro.Demo.EventAggregation;

namespace Caliburn.Micro.Demo.Host.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IEventAggregator _aggregator;
        private readonly Timer _timer;

        public ShellViewModel(IEventAggregator aggregator, IEnumerable<IStore> stores,
            MyBasketNotificationBarViewModel notificationbar, CustomerShellViewModel customerShellView)
        {
            _aggregator = aggregator;
            _aggregator.Subscribe(this);
            NotificationBar = notificationbar;
            CustomerShell = customerShellView;
            Stores = new ObservableCollection<IStore>(stores);
            _timer = new Timer
            {
                Interval = 500
            };

            _timer.Enabled = true;
            _timer.Elapsed += (s, e) =>
            {
                _aggregator.PublishOnUIThread(new UpdateCustomerEvent());
            };
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

        public object NotificationBar { get; set; }
        public object CustomerShell { get; set; }
    }
}
