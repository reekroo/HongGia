using System.Linq;
using System.Web.Mvc;

using HongGia.BL.SmallFunctional;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.Controllers
{
	public class NewsController : DefaultController
	{
		[HttpGet]
		public ActionResult AllNews(int pageNum = 0)
		{
			var allNews = NewsService.GetAllNews();

			ViewData["PageNum"] = pageNum;
			ViewData["ItemCount"] = allNews?.AllNews.Count() ?? 0;
			ViewData["PageSize"] = PageSizeConstants.News;

			if (allNews == null)
			{
				return View(new AllNewsView());
			}

			allNews.AllNews.ToList().ForEach(x => x.Text = StringTruncater.Truncate(x.Text));

			allNews.AllNews = allNews.AllNews.OrderByDescending(p => p.Date).Skip(PageSizeConstants.News * pageNum).Take(PageSizeConstants.News).ToList();

			return View(allNews);
		}

		[HttpGet]
		public ActionResult News(int id)
		{
			var news = NewsService.GetNews(id);

			if (news == null)
			{
				return View(new NewsView());
			}

			return View(news);
		}
	}
}