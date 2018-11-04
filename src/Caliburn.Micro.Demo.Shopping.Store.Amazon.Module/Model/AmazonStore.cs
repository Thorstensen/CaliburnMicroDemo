using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Caliburn.Micro.Demo.Shopping.Contracts;
using Caliburn.Micro.Demo.Shopping.Model;

namespace Caliburn.Micro.Demo.Shopping.Store.Amazon.Module.Model
{
    public class AmazonStore : Shopping.Model.Store
    {
        const string LogoUri = "pack://application:,,,/Caliburn.Micro.Demo.Shopping.Amazon.Module;component/Resources/Images/amazon.png";

        public override string StoreName => "Amazon";
        public override string StoreDescription => "Amazon is an electronic commerce and cloud computing company. Selling books, DVDs, Clothing, Audiobooks and cloud services";
        public override BitmapImage StoreLogo => new BitmapImage(new Uri(LogoUri));

        public override IEnumerable<IForSaleItem> GetSellableItems()
        {
            return new List<IForSaleItem>()
            {
                new Book("Domain Driven Design by Eric Evans", "Teaches the ideas behind DDD", 35d),
                new Book("Clean Code by Uncle Bob", "Clean design in pratice", 25d)
            };
        }
    }
}
