using System.Web.Mvc;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class SliderController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			var result = ImageService.GetSliderImages();

			if (result == null)
			{
				return View(new SliderView());
			}

			return View(result);
		}

		[HttpPost]
		public ActionResult Add(Image image)
		{
			if (ModelState.IsValid)
			{
				ImageService.AddImage(image);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Remove(int imageId)
		{
			if (ModelState.IsValid)
			{
				var result = ImageService.RemoveImage(imageId);
			}

			return RedirectToAction("Index");
		}
	}
}