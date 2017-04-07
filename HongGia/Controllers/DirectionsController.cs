using System.Web.Mvc;

using HongGia.Core.Controllers;
using HongGia.DB.Services;

using HongGia.Models;

namespace HongGia.Controllers
{
    public class DirectionsController : DefaultController
    {
        public ActionResult HongGiaVietnam()
        {
            var model = PageService.GetPageByName("DirectionsHongGiaVietnam", this.CurrentLangCode);

            if (model == null)
            {
                return View(new HongGiaVietnamViewModel());
            }

            return View(model);
        }
        public ActionResult KungFu()
        {
            var model = PageService.GetPageByName("DirectionsKungFu", this.CurrentLangCode);

            if (model == null)
            {
                return View(new KungFuViewModel());
            }

            return View(model);
        }
        public ActionResult ChiKong()
        {
            var model = PageService.GetPageByName("DirectionsChiKong", this.CurrentLangCode);

            if (model == null)
            {
                return View(new ChiKongViewModel());
            }

            return View(model);
        }
        public ActionResult TaiChi()
        {
            var model = PageService.GetPageByName("DirectionsTaiChi", this.CurrentLangCode);

            if (model == null)
            {
                return View(new TaiChiViewModel());
            }

            return View(model);
        }
        public ActionResult WuChi()
        {
            var model = PageService.GetPageByName("DirectionsWuChi", this.CurrentLangCode);

            if (model == null)
            {
                return View(new WuChiViewModel());
            }

            return View(model);
        }
        public ActionResult NgaMi()
        {
            var model = PageService.GetPageByName("DirectionsNgaMi", this.CurrentLangCode);

            if (model == null)
            {
                return View(new NgaMiViewModel());
            }

            return View(model);
        }
        public ActionResult VinChun()
        {
            var model = PageService.GetPageByName("DirectionsVinChun", this.CurrentLangCode);

            if (model == null)
            {
                return View(new VinChunViewModel());
            }

            return View(model);
        }
        public ActionResult PaKua()
        {
            var model = PageService.GetPageByName("DirectionsPaKua", this.CurrentLangCode);

            if (model == null)
            {
                return View(new PaKuaViewModel());
            }

            return View(model);
        }
        public ActionResult SinI()
        {
            var model = PageService.GetPageByName("DirectionsSinI", this.CurrentLangCode);

            if (model == null)
            {
                return View(new SinIViewModel());
            }

            return View(model);
        }
        public ActionResult BaiMy()
        {
            var model = PageService.GetPageByName("DirectionsBaiMy", this.CurrentLangCode);

            if (model == null)
            {
                return View(new BaiMyViewModel());
            }

            return View(model);
        }
        public ActionResult FiveEnimals()
        {
            var model = PageService.GetPageByName("DirectionsFiveEnimals", this.CurrentLangCode);

            if (model == null)
            {
                return View(new FiveEnimalsViewModel());
            }

            return View(model);
        }
        public ActionResult Weapon()
        {
            var model = PageService.GetPageByName("DirectionsWeapon", this.CurrentLangCode);

            if (model == null)
            {
                return View(new WeaponViewModel());
            }

            return View(model);
        }
        public ActionResult Meditation()
        {
            var model = PageService.GetPageByName("DirectionsMeditation", this.CurrentLangCode);

            if (model == null)
            {
                return View(new MeditationViewModel());
            }

            return View(model);
        }
    }
}