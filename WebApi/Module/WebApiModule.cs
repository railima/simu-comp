using Autofac;
using Infrastructure.Modules;

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
