using System.Web.Mvc;

using HongGia.CRM.Models;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
    public class CatigoryController : Controller
    {
        [HttpGet]
        public ActionResult Index(int pageNum = 0)
        {
            var result = CatigoryService.GetCatigories();
            
            if (result == null)
            {
                return View(new AllNewsViewModel());
            }

            return View(result);
        }
    }
}