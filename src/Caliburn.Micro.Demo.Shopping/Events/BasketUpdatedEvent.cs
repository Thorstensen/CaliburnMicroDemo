using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.Events
{
    public class BasketUpdatedEvent
    {
        public BasketUpdatedEvent(int totalCountInBasket, int totalAmount)
        {
            _totalCountInBasket = totalCountInBasket;
            _totalAmount = totalAmount;
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

        private readonly int _totalAmount;
        public int TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                TotalAmount = value;
            }
        }
    }
}
