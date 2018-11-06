using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Model
{
    public abstract class BaseStore : PropertyChangedBase, IStore
    {
        public BaseStore()
        {
            ForSale = new ObservableCollection<IForSaleItem>();
            LoadSellableItems();
        }

        private async void LoadSellableItems()
        {
            var items = await GetSellableItemsAsync();
            ForSale = new ObservableCollection<IForSaleItem>(items);
        }
        public abstract string StoreName { get; }
        public abstract string StoreDescription { get; }
        public abstract BitmapImage StoreLogo { get; }
        public abstract Task<IEnumerable<IForSaleItem>> GetSellableItemsAsync();

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
