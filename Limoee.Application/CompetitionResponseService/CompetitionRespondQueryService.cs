using System;
using Limoee.Domain.CompetitionResponseAgg;

namespace Limoee.Application.CompetitionResponseService
{
    public class CompetitionRespondQueryService : ICompetitionResponseQueryService
    {
        private readonly ICompetitionResponseRepository _competitionResponseRepository;

        public CompetitionRespondQueryService(ICompetitionResponseRepository competitionResponseRepository)
        {
            _competitionResponseRepository = competitionResponseRepository;
        }

        public CompetitionResponseDTO GetCompetitionResponseByCompetitionId(Guid id)
        {
            var competition = _competitionResponseRepository.GetCompetitionResponseByCompetitionId(id);
            return AutoMapper.Mapper.Map<CompetitionResponse, CompetitionResponseDTO>(competition);
        }
    }
}
