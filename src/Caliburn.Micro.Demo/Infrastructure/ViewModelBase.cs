using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Infrastructure
{
    public abstract class ViewModelBase : PropertyChangedBase
    {
        private readonly IEventAggregator _eventAggregator;

        public ViewModelBase(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            var implementsHandle = this is IHandle;
            if (implementsHandle)
                _eventAggregator.Subscribe(this);
        }

        ~ViewModelBase()
        {
            _eventAggregator.Unsubscribe(this);
        }
    }
}
