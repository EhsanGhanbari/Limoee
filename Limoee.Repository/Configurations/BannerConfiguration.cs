using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Limoee.Domain.BannerAgg;

namespace Limoee.Repository.Configurations
{
    public class BannerConfiguration : EntityTypeConfiguration<Banner>
    {
        public BannerConfiguration()
        {
            ToTable("Banner");
            HasKey(b => b.Id);
            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.Advertiser).HasMaxLength(200).IsUnicode().IsRequired();
            Property(b => b.CreationTime).IsRequired();
            Property(b => b.IsActive).IsRequired();
            Property(b => b.StartDate).IsRequired();
            Property(b => b.EndDate).IsRequired();
            Property(b => b.BannerImage.Name).IsOptional().IsUnicode();
            Property(b => b.BannerImage.Path).IsRequired().IsUnicode();
            Property(b => b.AdvertiserHomePage).IsRequired();
            Property(b => b.DisplayArea).IsRequired();
        }
    }
}
