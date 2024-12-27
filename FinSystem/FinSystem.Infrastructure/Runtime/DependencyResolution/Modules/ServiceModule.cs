using Autofac;
using FinSystem.Application.Interfaces;
using FinSystem.Application.Services;
using FinSystem.Domain.Entities;
using FinSystem.Domain.Interfaces;
using FinSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FinSystem.Infrastructure.Runtime.DependencyResolution.Modules
{
    public static class ServiceModule
    {
        public static void Initialize(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>().InstancePerLifetimeScope();
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var jwtKey = configuration["JwtKey"];
                return new JwtHandler(jwtKey);
            }).As<IJwtHandler>().SingleInstance();
        }
    }
}
