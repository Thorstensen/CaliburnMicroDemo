using Caliburn.Micro.Demo.EventAggregation;
using Caliburn.Micro.Demo.Shopping.Commands;
using Caliburn.Micro.Demo.Shopping.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class ShoppingLimitGuard : IExecuteGuard
    {
        public bool CanExecute(object command)
        {
            var @event = command as BasketUpdatedEvent;
            return @event.TotalAmount < 50000;
        }
    }
}
