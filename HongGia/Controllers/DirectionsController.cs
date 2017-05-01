using System.Web.Mvc;

using HongGia.Core.Controllers;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.Controllers
{
	public class DirectionsController : DefaultController
	{
		public ActionResult HongGiaVietnam()
		{
			var model = BasePageService.GetBasePageContent("DirectionsHongGiaVietnam", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult KungFu()
		{
			var model = BasePageService.GetBasePageContent("DirectionsKungFu", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult ChiKong()
		{
			var model = BasePageService.GetBasePageContent("DirectionsChiKong", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult TaiChi()
		{
			var model = BasePageService.GetBasePageContent("DirectionsTaiChi", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult WuChi()
		{
			var model = BasePageService.GetBasePageContent("DirectionsWuChi", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult NgaMi()
		{
			var model = BasePageService.GetBasePageContent("DirectionsNgaMi", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult VinChun()
		{
			var model = BasePageService.GetBasePageContent("DirectionsVinChun", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult PaKua()
		{
			var model = BasePageService.GetBasePageContent("DirectionsPaKua", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult SinI()
		{
			var model = BasePageService.GetBasePageContent("DirectionsSinI", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult BaiMy()
		{
			var model = BasePageService.GetBasePageContent("DirectionsBaiMy", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult FiveEnimals()
		{
			var model = BasePageService.GetBasePageContent("DirectionsFiveEnimals", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Weapon()
		{
			var model = BasePageService.GetBasePageContent("DirectionsWeapon", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Meditation()
		{
			var model = BasePageService.GetBasePageContent("DirectionsMeditation", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
	}
}