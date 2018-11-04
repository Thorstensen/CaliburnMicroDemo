using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Model
{
    public abstract class Store : PropertyChangedBase, IStore
    {
        public Store()
        {
            ForSale = new ObservableCollection<IForSaleItem>(GetSellableItems());
        }

        public abstract string StoreName { get; }
        public abstract string StoreDescription { get; }
        public abstract BitmapImage StoreLogo { get; }
        public abstract IEnumerable<IForSaleItem> GetSellableItems();
      
        private ObservableCollection<IForSaleItem> _forSale;
        public ObservableCollection<IForSaleItem> ForSale
        {
            get { return _forSale; }
            set
            {
                _forSale = value;
                NotifyOfPropertyChange(() => ForSale);
            }
        }
    }
}
