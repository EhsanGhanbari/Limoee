using Microsoft.AspNet.Identity.EntityFramework;

namespace Limoee.Web.UI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class LimoeeUser : IdentityUser
    {

    }

    public class LimoeeRole : IdentityRole
    {
        public LimoeeRole()
        {
            
        }

        public LimoeeRole(string name)
        {
            base.Name = name;
        }
    }
}