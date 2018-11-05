using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Model
{
    public class GenericProduct : ForSaleItem
    {
        public GenericProduct(string itemName, string description, double price, string thumbnailurl)
            : base(itemName, description, price, thumbnailurl)
        {
        }
    }
}
