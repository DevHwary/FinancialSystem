using Autofac;
using FinSystem.Domain.Interfaces;
using FinSystem.Infrastructure.Repositories;

namespace FinSystem.Infrastructure.Runtime.DependencyResolution.Modules
{
    public static class RepositoryModule
    {
        public static void Initialize(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FinanceRequestRepository>().As<IFinanceRequestRepository>().InstancePerLifetimeScope();
        }
    }
}
