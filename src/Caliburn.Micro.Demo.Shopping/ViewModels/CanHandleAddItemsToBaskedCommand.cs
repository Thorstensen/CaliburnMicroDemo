using Caliburn.Micro.Demo.EventAggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class CanHandleAddItemsToBaskedCommand : IExecuteGuard
    {
        public CanHandleAddItemsToBaskedCommand(IEventAggregator ea)
        {

        }

        public bool CanExecute(object message)
        {
            return true;
        }
    }
}
