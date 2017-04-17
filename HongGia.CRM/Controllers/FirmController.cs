using System.Web.Mvc;

using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
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
			FirmService.AddFirm(firm);
			return RedirectToAction("Index");
		}
	}
}