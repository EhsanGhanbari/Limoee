using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Limoee.Domain.CompetitionResponseAgg;

namespace Limoee.Repository.Configurations
{
    public class CompetitionResponseConfiguration : EntityTypeConfiguration<CompetitionResponse>
    {
        public CompetitionResponseConfiguration()
        {
            ToTable("Competition_Response");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.UserName).IsRequired();
            Property(c => c.CompetitionId);
            Property(c => c.ResponseDate).HasColumnType("datetime").IsRequired();

            HasMany(c => c.ResponsedQuestions).WithMany(cq => cq.CompetitionResponses).Map(q =>
            {
                q.MapLeftKey("CompetitionResponseId");
                q.MapRightKey("ResponsedQuestionId");
                q.ToTable("Competition_Responsed_Question");
            });

        }
    }
}
