using System.Data.Entity;
using System.Text;
using Limoee.Domain.BannerAgg;
using Limoee.Domain.CompetitionAgg;
using Limoee.Domain.CompetitionResponseAgg;
using Limoee.Repository.Configurations;

namespace Limoee.Repository
{
    public class LimoeeDataContext : DbContext
    {
        public LimoeeDataContext()
            : base("Limoee")
        {

        }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionResponse> CompetitionResponses { get; set; }
        public DbSet<BannerLog> BannerLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new BannerConfiguration());
            modelBuilder.Configurations.Add(new CompetitionConfiguration());
            modelBuilder.Configurations.Add(new CompetitionResponseConfiguration());
            modelBuilder.Configurations.Add(new BannerLogConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
