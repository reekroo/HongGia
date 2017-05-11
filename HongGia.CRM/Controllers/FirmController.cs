using System.Web.Mvc;

using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
    [Authorize(Roles = "admin")]
    public class FirmController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			var result = FirmService.GetFirms();

			if (result == null)
			{
				return View(new Firmsview());
			}

			return View(result);
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View(new FirmView());
		}

		[HttpPost]
		public ActionResult Add(FirmView firm)
		{
			if (ModelState.IsValid)
			{
				FirmService.AddFirm(firm);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Remove(int firmId)
		{
			if (ModelState.IsValid)
			{
				FirmService.RemoveFirm(firmId);
			}

			return RedirectToAction("index");
		}
	}
}