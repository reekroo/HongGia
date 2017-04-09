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
			var model = PageService.GetPageByName("DirectionsHongGiaVietnam", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult KungFu()
		{
			var model = PageService.GetPageByName("DirectionsKungFu", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult ChiKong()
		{
			var model = PageService.GetPageByName("DirectionsChiKong", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult TaiChi()
		{
			var model = PageService.GetPageByName("DirectionsTaiChi", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult WuChi()
		{
			var model = PageService.GetPageByName("DirectionsWuChi", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult NgaMi()
		{
			var model = PageService.GetPageByName("DirectionsNgaMi", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult VinChun()
		{
			var model = PageService.GetPageByName("DirectionsVinChun", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult PaKua()
		{
			var model = PageService.GetPageByName("DirectionsPaKua", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult SinI()
		{
			var model = PageService.GetPageByName("DirectionsSinI", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult BaiMy()
		{
			var model = PageService.GetPageByName("DirectionsBaiMy", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult FiveEnimals()
		{
			var model = PageService.GetPageByName("DirectionsFiveEnimals", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Weapon()
		{
			var model = PageService.GetPageByName("DirectionsWeapon", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
		public ActionResult Meditation()
		{
			var model = PageService.GetPageByName("DirectionsMeditation", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}
	}
}