using Caliburn.Micro.Demo.Shopping.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Caliburn.Micro.Demo.Shopping.ViewModels
{
    public class ProductViewModel
    {
        private readonly IEventAggregator _eventAggregator;
      
        public ProductViewModel(ObservableCollection<IForSaleItem> items)
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            SellableItems = items;
        }

        public ObservableCollection<IForSaleItem> SellableItems { get; set; }
    }
}
