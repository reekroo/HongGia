using System.Web.Mvc;

using HongGia.Core.Controllers;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.Controllers
{
	public class TrainingController : DefaultController
	{
		public ActionResult Groups()
		{
			var model = PageService.GetPageByName("TrainingGroups", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Online()
		{
			var model = PageService.GetPageByName("TrainingOnline", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Seminars()
		{
			var model = PageService.GetPageByName("TrainingSeminars", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
	}
}