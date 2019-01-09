using System;
using System.Collections.Generic;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Application.CompetitionService;

namespace Limoee.Application.CompetitionResponseService
{
    public class CreateCompetitionResponseCommand : ICommand
    {
        public string UserName { get; set; }
        public DateTime ResponseDate { get; set; }
      

        //public List<Guid> QuestionIds { get; set; }
        //public List<Guid> AnswerIds { get; set; } 

        /// <summary>
        /// competition should send to the view as every competition will contain a list a question 
        /// and every question will contain a list of answer to display for user
        /// conmetitionId, questionIds and asnwerIds will be sent via this
        /// </summary>
        public CompetitionDTO Competition { get; set; }

    }
}
