using System;
using System.Reflection;
using Autofac;
using Limoee.Domain.BannerAgg;
using Limoee.Repository.Infrastructure;
using Limoee.Repository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Limoee.Repository.Test
{
    [TestClass]
    public class IoCConfigurationTest
    {
        private IContainer _serviceContainer;
        
        [TestInitialize]
        public void Initialize()
            
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RepositoryModule>();

            _serviceContainer = builder.Build();
 
        }

        [TestMethod]
        public void IoC_Can_Create_InstanceOf_BannerRepository()
        {
            var implementingType = _serviceContainer.Resolve<IBannerRepository>();
            Assert.IsInstanceOfType(implementingType, typeof(BannerRepository));
        }

        [TestMethod]
        public void IoC_Can_Create_InstanceOf_UnitOfWork()
        {
            var implementingType = _serviceContainer.Resolve<IUnitOfWork>();
            Assert.IsInstanceOfType(implementingType, typeof(UnitOfWork));
        }
        
        [TestMethod]
        public void IoC_Can_Create_InstanceOf_DatabaseFactory()
        {
            var implementingType = _serviceContainer.Resolve<IDatabaseFactory>();
            Assert.IsInstanceOfType(implementingType, typeof(DatabaseFactory));
        }
    }
}
