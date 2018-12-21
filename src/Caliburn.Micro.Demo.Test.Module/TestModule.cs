using Autofac;
using Caliburn.Micro.Demo.Contracts;
using System.ComponentModel.Composition;

namespace Caliburn.Micro.Demo.Test.Module
{
    [Export(typeof(IModule))]
    public class TestModule : IModule
    {
        public void RegisterComponents(ContainerBuilder builder)
        {
           
        }
    }
}
