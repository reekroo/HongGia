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

            return View();
        }
        public ActionResult History()
        {
            return View();
        }
        public ActionResult Levels()
        {
            return View();
        }
        public ActionResult ToBeginner()
        {
            return View();
        }
        public ActionResult Program()
        {
            return View();
        }
    }
}