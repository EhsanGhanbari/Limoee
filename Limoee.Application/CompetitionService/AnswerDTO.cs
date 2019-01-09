using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Limoee.Application.CompetitionService
{
    public class AnswerDTO
    {
        public Guid Id { get; set; }

        public int Order { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Is Required!")]
        public string Title { get; set; }
    }
}
