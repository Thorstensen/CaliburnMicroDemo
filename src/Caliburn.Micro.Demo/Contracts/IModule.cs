using Autofac;

namespace Caliburn.Micro.Demo.Contracts
{
    public interface IModule
    {
        void RegisterComponents(ContainerBuilder builder);
    }
}
