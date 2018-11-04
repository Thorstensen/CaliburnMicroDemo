using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.Contracts
{
    public interface IForSaleItem
    {
        string ItemName { get; }
        string Description { get; }
        double Price { get; }
    }
}
