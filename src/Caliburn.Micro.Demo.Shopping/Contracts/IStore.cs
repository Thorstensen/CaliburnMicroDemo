using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Contracts
{
    public interface IStore
    {
        string StoreName { get; }
        string StoreDescription { get; }
        BitmapImage StoreLogo { get; }
        ObservableCollection<IForSaleItem> ForSale { get; }
    }
}
