using System.Linq;
using System.Web.Mvc;

using HongGia.BL.SmallFunctional;

using HongGia.Core.Constants;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class NewsController : Controller
	{
		[HttpGet]
		public ActionResult Index(string lang, int pageNum = 0)
		{
			var result = NewsService.GetAllNews();

			ViewData["PageNum"] = pageNum;
			ViewData["ItemCount"] = result?.AllNews.Count() ?? 0;
			ViewData["PageSize"] = 20;

			if (result == null)
			{
				return View(new AllNewsView());
			}

			result.AllNews = result.AllNews.OrderBy(p => p.Date).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

			return View(result);
		}

		[HttpGet]
		public ActionResult Add(string lang)
		{
			return View();
		}

		[HttpGet]
		public ActionResult Update(int newsId)
		{
			var result = NewsService.GetNews(newsId);

			if (result == null)
			{
				return View("Add");
			}

			return View(result);
		}

		[HttpPost]
		public ActionResult Add(News news)
		{
			if (ModelState.IsValid)
			{
				news.Image = new Image()
				{
					Src = FilePathCreator.GetGooglePath(news.ImagePAth),
					Alt = news.Header
				};

				NewsService.AddNews(news);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Update(News news)
		{
			if (ModelState.IsValid)
			{
				NewsService.UpdateNews(news);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public bool Remove(int newsId)
		{
			if (ModelState.IsValid)
			{
				NewsService.RemoveNews(newsId);

				return true;
			}

			return false;
		}
	}
}