using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Limoee.Application.BannerService;
using Limoee.Web.UI.Helpers;

namespace Limoee.Web.UI.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            PersianCultureHelper.FixAndSetCurrentCulture();
            return base.BeginExecuteCore(callback, state);
        }

        private readonly IBannerQueryService _bannerQueryService;

        public HomeController(IBannerQueryService bannerQueryService)
        {
            _bannerQueryService = bannerQueryService;
        }


        public ActionResult Index()
        {
            return View();
        }

        #region Banner

        /// <summary>
        /// نمایش بنرهای سمت چپ وبسایت
        /// </summary>
        /// <returns></returns>
        // [ChildActionOnly]
        public ActionResult LeftSideBanners()
        {
            var banners = _bannerQueryService.GetAllLeftSideBannersByRandom();
            var files = Directory.GetFiles(Server.MapPath("~/Images/Banner"));
            foreach (var file in files)
            {
                banners.Select(c => c.BannerImage.Name == Path.GetFileName(file));
            }
            return PartialView("_LeftSideBanners", banners);
        }


        /// <summary>
        /// نمایش بنرهای سمت بالای وبسایت
        /// </summary>
        /// <returns></returns>
        // [ChildActionOnly]
        public ActionResult TopSideBanners()
        {
            var banners = _bannerQueryService.GetAllTopSideBannersByRandom();
            var files = Directory.GetFiles(Server.MapPath("~/Images/Banner"));
            foreach (var file in files)
            {
                banners.Select(c => c.BannerImage.Name == Path.GetFileName(file));
            }

            return PartialView("_TopSideBanners", banners);
        }

        #endregion

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}