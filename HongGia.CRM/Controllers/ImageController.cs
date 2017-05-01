using System.Web.Mvc;

using HongGia.Core.Models.Base;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class ImageController : Controller
	{
		[HttpPost]
		public ActionResult Add(Image image,int pageContentId, string pageContentName, string pageContentLang)
		{
			//!!! fake

			image.Src = "aaaaa";

			if (ModelState.IsValid)
			{
				ImageService.AddImage(image, pageContentId);
			}

			return RedirectToAction("AddOrUpdate", "BasePage", new { name = pageContentName, lang = pageContentLang });
		}

		[HttpPost]
		public ActionResult Remove(int imageId, string pageContentName, string pageContentLang)
		{
			ImageService.RemoveImage(imageId);

			return RedirectToAction("AddOrUpdate", "BasePage", new { name = pageContentName, lang = pageContentLang });
		}
	}
}