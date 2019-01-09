using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Limoee.Domain.BannerAgg;

namespace Limoee.Repository.Configurations
{
    public class BannerLogConfiguration : EntityTypeConfiguration<BannerLog>
    {
        public BannerLogConfiguration()
        {
            ToTable("BannerLog");
            HasKey(b => b.Id);
            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.DisplayDate).IsRequired().HasColumnType("date");
            Property(b => b.Count).IsRequired();
            HasRequired(b => b.Banner);
        }
    }
}
