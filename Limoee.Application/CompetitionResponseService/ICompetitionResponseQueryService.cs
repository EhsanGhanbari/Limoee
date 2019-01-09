using System;
using Limoee.Infrastructure.Domain;

namespace Limoee.Application.CompetitionResponseService
{
    public interface ICompetitionResponseQueryService
    {
        CompetitionResponseDTO GetCompetitionResponseByCompetitionId(Guid id);
    }
}
