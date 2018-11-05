using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.Events
{
    public class BasketUpdatedEvent
    {
        public BasketUpdatedEvent(int totalCountInBasket)
        {
            _totalCountInBasket = totalCountInBasket;
        }

        private readonly int _totalCountInBasket;
        public int TotalCountInBasket
        {
            get { return _totalCountInBasket; }
            set
            {
                TotalCountInBasket = value;
            }
        }
    }
}
