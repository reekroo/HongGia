using System.Web.Mvc;

using HongGia.BL.SmallFunctional;

using HongGia.Core.Models.Base;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
    [Authorize(Roles = "admin")]
    public class ImageController : Controller
	{
		[HttpPost]
		public ActionResult Add(Image image,int pageContentId, string pageContentName, string pageContentLang)
		{
			if (ModelState.IsValid)
			{
				image.Src = FilePathCreator.GetGooglePath(image.Src);

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