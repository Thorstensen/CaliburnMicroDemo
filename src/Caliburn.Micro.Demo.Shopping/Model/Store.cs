using Caliburn.Micro.Demo.Contracts;
using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Model
{
    public abstract class Store<TDetailedView> : PropertyChangedBase, IStore
        where TDetailedView : IStoreDetailedView, new()
    {
        public Store()
        {
            ForSale = new ObservableCollection<IForSaleItem>(GetSellableItems());
        }

        public void Open()
        {
            var windowManager = new WindowManager();
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.MinWidth = 450;
            settings.MinHeight = 500;
            settings.Title = $"{StoreName}";
            windowManager.ShowWindow(new TDetailedView(), null, settings);
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
