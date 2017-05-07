using System.Web.Mvc;

using HongGia.BL.SmallFunctional;

using HongGia.Core.Models.Base;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class FileController : Controller
	{
		[HttpPost]
		public ActionResult Add(File file,int pageContentId, string pageContentName, string pageContentLang)
		{
			if (ModelState.IsValid)
			{
				file.Path = FilePathCreator.GetGooglePath(file.Path);

				FileService.Add(file, pageContentId);
			}

			return RedirectToAction("AddOrUpdate", "BasePage", new { name = pageContentName, lang = pageContentLang });
		}

		[HttpPost]
		public ActionResult Remove(int fileId, string pageContentName, string pageContentLang)
		{
			FileService.Remove(fileId);

			return RedirectToAction("AddOrUpdate", "BasePage", new { name = pageContentName, lang = pageContentLang });
		}
	}
}