using System.Web.Mvc;

namespace HongGia.CRM.Controllers
{
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}