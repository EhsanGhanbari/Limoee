using System;
using System.Collections.Generic;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.CompetitionResponseAgg
{
    public class CompetitionResponse : BaseEntity<Guid>, IAggregateRoot
    {
        public string UserName { get; set; }
        public Guid CompetitionId { get; set; }
        public IList<ResponsedQuestion> ResponsedQuestions { get; set; }
        public DateTime ResponseDate { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
