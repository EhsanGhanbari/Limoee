using System;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.CompetitionAgg
{
    public class Answer : BaseEntity<Guid>
    {
        public int Order { get; set; }

        public string Title { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}