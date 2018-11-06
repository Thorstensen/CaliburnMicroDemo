using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml;
using Caliburn.Micro.Demo.Shopping.Contracts;
using Caliburn.Micro.Demo.Shopping.Model;

namespace Caliburn.Micro.Demo.Shopping.Store.Amazon.Module.Model
{
    public class AmazonStore : BaseStore
    {
        const string LogoUri = "pack://application:,,,/Caliburn.Micro.Demo.Shopping.Amazon.Module;component/Resources/Images/amazon.png";

        public override string StoreName => "Amazon";
        public override string StoreDescription => "Amazon is an electronic commerce and cloud computing company. Selling books, DVDs, Clothing, Audiobooks and cloud services";
        public override BitmapImage StoreLogo => new BitmapImage(new Uri(LogoUri));

        public override Task<List<IForSaleItem>> GetSellableItemsAsync()
        {
            return Task.Run(() =>
            {
                var amazonRss = @"https://www.amazon.in/rss/bestsellers/books";
                XmlReader reader = XmlReader.Create(amazonRss);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                var list = new List<IForSaleItem>();

                foreach (var item in feed.Items)
                {
                    var title = Regex.Match(item.Title.Text, "(?<=\\#\\d{1,2}: ).*").Groups[0].Value;
                    var summary = item.Summary.Text;
                    var url = Regex.Match(summary, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
                    var randomPrice = new Random();
                    var price = randomPrice.Next(10, 100);

                    var book = new Book(title, summary, price, url);
                    list.Add(book);
                }

                return list;
            });
        }
    }
}
