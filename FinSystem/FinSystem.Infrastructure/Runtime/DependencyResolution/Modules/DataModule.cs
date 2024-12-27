using Autofac;
using FinSystem.Domain.Interfaces;
using FinSystem.Infrastructure.Data;
using FinSystem.Infrastructure.Repositories;

namespace FinSystem.Infrastructure.Runtime.DependencyResolution.Modules
{
    public class DataModule
    {
        public static void Initialize(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
        }
    }
}
