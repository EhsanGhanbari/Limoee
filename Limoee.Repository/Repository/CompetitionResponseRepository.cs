using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Limoee.Domain.CompetitionAgg;
using Limoee.Domain.CompetitionResponseAgg;
using Limoee.Infrastructure.Domain;
using Limoee.Repository.Infrastructure;

namespace Limoee.Repository.Repository
{
    public class CompetitionResponseRepository : BaseRepository<CompetitionResponse, Guid>, ICompetitionResponseRepository
    {
        public CompetitionResponseRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public override PagedResult<CompetitionResponse> GetMany(Expression<Func<CompetitionResponse, bool>> expressionQuery, int pageIndex = 1, int pageSize = 30)
        {
            throw new NotImplementedException();
        }

        public CompetitionResponse GetCompetitionResponseByCompetitionId(Guid id)
        {
            return DataContext.CompetitionResponses.Where(c => c.CompetitionId == id).Include(c => c.ResponsedQuestions).SingleOrDefault();
        }
    }
}
