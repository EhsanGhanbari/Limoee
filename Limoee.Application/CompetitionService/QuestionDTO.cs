using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Limoee.Application.CompetitionService
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Is Required!")]
        [AllowHtml]
        public string Title { get; set; }

        [Required(ErrorMessage = "Is Required!")]
        public string Category { get; set; }

        public IList<AnswerDTO> Answers { get; set; }

        public Guid AcceptedAnswer { get; set; }
        
       // public QuestionImage QuestionImage { get; set; }
    }
}