using System;
using Limoee.Application.CompetitionResponseService;
using Limoee.Infrastructure.Domain;

namespace Limoee.Application.CompetitionService
{
    public interface ICompetitionQueryService
    {
        CompetitionDTO GetCompetition(Guid id);

        PagedResult<CompetitionDTO> GetAllCompetitions(PagingOptions pagingOptions);

    }
}