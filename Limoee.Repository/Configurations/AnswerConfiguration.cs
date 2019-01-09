using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Limoee.Domain.CompetitionAgg;

namespace Limoee.Repository.Configurations
{
    public class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            ToTable("Question_Answers");
            HasKey(x => x.Id);
            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.Order).IsRequired();
            Property(b => b.Title).IsRequired().IsUnicode();
        }
    }
}