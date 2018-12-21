using Caliburn.Micro.Demo.EventAggregation;
using Caliburn.Micro.Demo.Shopping.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class CustomerViewModel : Screen, ICanHandle<UpdateCustomerEvent, AlwaysTrueGuard>
    {
        private readonly IEventAggregator _eventAggregator;

        public CustomerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Allocation = new byte[1024 * 1024 * 10]; // 10 mb allocated to testing
        }

        protected override void OnDeactivate(bool close)
        {
            _eventAggregator.Unsubscribe(this);
            base.OnDeactivate(close);
        }

        protected override void OnActivate()
        {
            _eventAggregator.Subscribe(this);
            base.OnActivate();
        }

        public void Handle(UpdateCustomerEvent command)
        {
            ++Count;
        }

        public void RemoveThis()
        {
            _eventAggregator.PublishOnUIThread(new RemoveCustomerCommand(GetHashCode()));
        }

        public byte[] Allocation { get; set; }

        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                NotifyOfPropertyChange(() => Count);
            }
        }
    }
}
