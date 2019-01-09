using Microsoft.AspNet.Identity.EntityFramework;

namespace Limoee.Web.UI.Models
{

    public class LimoeeDbContext : IdentityDbContext<LimoeeUser>
    {
        public LimoeeDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static LimoeeDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            System.Data.Entity.Database.SetInitializer<LimoeeDbContext>(new ApplicationDbInitializer());
        }
    }
}