using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HongGia.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Master()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult FeedBack()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}