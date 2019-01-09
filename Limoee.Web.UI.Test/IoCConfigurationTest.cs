using System;
using System.Web.Mvc;
using Limoee.Application.BannerService;
using Limoee.Application.CommandProcessor.Dispatcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Limoee.Web.UI.Test
{
    [TestClass]
    public class IoCConfigurationTest
    {
        [TestInitialize]
        public void Initialize()
        {
            BootStrapper.Run();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Bus_Handle_Command()
        {
            var bus = DependencyResolver.Current.GetService<ICommandBus>();

            bus.Submit(new CreateBannerCommand());

        }
    }
}
