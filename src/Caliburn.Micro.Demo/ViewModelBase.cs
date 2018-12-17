using Caliburn.Micro.Demo.EventAggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo
{
    public abstract class ViewModelBase : PropertyChangedBase
    {
        protected readonly IEventAggregator EventAggregator;

        public ViewModelBase(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        ~ViewModelBase()
        {
            EventAggregator.Unsubscribe(this);
        }
    }
}
