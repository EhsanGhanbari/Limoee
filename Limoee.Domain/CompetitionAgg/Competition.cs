using System;
using System.Collections.Generic;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.CompetitionAgg
{
    public class Competition : BaseEntity<Guid>, IAggregateRoot
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual IList<Question> Questions { get; set; }

        protected override void Validate()
        {
            if (StartDate >= EndDate)
                this.AddBrokenRule(new BusinessRule("StartDate", "Start Date must be before than End Date!"));

            if (Questions.Count == 0)
                AddBrokenRule(new BusinessRule("Question", "Question can not be empty!"));
        }
    }
}
