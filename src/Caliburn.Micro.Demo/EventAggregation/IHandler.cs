using System;

namespace Caliburn.Micro.Demo.EventAggregation
{
    public interface IHandler
    {
        bool Handles(Type t);
        int ReferencedHashcode { get; }
    }
}
