using Autofac;
using Caliburn.Micro.Demo.Shopping.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Caliburn.Micro.Demo.Shopping.Extensions
{
    public static class ContainerBuilderExtensions
    {
        const string View = "_View";

        public static void RegisterStore<TStore, TDetailedView>(this ContainerBuilder builder)
            where TStore : IStore, new()
        {
            var store = new TStore();

            builder.RegisterType<TStore>().As<IStore>().Named(store.StoreName, typeof(TStore));
            builder.RegisterType<TDetailedView>().Named(store.StoreName + View, typeof(UserControl));
        }
    }
}
