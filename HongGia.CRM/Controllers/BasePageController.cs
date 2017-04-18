using System.Web.Mvc;
using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class BasePageController : Controller
	{
		// GET: BasePage
		public ActionResult Index()
		{
			return View();
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