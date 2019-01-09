using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Limoee.Application;
using Limoee.Application.BannerService;
using Limoee.Application.Mappings;
using Limoee.Web.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebGrease.Configuration;

namespace Limoee.Web.UI
{
    public static class BootStrapper
    {
        public static void Run()
        {
            SetIoCContainer();
            AutoMapperConfiguration.Configure();
        }
        private static void SetIoCContainer()
        {
            //83192020 kart meli , shenasnameh, daftarche
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UserStore<LimoeeUser>>().As<IUserStore<LimoeeUser>>().InstancePerRequest();
            builder.RegisterType<RoleStore<LimoeeRole>>().As<IRoleStore<LimoeeRole, string>>().InstancePerRequest();


            builder.RegisterType<LimoeeUserManager>().As<LimoeeUserManager>().AsSelf();
            builder.RegisterType<LimoeeRoleManager>().As<LimoeeRoleManager>().AsSelf();

            //builder.RegisterType<IUserStore<LimoeeUser>>().As();

            builder.RegisterType<UserManagerService>().As<IUserManagerService>().SingleInstance();
            builder.RegisterType<RoleManagerService>().As<IRoleManagerService>().SingleInstance();

            builder.RegisterModule<ApplicationModule>();
            var container = builder.Build();
            //ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory());
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }

    public class AutofacControllerFactory : DefaultControllerFactory
    {
        private IContainer container;

        protected IController GetControllerInstance(Type ControllerType)
        {
            if (ControllerType != null)
            {
                return (IController)container.Resolve(ControllerType);
            }
            return null;
        }

    }
}