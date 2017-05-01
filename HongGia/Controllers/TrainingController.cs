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
			var model = BasePageService.GetBasePageContent("TrainingGroups", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Online()
		{
			var model = BasePageService.GetBasePageContent("TrainingOnline", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Seminars()
		{
			var model = BasePageService.GetBasePageContent("TrainingSeminars", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
	}
}