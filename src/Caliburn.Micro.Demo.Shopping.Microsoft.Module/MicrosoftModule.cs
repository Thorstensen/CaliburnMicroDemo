using Autofac;
using Caliburn.Micro.Demo.Contracts;
using Caliburn.Micro.Demo.Shopping.Extensions;
using Caliburn.Micro.Demo.Shopping.Microsoft.Module.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Shopping.Microsoft.Module
{
    [Export(typeof(IModule))]
    public class MicrosoftModule : IModule
    {
        public void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterStore<MicrosoftStore>();
        }
    }
}
