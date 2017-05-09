using System.Web.Mvc;

using HongGia.Core.Controllers;

namespace HongGia.Controllers
{
	public class ErrorController : DefaultController
	{
		//public ActionResult Index()
		//{
		//	Response.StatusCode = 404;
		//	return View("NotFound");
		//}

		public ActionResult NotFound()
		{
			Response.StatusCode = 404;
			return View();
		}

		public ActionResult Forbidden()
		{
			Response.StatusCode = 403;
			return View();
		}

		public ActionResult BadRequest()
		{
			Response.StatusCode = 400;
			return View();
		}

		public ActionResult Server()
		{
			Response.StatusCode = 500;
			return View();
		}
	}
}