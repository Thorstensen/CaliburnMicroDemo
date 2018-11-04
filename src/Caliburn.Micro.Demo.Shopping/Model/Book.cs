using Caliburn.Micro.Demo.Shopping.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.Model
{
    public class Book : IForSaleItem
    {
        public Book(string bookName, string description, double price)
        {
            ItemName = bookName;
            Description = description;
            Price = price;
        }

        public string ItemName { get; } 
        public string Description { get; }
        public double Price { get; }
    }
}
