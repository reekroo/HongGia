using System.Web.Mvc;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class BasePageController : Controller
	{
		[HttpGet]
		public ActionResult Index(string name, string lang = "ru")
		{
			ViewData["PageName"] = name;

			var result = BasePageService.GetBasePageContent(name, lang);
			
			return View(result);
		}

		[HttpGet]
		public ActionResult AddOrUpdate(string name, string lang)
		{
			ViewData["PageLang"] = lang;

			if (BasePageService.GetBasePageContent(name, lang) == null)
			{
				BasePageService.AddBasePageContent(name, lang);
			}

			var result = BasePageService.GetBasePageContent(name, lang);

			return View(result);
		}

		[HttpPost]
		public ActionResult Remove(int basepageContentId, string name, string lang)
		{
			var result = BasePageService.RemoveBasePageContent(basepageContentId);

			return RedirectToAction("Index", new { name, lang });
		}

		[HttpGet]
		public ActionResult Information()
		{
			var result = BasePageService.GetInformation();

			return View(result);
		}

		[HttpPost]
		public ActionResult AddBasePageName(string name)
		{
			if (ModelState.IsValid)
			{
				var result = BasePageService.AddBasePageName(name);
			}

			return RedirectToAction("Information");
		}

		[HttpPost]
		public ActionResult AddLang(string lang)
		{
			if (ModelState.IsValid)
			{
				var result = BasePageService.AddLang(lang);
			}

			return RedirectToAction("Information");
		}

	}
}