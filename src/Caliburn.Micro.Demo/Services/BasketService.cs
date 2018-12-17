using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Services
{
    public class BasketService : IBasketService
    {
        public int GetMaxBasketSize()
        {
            return 15000;
        }
    }
}
