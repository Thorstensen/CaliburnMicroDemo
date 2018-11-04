using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.Contracts
{
    public interface IAddItemToBasketCommand
    {
        string Name { get; set; }
        double Price { get; set; }
        string CompanyName { get; set; }
        int Quantity { get; set; }
    }
}
