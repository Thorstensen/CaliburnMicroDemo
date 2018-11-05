using Caliburn.Micro.Demo.Shopping.Contracts;
using Caliburn.Micro.Demo.Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Google.Module.Model
{
    class GoogleStore : BaseStore
    {
        const string LogoUri = "pack://application:,,,/Caliburn.Micro.Demo.Shopping.Google.Module;component/Resources/Images/google.png";

        public override string StoreName => "Google Store";

        public override string StoreDescription => "Google Store provides a variety of products such as Chromecast, Google Pixel series and Google Home";

        public override BitmapImage StoreLogo => new BitmapImage(new Uri(LogoUri));

        public override async Task<IEnumerable<IForSaleItem>> GetSellableItemsAsync()
        {
            //Synchron now, will be async soon....
            var list = new List<IForSaleItem>();
            list.Add(new GenericProduct("Google Chromecast", "", 45d,
                @"https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/Chromecast-2015.jpg/300px-Chromecast-2015.jpg"));

            list.Add(new GenericProduct("Google Home", "", 140d, 
                @"https://i5.walmartimages.com/asr/494433a6-f130-47d7-87c4-a49ddadb3f8c_4.bfeee59991749977a7d925b2cfaa7886.jpeg?odnHeight=450&odnWidth=450&odnBg=FFFFFF"));

            list.Add(new GenericProduct("Google Pixel 3", "", 1000d,
                @"https://assets.mspcdn.net/w_128,h_128,c_pad,b_white,q_auto:low,fl_lossy,f_auto/c/13633-3-1"));

            return list;
        }
    }
}
