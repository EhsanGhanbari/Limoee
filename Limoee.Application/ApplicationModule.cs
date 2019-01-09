using Autofac;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Application.CommandProcessor.Dispatcher;
using Limoee.Repository;

namespace Limoee.Application
{
    /// <summary>
    /// This class is used by Autofac to configure IoC container
    /// </summary>
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();

            builder.RegisterAssemblyTypes(ThisAssembly).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerRequest();

            builder.RegisterAssemblyTypes(ThisAssembly).Where(t => t.Name.EndsWith("QueryService")).AsImplementedInterfaces().InstancePerRequest();  

            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerRequest();
        }
    }
}
