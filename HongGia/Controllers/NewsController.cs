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
		public ActionResult AllNews(int pageNum = 0)
		{
			var allNews = NewsService.GetAllNews();

			ViewData["PageNum"] = pageNum;
			ViewData["ItemCount"] = allNews?.AllNews.Count() ?? 0;
			ViewData["PageSize"] = PageConstants.PageNewsSize;

			if (allNews == null)
			{
				return View(new AllNewsView());
			}

            allNews.AllNews.ToList().ForEach(x => x.Text = StringTruncater.Truncate(x.Text));

            allNews.AllNews = allNews.AllNews.OrderBy(p => p.Date).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

			return View(allNews);
		}

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