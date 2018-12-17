using Autofac;
using Caliburn.Micro.Demo.Contracts;
using Caliburn.Micro.Demo.EventAggregation;
using Caliburn.Micro.Demo.Shopping.Extensions;
using Caliburn.Micro.Demo.Shopping.Store.Amazon.Module.Model;
using Caliburn.Micro.Demo.Shopping.ViewModels;
using System.ComponentModel.Composition;

namespace Caliburn.Micro.Demo.Shopping.Store.Amazon.Module
{
    [Export(typeof(IModule))]
    public class AmazonModule : IModule
    {
        public void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterStore<AmazonStore>();
            builder.RegisterCommandGuard<CanHandleAddItemsToBaskedCommand>();
            builder.RegisterCommandGuard<ShoppingLimitGuard>();
        }
    }
}
