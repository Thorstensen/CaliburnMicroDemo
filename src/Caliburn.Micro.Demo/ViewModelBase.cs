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
            var implementsHandle = this is IHandle;
            if (implementsHandle)
                EventAggregator.Subscribe(this);
        }
        ~ViewModelBase()
        {
            EventAggregator.Unsubscribe(this);
        }
    }
}
