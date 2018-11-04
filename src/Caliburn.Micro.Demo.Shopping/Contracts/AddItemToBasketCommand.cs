using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.Contracts
{
    class AddItemToBasketCommand : IAddItemToBasketCommand
    {
        public AddItemToBasketCommand(string name, double price, string companyName, int quantity)
        {
            Name = name;
            Price = price;
            CompanyName = companyName;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public string CompanyName { get; set; }
        public int Quantity { get; set; }
    }
}
