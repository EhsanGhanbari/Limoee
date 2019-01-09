using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Limoee.Domain.CompetitionAgg;

namespace Limoee.Repository.Configurations
{
    public class CompetitionConfiguration : EntityTypeConfiguration<Competition>
    {
        public CompetitionConfiguration()
        {
            ToTable("Competition");
            HasKey(b => b.Id);
            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.Description).IsRequired().IsUnicode();
            Property(b => b.EndDate).IsRequired();
            Property(b => b.StartDate).IsRequired();
            Property(b => b.Title).IsRequired().HasMaxLength(100).IsUnicode();
         
        }
    }
}