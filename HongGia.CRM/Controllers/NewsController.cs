using System.Linq;
using System.Web.Mvc;

using HongGia.CRM.Models;

using HongGia.Core.Constants;
using HongGia.Core.Interfaces.Base;

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
                return View(new AllNewsViewModel());
            }

            result.AllNews = result.AllNews.OrderBy(p => p.Date).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

            return View(result);
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

        [HttpGet]
        public ActionResult Add(string lang)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(INews news)
        {
            if (ModelState.IsValid)
            {
                NewsService.UpdateNews(news);
            }

            return View("Update");
        }

        [HttpPost]
        public ActionResult Add(INews news)
        {
            if (ModelState.IsValid)
            {
                NewsService.AddNews(news);
            }

            return View("Update");
        }
        
        [HttpPost]
        public ActionResult Remove(int newsId)
        {
            if (ModelState.IsValid)
            {
                NewsService.RemoveNews(newsId);
            }

            return View("Index");
        }
    }
}