using System;

namespace Caliburn.Micro.Demo.Shopping.Events
{
    public class RemoveCustomerCommand
    {
        public RemoveCustomerCommand(int hashCode)
        {
            HashCode = hashCode;
        }

        public int HashCode { get; }
    }
}
