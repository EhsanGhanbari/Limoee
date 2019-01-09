using System;
using Autofac;
using Limoee.Application.BannerService;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Application.CommandProcessor.Dispatcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Limoee.Application.Test
{
    [TestClass]
    public class CommandBusTest
    {
        private IContainer _serviceContainer;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();

            _serviceContainer = builder.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Bus_Handle_Command()
        {
            var bus = _serviceContainer.Resolve<ICommandBus>();

            bus.Submit(new CreateBannerCommand());

        }

    }
}