using Autofac;
using FinSystem.Application.DTOs;
using FinSystem.Application.Validators;
using FluentValidation;

namespace FinSystem.Infrastructure.Runtime.DependencyResolution.Modules
{
    public class ApplicationModule
    {
        public static void Initialize(ContainerBuilder builder)
        {
            builder.RegisterType<UserRegistrationValidator>().As<IValidator<UserRegistrationDto>>();
        }

    }
}
