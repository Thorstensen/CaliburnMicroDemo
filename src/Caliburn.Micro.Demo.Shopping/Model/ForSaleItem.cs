using Caliburn.Micro.Demo.Shopping.Commands;
using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Net;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Model
{
    public abstract class ForSaleItem : IForSaleItem
    {
        private readonly IEventAggregator _eventAggregator;

        public ForSaleItem(string itemName, string description, double price, string thumbnailUrl)
        {
            ItemName = itemName;
            Description = description;
            Price = price;
            Thumbnail = DownloadImage(thumbnailUrl);

            _eventAggregator = IoC.Get<IEventAggregator>();
        }

        public string ItemName { get; }
        public string Description { get; }
        public BitmapImage Thumbnail { get; }
        public double Price { get; }

        public void AddToBasket()
        {
            _eventAggregator.PublishOnUIThread(new AddItemToBasketCommand(this));
        }

        private BitmapImage DownloadImage(string url)
        {
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(url);

            return ToImage(imageBytes);
        }

        private BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
