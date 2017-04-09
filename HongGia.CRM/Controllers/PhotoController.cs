using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Models.Views;

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
				return View(new PhotosView());
			}

			result.AllPhoto = result.AllPhoto.OrderBy(p => p.Id).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

			return View(result);
		}

		[HttpGet]
		public ActionResult Add()
		{
			var result = new PhotoView()
			{
				Categories = CatigoryService.GetCatigoriesListStringByType("photo")
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
			var str = photo.Categories.FirstOrDefault();

			photo.Categories = string.IsNullOrEmpty(str) == false ? str.Split(',') : null;

			if (ModelState.IsValid)
			{
				var result = PhotoService.AddPhoto(photo);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Update(PhotoView photo)
		{
			var str = photo.Categories.FirstOrDefault();

			photo.Categories = string.IsNullOrEmpty(str) == false ? str.Split(',') : null;

			if (ModelState.IsValid)
			{
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