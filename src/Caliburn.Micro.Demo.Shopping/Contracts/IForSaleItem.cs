using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Contracts
{
    public interface IForSaleItem
    {
        string ItemName { get; }
        string Description { get; }
        BitmapImage Thumbnail { get; } 
        double Price { get; }

        void AddToBasket();
    }
}
