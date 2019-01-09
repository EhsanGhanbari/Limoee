using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Limoee.Application;
using Limoee.Application.CommandProcessor.Dispatcher;
using Limoee.Application.CompetitionResponseService;
using Limoee.Application.CompetitionResponseService;
using Limoee.Application.CompetitionService;

namespace Limoee.Web.UI.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly ICompetitionQueryService _competitionQueryService;

        public CompetitionController(ICommandBus commandBus, ICompetitionQueryService competitionQueryService)
        {
            _commandBus = commandBus;
            _competitionQueryService = competitionQueryService;
        }


        /// <summary>
        /// لیست مسابقات 
        /// مسابقات جاری و فعال
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int pageIndex = 1, int pageSize = 30)
        {
            var competition = _competitionQueryService.GetAllCompetitions(new PagingOptions(pageIndex, pageSize));
            return View(competition);
        }


        /// <summary>
        /// شرکت در مسابقه
        /// کاربر از لیست مسابقات موجود یکی را انتخاب کرده
        ///  و وارد صفحه ی مسابقه مربوطه شده و جواب سوالات مسابقه را ثبت می کند
        /// </summary>
        /// <returns></returns>
        public ActionResult Participate(Guid id)
        {
            var competition = _competitionQueryService.GetCompetition(id);
            var command = new CreateCompetitionResponseCommand()
            {
                UserName = "X",   // TODO Get the username 
                Competition = competition,
            };
            return View("Participate", command);
        }

        [HttpPost]
        public ActionResult Participate(CreateCompetitionResponseCommand command)
        {
            if (!ModelState.IsValid) return View("Participate");
            {
                var result = _commandBus.Submit(command);
                return Json(result);
            }
        }



    }
}