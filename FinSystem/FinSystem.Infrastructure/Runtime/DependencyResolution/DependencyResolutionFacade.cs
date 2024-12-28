using Autofac;
using FinSystem.Infrastructure.Runtime.DependencyResolution.Modules;

namespace FinSystem.Infrastructure.Runtime.DependencyResolution
{
    public class DependencyResolutionFacade 
    {
        public static void Initialize(ContainerBuilder container)
        {
            ApplicationModule.Initialize(container);
            DataModule.Initialize(container);
            RepositoryModule.Initialize(container);
            ServiceModule.Initialize(container);
        }
    }
}
