using System;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.CompetitionResponseAgg
{
    public interface ICompetitionResponseRepository : IBaseRepository<CompetitionResponse, Guid>
    {
        CompetitionResponse GetCompetitionResponseByCompetitionId(Guid id);
    }
}
