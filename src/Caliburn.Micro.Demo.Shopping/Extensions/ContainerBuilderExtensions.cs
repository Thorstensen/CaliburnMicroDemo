using Autofac;
using Caliburn.Micro.Demo.Shopping.Contracts;

namespace Caliburn.Micro.Demo.Shopping.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterStore<TStore>(this ContainerBuilder builder)
            where TStore : IStore, new()
        {
            builder.RegisterType<TStore>().As<IStore>();
        }
    }
}
