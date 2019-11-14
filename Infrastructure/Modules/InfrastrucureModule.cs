using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureModule).Assembly)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
