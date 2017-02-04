using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;

using HongGia.DB.Services;

namespace HongGia.Controllers
{
    public class PhotoController : DefaultController
    {
        public ActionResult AllPhoto()
        {
            var result = PhotoService.GetAllPhoto();

            return View(result);
        }

        public ActionResult CategoryPhoto(string category,int pageNum = 0)
        {
            var result = PhotoService.GetCategoryPhoto(category);

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = result.CategoryPhoto.Count();
            ViewData["PageSize"] = PageConstants.PageCategoriesPhotoSize;

            result.CategoryPhoto = result.CategoryPhoto.OrderBy(p => p.Id).Skip(PageConstants.PageCategoriesPhotoSize * pageNum).Take(PageConstants.PageCategoriesPhotoSize).ToList();

            return View(result);
        }
    }
}