using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Domain.CompetitionAgg;

namespace Limoee.Application.CompetitionService
{
    public class EditCompetitionCommand : ICommand
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Is Required!")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Is Required!")]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IList<QuestionDTO> Questions { get; set; }
    
    }
}
