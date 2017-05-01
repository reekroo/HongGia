using System.Web.Mvc;

using HongGia.Core.Controllers;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.Controllers
{
	public class HongGiaController : DefaultController
	{
		public ActionResult About()
		{
			var model = BasePageService.GetBasePageContent("About", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult History()
		{
			var model = BasePageService.GetBasePageContent("HongGiaHistory", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Levels()
		{
			var model = BasePageService.GetBasePageContent("HongGiaLevels", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult ToBeginner()
		{
			var model = BasePageService.GetBasePageContent("HongGiaToBeginner", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Program()
		{
			var model = BasePageService.GetBasePageContent("HongGiaProgram", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
	}
}