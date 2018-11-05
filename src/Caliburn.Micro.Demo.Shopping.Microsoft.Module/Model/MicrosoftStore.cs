using Caliburn.Micro.Demo.Shopping.Contracts;
using Caliburn.Micro.Demo.Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Microsoft.Module.Model
{
    public class MicrosoftStore : BaseStore
    {
        const string LogoUri = "pack://application:,,,/Caliburn.Micro.Demo.Shopping.Microsoft.Module;component/Resources/Images/microsoft.png";

        public override string StoreName => "Microsoft Store";

        public override string StoreDescription => "The Microsoft Store offers Signature PCs and tablets like the Microsoft Surface and from third parties such as HP, Acer, Dell, Lenovo, and VAIO.";

        public override BitmapImage StoreLogo => new BitmapImage(new Uri(LogoUri));

        public override async Task<IEnumerable<IForSaleItem>> GetSellableItemsAsync()
        {
            //Synchron now, will be async soon....
            var list = new List<IForSaleItem>();
            list.Add(new GenericProduct("Microsoft Surface Pro 3", "", 2500d,
                @"https://gts.jo/image/cache/catalog/products/laptops/Microsoft/microsoft-surface-pro-3-128x128.jpg"));

            list.Add(new GenericProduct("Xbox One", "", 250d,
                @"https://lazybee.com/images/files/small/5dx7Th7Z6zL4.jpg"));

            list.Add(new GenericProduct("Office 360 Licence", "", 100d,
                @"http://icons.iconarchive.com/icons/martz90/circle/512/office-2013-icon.png"));

            return list;
        }
    }
}
