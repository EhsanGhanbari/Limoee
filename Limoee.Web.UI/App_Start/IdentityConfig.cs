using System.Web;
using System.Web.Mvc;
using Limoee.Web.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Limoee.Web.UI
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public interface IUserManagerService
    {
        LimoeeUserManager CreateInstance();
    }

    public class UserManagerService : IUserManagerService
    {
        public LimoeeUserManager CreateInstance()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<LimoeeUserManager>();
        }
    }

    public interface IRoleManagerService
    {
        LimoeeRoleManager CreateInstance();
    }

    public class RoleManagerService : IRoleManagerService
    {
        public LimoeeRoleManager CreateInstance()
        {
            return HttpContext.Current.GetOwinContext().Get<LimoeeRoleManager>();
        }
    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class LimoeeRoleManager : RoleManager<LimoeeRole>
    {
        public LimoeeRoleManager(IRoleStore<LimoeeRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static LimoeeRoleManager Create(IdentityFactoryOptions<LimoeeRoleManager> options, IOwinContext context)
        {
            //var manager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
            var manager = new LimoeeRoleManager(new RoleStore<LimoeeRole>(new LimoeeDbContext()) { DisposeContext = true });
            //var manager = DependencyResolver.Current.GetService<LimoeeRoleManager>();
            return manager;
        }
    }
}