using Autofac;
using Core.Exceptions;
using Core.Services;
using Infrastructure.Exceptions;

namespace Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CompraService).Assembly)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(InfrastructureModule).Assembly)
                   .Where(type => type.Namespace.Contains("Infrastructure"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
