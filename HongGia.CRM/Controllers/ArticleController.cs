using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Interfaces.Base;

using HongGia.CRM.Models;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        public ActionResult Index(int pageNum = 0)
        {
            var result = ArtircleService.GetArticles();

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = result?.AllArticles.Count() ?? 0;
            ViewData["PageSize"] = 20;

            if (result == null)
            {
                return View(new AllNewsViewModel());
            }

            result.AllArticles = result.AllArticles.OrderBy(p => p.Id).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Update(int articleId)
        {
            var result = ArtircleService.GetArticle(articleId);

            if (result == null)
            {
                return View("Add");
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult Add(IArticle article)
        {
            if (ModelState.IsValid)
            {
                ArtircleService.AddArticle(article);
            }

            return View("Update", article.Id);
        }

        [HttpPost]
        public ActionResult Update(IArticle article)
        {
            if (ModelState.IsValid)
            {
                ArtircleService.UpdateArticle(article);
            }

            return View("Update");
        }
        
        [HttpPost]
        public ActionResult Remove(int articleId)
        {
            if (ModelState.IsValid)
            {
                ArtircleService.RemoveArticle(articleId);
            }

            return View("Index");
        }

    }
}