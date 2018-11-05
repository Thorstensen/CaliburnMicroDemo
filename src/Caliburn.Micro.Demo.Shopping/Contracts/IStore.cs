using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Contracts
{
    public interface IStore
    {
        string StoreName { get; }
        string StoreDescription { get; }
        BitmapImage StoreLogo { get; }
        ObservableCollection<IForSaleItem> ForSale { get; }
        void Open();
    }
}
