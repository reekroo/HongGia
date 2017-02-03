using System.Web.Mvc;

using HongGia.Core.Controllers;

namespace HongGia.Controllers
{
    public class TrainingController : DefaultController
    {
        // GET: Training
        public ActionResult Groups()
        {
            return View();
        }
        public ActionResult Online()
        {
            return View();
        }
        public ActionResult Seminars()
        {
            return View();
        }
    }
}