using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Limoee.Application.BannerService;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Application.CommandProcessor.Dispatcher;
using Limoee.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Limoee.Application.Test
{
    [TestClass]
    public class AutofacConfigurationTest
    {
        private IContainer _serviceContainer;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>();
            builder.RegisterModule(new RepositoryModule());
            var servicesAssembly = Assembly.Load("Limoee.Application");
            builder.RegisterAssemblyTypes(servicesAssembly).AsClosedTypesOf(typeof(ICommandHandler<>));

            _serviceContainer = builder.Build();
        }

        [TestMethod]
        public void IoC_Can_Find_CommandHandler_For_CreateBannerCommand()
        {
            var bus = _serviceContainer.Resolve<ICommandBus>() ;
            var handler = _serviceContainer.Resolve<ICommandHandler<CreateBannerCommand>>();

            handler.Execute(new CreateBannerCommand());

            Assert.IsNotNull(handler);
            Assert.IsNotNull(bus);
            Assert.IsTrue(bus.GetType() == typeof(DefaultCommandBus));
        }
    }
}
