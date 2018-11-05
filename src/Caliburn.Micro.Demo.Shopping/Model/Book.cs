using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Model
{
    public class Book : IForSaleItem
    {
        public Book(string bookName, string description, double price, BitmapImage thumbnail)
        {
            ItemName = bookName;
            Description = description;
            Price = price;
            Thumbnail = thumbnail;
        }

        public string ItemName { get; } 
        public string Description { get; }
        public double Price { get; }

        public BitmapImage Thumbnail { get; }
    }
}
