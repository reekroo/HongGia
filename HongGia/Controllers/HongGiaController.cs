using System.Web.Mvc;

using HongGia.Core.Controllers;
using HongGia.DB.Services;
using HongGia.Models;

namespace HongGia.Controllers
{
    public class HongGiaController : DefaultController
    {
        public ActionResult About()
        {
            var model = PageService.GetPageByName("HongGiaAbout",this.CurrentLangCode);

            if (model == null)
            {
                return View(new AboutViewModel());
            }

            return View(model);
        }
        public ActionResult History()
        {
            var model = PageService.GetPageByName("HongGiaHistory", this.CurrentLangCode);

            if (model == null)
            {
                return View(new HistoryViewModel());
            }

            return View(model);
        }
        public ActionResult Levels()
        {
            var model = PageService.GetPageByName("HongGiaLevels", this.CurrentLangCode);

            if (model == null)
            {
                return View(new LevelsViewModel());
            }

            return View(model);
        }
        public ActionResult ToBeginner()
        {
            var model = PageService.GetPageByName("HongGiaToBeginner", this.CurrentLangCode);

            if (model == null)
            {
                return View(new ToBeginnerViewModel());
            }

            return View(model);
        }
        public ActionResult Program()
        {
            var model = PageService.GetPageByName("HongGiaProgram", this.CurrentLangCode);

            if (model == null)
            {
                return View(new ProgramViewModel());
            }

            return View(model);
        }
    }
}