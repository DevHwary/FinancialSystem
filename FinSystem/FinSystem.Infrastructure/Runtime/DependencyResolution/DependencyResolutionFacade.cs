using Autofac;
using FinSystem.Infrastructure.Runtime.DependencyResolution.Modules;

namespace FinSystem.Infrastructure.Runtime.DependencyResolution
{
    public class DependencyResolutionFacade 
    {
        public static void Initialize(ContainerBuilder container)
        {
            DataModule.Initialize(container);
            ServiceModule.Initialize(container);
        }
    }
}
