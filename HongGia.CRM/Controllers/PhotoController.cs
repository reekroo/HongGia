using System.Linq;
using System.Web.Mvc;
using HongGia.BL.SmallFunctional;
using HongGia.Core.Constants;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
    [Authorize(Roles = "admin")]
    public class PhotoController : Controller
	{
		[HttpGet]
		public ActionResult Index(int pageNum = 0)
		{
			var result = PhotoService.GetAllPhoto();

			ViewData["PageNum"] = pageNum;
			ViewData["ItemCount"] = result?.AllPhoto.Count() ?? 0;
			ViewData["PageSize"] = PageSizeConstants.UnicSize;

			if (result == null)
			{
				return View(new PhotosView());
			}

			result.AllPhoto = result.AllPhoto.OrderBy(p => p.Id).Skip(PageSizeConstants.UnicSize * pageNum).Take(PageSizeConstants.UnicSize).ToList();

			return View(result);
		}

		[HttpGet]
		public ActionResult Add()
		{
			var result = new PhotoView()
			{
				Categories = CatigoryService.GetCatigoriesListStringByType(PageSearchConstants.Photo)
			};

			return View(result);
		}

		[HttpGet]
		public ActionResult Update(int photoId)
		{
			var result = PhotoService.GetPhoto(photoId);

			if (result == null)
			{
				return View("Add");
			}

			return View(result);
		}

		[HttpPost]
		public ActionResult Add(PhotoView photo)
		{
			if (ModelState.IsValid)
			{
				var str = photo.Categories.FirstOrDefault();

				photo.Categories = string.IsNullOrEmpty(str) == false ? str.Split(',') : null;
				photo.Path = FilePathCreator.GetGooglePath(photo.Path);

				var result = PhotoService.AddPhoto(photo);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Update(PhotoView photo)
		{
			if (ModelState.IsValid)
			{
				var str = photo.Categories.FirstOrDefault();

				photo.Categories = string.IsNullOrEmpty(str) == false ? str.Split(',') : null;

				PhotoService.UpdatePhoto(photo);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Remove(int photoId)
		{
			if (ModelState.IsValid)
			{
				var result = PhotoService.RemovePhoto(photoId);
			}

			return RedirectToAction("Index");
		}

	}
}