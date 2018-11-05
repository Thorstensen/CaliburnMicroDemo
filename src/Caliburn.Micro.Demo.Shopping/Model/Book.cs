using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Windows.Media.Imaging;

namespace Caliburn.Micro.Demo.Shopping.Model
{
    public class Book : ForSaleItem
    {
        public Book(string bookName, string description, double price, string thumbnail)
            : base(bookName, description, price, thumbnail)
        {
        }
    }
}
