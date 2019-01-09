using System;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.CompetitionAgg
{
    public interface ICompetitionRepository : IBaseRepository<Competition, Guid>
    {
        Competition GetCompetitionOfWeek();

        Competition GetCompetitionDetail(Guid id);
    }
}