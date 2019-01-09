using System;
using System.Collections.Generic;
using Limoee.Domain.CompetitionAgg;

namespace Limoee.Application.CompetitionService
{
    public class CompetitionDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IList<QuestionDTO> Questions { get; set; }
     
    }
}