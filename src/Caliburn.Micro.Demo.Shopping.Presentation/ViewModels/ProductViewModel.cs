using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.Presentation.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(IObservableCollection<IForSaleItem> items)
        {
            var eventAggregator = IoC.Get<IEventAggregator>();
        }
    }
}
