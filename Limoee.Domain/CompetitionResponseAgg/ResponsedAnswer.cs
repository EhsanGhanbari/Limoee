using System;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.CompetitionResponseAgg
{
    public class ResponsedAnswer : BaseEntity<Guid>
    {
        public int Order { get; set; }

        public string Title { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}