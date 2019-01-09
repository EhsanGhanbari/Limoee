using System;
using System.Collections;
using System.Collections.Generic;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.CompetitionResponseAgg
{
    public class ResponsedQuestion : BaseEntity<Guid>
    {
        public string Title { get; set; }  // ToDo- Overhead
        public string Category { get; set; }  // Todo- Overhead
        public virtual ResponsedAnswer ResponsedAnswer { get; set; }
        
        /// <summary>
        /// for mapping CompeitionResponse in one mapping class 
        /// </summary>
        public IList<CompetitionResponse> CompetitionResponses { get; set; }

        protected override void Validate()
        {
        }
    }
}