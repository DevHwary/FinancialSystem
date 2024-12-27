using Autofac;
using FinSystem.Infrastructure.Runtime.DependencyResolution.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Infrastructure.Runtime.DependencyResolution
{
    public static class DependencyResolutionFacade
    {
        public static void Initialize(ContainerBuilder container)
        {
            ServiceModule.Initialize(container);
        }
    }
}
