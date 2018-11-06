using Autofac;
using Caliburn.Micro.Demo.Companies.Module.ViewModels;
using Caliburn.Micro.Demo.Contracts;
using System.ComponentModel.Composition;

namespace Caliburn.Micro.Demo.Companies.Module
{
    [Export(typeof(IModule))]
    public class Module : IModule
    {
        public void RegisterComponents(ContainerBuilder builder)
        {
           
        }
    }
}
