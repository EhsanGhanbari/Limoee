using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limoee.Application.CompetitionResponseService
{
    public class EditCompetitionResponseCommand
    {
        public string UserName { get; set; }
        public DateTime ResponseDate { get; set; }
        public Guid CompetitionId { get; set; }
        public IList<Guid> QuestionIds { get; set; }
        public IList<Guid> AnswerIds { get; set; } 
    }
}
