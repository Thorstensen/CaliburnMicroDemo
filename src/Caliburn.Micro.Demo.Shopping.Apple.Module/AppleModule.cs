using Autofac;
using Caliburn.Micro.Demo.Contracts;
using Caliburn.Micro.Demo.Shopping.Apple.Module.Model;
using Caliburn.Micro.Demo.Shopping.Extensions;
using System.ComponentModel.Composition;

namespace Caliburn.Micro.Demo.Shopping.Apple.Module
{
    [Export(typeof(IModule))]
    public class AppleModule : IModule
    {
        public void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterStore<AppleStore>();
        }
    }
}
