using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Limoee.Application;
using Limoee.Application.BannerService;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Application.CommandProcessor.Dispatcher;
using Limoee.Application.CompetitionResponseService;
using Limoee.Application.CompetitionResponseService;
using Limoee.Application.CompetitionService;
using Limoee.Web.UI.Helpers;

namespace Limoee.Web.UI.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly ICompetitionQueryService _competitionQueryService;
        private readonly ICompetitionResponseQueryService _competitionRespondQueryService;
        private readonly IBannerQueryService _bannerQueryService;
        private const string BannersFolder = "~/Images/Banner";

        public AdminController(ICommandBus commandBus, ICompetitionQueryService competitionQueryService,
            ICompetitionResponseQueryService competitionRespondQueryService, IBannerQueryService bannerQueryService)
        {
            _commandBus = commandBus;
            _competitionQueryService = competitionQueryService;
            _competitionRespondQueryService = competitionRespondQueryService;
            _bannerQueryService = bannerQueryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region "Banner"

        /// <summary>
        /// list of all active banners
        /// </summary>
        /// <returns></returns>
        public ActionResult ActiveBanners(int pageIndex = 1, int pageSize = 30)
        {
            var result = _bannerQueryService.GetAllActiveBanners(new PagingOptions(pageIndex, pageSize));
            return View("ActiveBanners", result);
        }

        /// <summary>
        /// list of all deactive banners
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult DeactiveBanners(int pageIndex = 1, int pageSize = 30)
        {
            var result = _bannerQueryService.GetAllDeactiveBanners(new PagingOptions(pageIndex, pageSize));
            return View("DeactiveBanners", result);
        }


        /// <summary>
        /// Create banner action
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateBanner()
        {
            return View("CreateBanner");
        }

        [HttpPost]
        public ActionResult CreateBanner(CreateBannerCommand command)
        {
            if (!ModelState.IsValid) return View("CreateBanner");

            var extension = Path.GetExtension(command.File.FileName).ToLower();

            try
            {
                var newFileName = Guid.NewGuid() + extension;
                var path = Path.Combine(Server.MapPath(BannersFolder), newFileName);
                command.File.SaveAs(path);
                command.Path = BannersFolder;
                command.Name = newFileName;
                _commandBus.Submit(command);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
            }

            return View("CreateBanner");
        }


        /// <summary>
        /// Activate a banner
        /// this command will be called via ajax
        /// </summary>
        /// <param name="bannerId"></param>
        public dynamic ActivateBanner(Guid bannerId)
        {
            var banner = _bannerQueryService.GetBanner(bannerId);
            var command = new ActivateBannerCommand
            {
                Id = banner.Id,
                StartDate = banner.StartDate,
            };
            var result = _commandBus.Submit(command);
            return result;
        }

        /// <summary>
        /// Deactivate a banner
        /// this command will be called via ajax
        /// </summary>
        /// <param name="bannerId"></param>
        public dynamic DeactivateBanner(Guid bannerId)
        {
            var command = new DeactivateBannerCommand { Id = bannerId };
            var result = _commandBus.Submit(command);
            return result;
        }


        #endregion

        #region "Competitions"

        /// <summary>
        /// List of all competitions
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Competitions(int pageIndex = 1, int pageSize = 30)
        {
            var result = _competitionQueryService.GetAllCompetitions(new PagingOptions(pageIndex, pageSize));
            return View("Competitions", result);
        }

        /// <summary>
        /// Create a competition by admin 
        /// </summary>
        /// <returns></returns>
        public ViewResult CreateCompetition()
        {
            return View("CreateCompetition");
        }

        [HttpPost]
        [HttpParamAction(Name = "CreateCompetition")]
        public ActionResult CreateCompetition(CreateCompetitionCommand command)
        {
            if (!ModelState.IsValid)
                return Json(new FailureResult("داده های فرم ارسال شده معتبر نیست. دوباره تلاش کنید!"));
            var result = _commandBus.Submit(command);
            return Json(result);
        }

        /// <summary>
        /// Edit a competition by admin 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditCompetition(Guid id)
        {
            var competition = _competitionQueryService.GetCompetition(id);
            var command = new EditCompetitionCommand
            {
                Description = competition.Description,
                EndDate = competition.EndDate,
                Title = competition.Title,
                Id = competition.Id,
                StartDate = competition.StartDate,
                Questions = competition.Questions
            };
            return View("EditCompetition", command);
        }

        [HttpPost]
        [HttpParamAction(Name = "EditCompetition")]
        public ActionResult EditCompetition(EditCompetitionCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = _commandBus.Submit(command);
                return Json(result);
            }
            return Json(new FailureResult("داده های فرم ارسال شده معتبر نیست. دوباره تلاش کنید!"));
        }


        /// <summary>
        /// Redirect to preview page for the created competition 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [HttpParamAction(Name = "PreviewCompetition")]
        public ActionResult PreviewCompetition(EditCompetitionCommand command)
        {
            return View("PreviewCompetition", command);
        }


        #endregion

        public ActionResult Members()
        {
            return View();
        }

        public ActionResult Newsletter()
        {
            return View();
        }
    }
}