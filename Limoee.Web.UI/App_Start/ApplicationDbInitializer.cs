using System.Data.Entity;
using System.Web;
using Limoee.Web.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Limoee.Web.UI
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<LimoeeDbContext>
    {
        protected override void Seed(LimoeeDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(LimoeeDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<LimoeeUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<LimoeeRoleManager>();
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new LimoeeRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new LimoeeUser { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}