using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;
using HongGia.DB.Services;

namespace HongGia.Controllers
{
    public class NewsController : DefaultController
    {
        public ActionResult AllNews(int pageNum = 0)
        {
            var allNews = NewsService.GetAllNews();

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = allNews.AllNews.Count();
            ViewData["PageSize"] = PageConstants.PageNewsSize;
            
            allNews.AllNews = allNews.AllNews.OrderBy(p => p.Date).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

            return View(allNews);
        }

        public ActionResult News(int id)
        {
            var news = NewsService.GetNews(id);

            return View(news);
        }
    }
}