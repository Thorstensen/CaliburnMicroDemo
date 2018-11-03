using System.Windows;
using Caliburn.Micro.Autofac;
using Caliburn.Micro.Demo.Host.ViewModels;

namespace Caliburn.Micro.Demo.Host
{
    public class Bootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
