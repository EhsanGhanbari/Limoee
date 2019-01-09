using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Limoee.Domain.CompetitionAgg;

namespace Limoee.Repository.Configurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            ToTable("Competition_Questions");
            HasKey(x => x.Id);
            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.Category).IsRequired().IsUnicode().HasMaxLength(30);
            Property(b => b.Title).IsRequired().IsUnicode();
            HasMany(x => x.Answers);
           
        }

    }
}