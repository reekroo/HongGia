using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;
using HongGia.DB.Services;

namespace HongGia.Controllers
{
    public class MediaController : DefaultController
    {
        public ActionResult Articles()
        {
            return View();
        }

        public ActionResult Books()
        {
            var result = MediaService.GetAllBookFiles();

            return View(result);
        }

        public ActionResult Video(int pageNum = 0)
        {
            var result = MediaService.GetAllVideo();

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = result.AllVideo.Count();
            ViewData["PageSize"] = PageConstants.PageVideoSize;

            result.AllVideo = result.AllVideo.OrderBy(p => p.Id).Skip(PageConstants.PageCategoriesPhotoSize * pageNum).Take(PageConstants.PageVideoSize).ToList();

            return View(result);
        }
    }
}