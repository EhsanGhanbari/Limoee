using System;
using Limoee.Domain.CompetitionAgg;
using Limoee.Infrastructure.Domain;

namespace Limoee.Application.CompetitionService
{
    /// <summary>
    /// Query Service Provider for Competitions
    /// </summary>
    public class CompetitionQueryService : ICompetitionQueryService
    {
        private readonly ICompetitionRepository _competitionRepository;
        public CompetitionQueryService(ICompetitionRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }

        /// <summary>
        /// Returns competition by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompetitionDTO GetCompetition(Guid id)
        {
            var competition = _competitionRepository.GetCompetitionDetail(id);
            return AutoMapper.Mapper.Map<Competition, CompetitionDTO>(competition);
        }

        /// <summary>
        /// Returns the list of paged competitions
        /// </summary>
        /// <param name="pagingOptions"></param>
        /// <returns></returns>
        public PagedResult<CompetitionDTO> GetAllCompetitions(PagingOptions pagingOptions)
        {
            var result = _competitionRepository.GetMany(x => true, pagingOptions.PageIndex, pagingOptions.PageSize);
            return AutoMapper.Mapper.Map<PagedResult<Competition>, PagedResult<CompetitionDTO>>(result);

        }
    }
}