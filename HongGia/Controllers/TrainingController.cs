using System.Web.Mvc;

namespace HongGia.Controllers
{
    public class TrainingController : Controller
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