using Autofac;
using Caliburn.Micro.Demo.EventAggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterCommandGuard<TCommandGuard>(this ContainerBuilder builder)
           where TCommandGuard : IExecuteGuard
        {
            var type = typeof(TCommandGuard);
            var typeName = type.FullName;
            builder.RegisterType<TCommandGuard>().Keyed<IExecuteGuard>(typeName);
        }
    }
}
