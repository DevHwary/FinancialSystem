using Autofac;
using FinSystem.Application.Interfaces;
using FinSystem.Application.Services;
using FinSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FinSystem.Infrastructure.Runtime.DependencyResolution.Modules
{
    public static class ServiceModule
    {
        public static void Initialize(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<FinanceRequestService>().As<IFinanceRequestService>().InstancePerLifetimeScope();
            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>().InstancePerLifetimeScope();

        }
    }
}
