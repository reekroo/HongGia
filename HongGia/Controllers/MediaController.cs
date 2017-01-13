using System.Web.Mvc;
using HongGia.Core.Controllers;

namespace HongGia.Controllers
{
    public class MediaController : DefaultController
    {
        // GET: Media
        public ActionResult Articles()
        {
            return View();
        }
        public ActionResult Books()
        {
            return View();
        }
        public ActionResult Photo()
        {
            return View();
        }
        public ActionResult Video()
        {
            return View();
        }
    }
}