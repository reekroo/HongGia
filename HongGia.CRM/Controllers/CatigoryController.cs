using System.Web.Mvc;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class CatigoryController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			 var result = CatigoryService.GetCatigories();

			if (result == null)
			{
				return View(new CatigoriesViewModels());
			}

			return View(result);
		}

		[HttpPost]
		public ActionResult Add(Catigory catigory)
		{
			if (ModelState.IsValid)
			{
				CatigoryService.AddCatigory(catigory);
			}

			return RedirectToAction("index");
		}

		[HttpPost]
		public ActionResult Remove(int catigoryId)
		{
			if (ModelState.IsValid)
			{
				CatigoryService.RemoveCatigory(catigoryId);
			}

			return RedirectToAction("index");
		}
	}
}