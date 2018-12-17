using Caliburn.Micro.Demo.EventAggregation;
using Caliburn.Micro.Demo.Shopping.Contracts;

namespace Caliburn.Micro.Demo.Shopping.Commands
{
    public class AddItemToBasketCommand : ISubscribable
    {
        public AddItemToBasketCommand(IForSaleItem item)
        {
            Item = item;
        }

        public IForSaleItem Item { get;}
    }
}
