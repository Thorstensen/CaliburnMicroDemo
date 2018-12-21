using Caliburn.Micro.Demo.EventAggregation;
using Caliburn.Micro.Demo.Shopping.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class CustomerShellViewModel : Conductor<IScreen>.Collection.AllActive, ICanHandle<RemoveCustomerCommand, AlwaysTrueGuard>
    {
        private readonly IEventAggregator _eventAggregator;

        public CustomerShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void AddCustomer()
        {
            var vm = new CustomerViewModel(_eventAggregator);
            Items.Add(vm);
            Items.ToList().ForEach(i => i.Activate());
        }

        public void Handle(RemoveCustomerCommand command)
        {
            var customerViewModel = Items.FirstOrDefault(p => p.GetHashCode() == command.HashCode);
            Items.Remove(customerViewModel);
            DeactivateItem(customerViewModel, true);
        }
    }
}
