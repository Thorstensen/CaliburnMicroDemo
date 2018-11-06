using Caliburn.Micro.Demo.Shopping.Contracts;
using Caliburn.Micro.Demo.Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Apple.Module.Model
{
    public class AppleStore : BaseStore
    {

        const string LogoUri = "pack://application:,,,/Caliburn.Micro.Demo.Shopping.Apple.Module;component/Resources/Images/apple.png";

        public override string StoreName => "Apple Store";

        public override string StoreDescription => "The stores sell Mac personal computers, iPhone smartphones, iPad tablet computers, iPod portable media players, Apple Watch smartwatches and Apple TV digital media players.";

        public override BitmapImage StoreLogo => new BitmapImage(new Uri(LogoUri));

        public override async Task<IEnumerable<IForSaleItem>> GetSellableItemsAsync()
        {
            //Synchron now, will be async soon....
            var list = new List<IForSaleItem>();
            list.Add(new GenericProduct("iPhone X", "", 1200d,
                @"https://cdn.pji.nu/product/standard/800/4471962.jpg"));

            list.Add(new GenericProduct("Mac", "", 140d,
                @"https://www.macstoreuk.com/wp-content/uploads/2017/06/MacStore_iMac_FeaturedProducts_500px-128x128.jpg"));

            list.Add(new GenericProduct("iWatch", "", 1000d,
                @"http://www.qdossound.com/files/styles/swatch_large/public/user-files/variants/protection/images/11-17/OptiGuard_Apple_Watch_38mm_Curve_Black_3.jpg?itok=RX5wb-0e"));

            return list;
        }
    }
}
