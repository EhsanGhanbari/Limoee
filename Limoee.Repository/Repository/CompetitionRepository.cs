using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Limoee.Domain.CompetitionAgg;
using Limoee.Infrastructure.Domain;
using Limoee.Repository.Infrastructure;

namespace Limoee.Repository.Repository
{
    public class CompetitionRepository : BaseRepository<Competition, Guid>, ICompetitionRepository
    {
        public CompetitionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }

        public Competition GetCompetitionOfWeek()
        {
            return DataContext.Competitions.SingleOrDefault(x => x.StartDate >= DateTime.Now && x.EndDate <= DateTime.Now);
        }

        /// <summary>
        /// Returns the competion and it's related questions
        /// </summary>
        /// <returns></returns>
        public Competition GetCompetitionDetail(Guid id)
        {
            return DataContext.Competitions.Where(c => c.Id == id).Include(q => q.Questions).SingleOrDefault();
        }

        public override PagedResult<Competition> GetMany(Expression<Func<Competition, bool>> expressionQuery, int pageIndex = 1, int pageSize = 30)
        {
            var total = DataContext.Competitions.CountAsync();

            var result = new PagedResult<Competition>()
            {
                PageSize = pageSize,
                CurrentPage = pageIndex,
                TotalCount = total.Result,
                Results = DataContext.Competitions.Where(expressionQuery).OrderByDescending(x => x.StartDate).Skip((pageIndex -1)  * pageSize).Take(pageSize).ToList()
            };

            return result;
        }
    }
}