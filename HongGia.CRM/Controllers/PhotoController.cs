using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Interfaces.Base;

using HongGia.CRM.Models;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public ActionResult Index(int pageNum = 0)
        {
            var result = PhotoService.GetAllPhoto();

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = result?.AllPhoto.Count() ?? 0;
            ViewData["PageSize"] = 20;

            if (result == null)
            {
                return View(new AllNewsViewModel());
            }

            result.AllPhoto = result.AllPhoto.OrderBy(p => p.Id).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

            return View(result);
        }

        [HttpGet]
        public ActionResult Photo(int photoId)
        {
            var result = PhotoService.GetPhoto(photoId);

            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateCatigories(int photoId, IEnumerable<string> catigory)
        {
            var result = PhotoService.UpdateCatigories(photoId, catigory);

            return View("Photo");
        }
        
        [HttpPost]
        public ActionResult Add(IPhoto photo)
        {
            var result = PhotoService.AddPhoto(photo);

            return View("Photo");
        }

        [HttpPost]
        public ActionResult Remove(int photoId, IEnumerable<string> catigory)
        {
            var result = PhotoService.UpdateCatigories(photoId, catigory);

            return View("Index");
        }

    }
}