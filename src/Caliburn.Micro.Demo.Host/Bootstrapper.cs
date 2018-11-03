using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Autofac;
using Caliburn.Micro.Autofac;
using Caliburn.Micro.Demo.Contracts;
using Caliburn.Micro.Demo.Host.ViewModels;
using System.Linq;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using System;
using System.Collections.Generic;
using Autofac.Integration.Mef;
using System.IO;

namespace Caliburn.Micro.Demo.Host
{
    public class Bootstrapper : AutofacBootstrapper<IShell>
    {
        private List<IModule> _modules = null;
        private ContainerBuilder _containerBuilder = new ContainerBuilder();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            var containerBuilder = new ContainerBuilder();
            var composablePartCatalog = GetComposableCatalog();
            containerBuilder.RegisterComposablePartCatalog(composablePartCatalog);

            using (var container = containerBuilder.Build())
            {
                _modules = container.Resolve<IEnumerable<IModule>>().ToList();
                _modules.ForEach(module =>
                {
                    module.RegisterComponents(builder);
                });
            }

            RegisterServices(builder);
            base.ConfigureContainer(builder);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*Module.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));

            allAssemblies.AddRange(base.SelectAssemblies());
            return allAssemblies;
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
        }

        private static ComposablePartCatalog GetComposableCatalog()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            return new DirectoryCatalog(Path.GetDirectoryName(path));
        }
    }
}
