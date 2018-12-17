using Autofac;
using Caliburn.Micro.Demo.EventAggregation;
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

        public static void RegisterCommandGuard<TCommandGuard>(this ContainerBuilder builder)
            where TCommandGuard : IExecuteGuard
        {
            var type = typeof(TCommandGuard);
            var typeName = type.FullName;
            builder.RegisterType<TCommandGuard>().Named(typeName, typeof(IExecuteGuard));
        }
    }
}
