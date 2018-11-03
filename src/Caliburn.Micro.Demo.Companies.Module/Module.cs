using Autofac;
using Caliburn.Micro.Demo.Companies.Module.ViewModels;
using Caliburn.Micro.Demo.Companies.Module.Views;
using Caliburn.Micro.Demo.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Companies.Module
{
    [Export(typeof(IModule))]
    public class Module : IModule
    {
        public void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyListViewModel>().As<IContent>();
        }
    }
}
