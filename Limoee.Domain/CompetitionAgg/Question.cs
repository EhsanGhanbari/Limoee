using System;
using System.Collections.Generic;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.CompetitionAgg
{
    public class Question : BaseEntity<Guid>
    {
        public string Title { get; set; }

        public string Category { get; set; }
        
        //public QuestionImage QuestionImage { get; set; }
        
        public virtual IList<Answer> Answers { get; set; }

        protected override void Validate()
        {
        }
    }
}