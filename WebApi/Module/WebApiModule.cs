using Autofac;
using Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Module
{
    public class WebApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(WebApiModule).Assembly)
                   .AsSelf()
                   .InstancePerLifetimeScope();

            builder.RegisterModule<InfrastructureModule>();
        }
    }
}
