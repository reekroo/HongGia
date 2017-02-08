using System.Web.Mvc;

using HongGia.Core.Controllers;
using HongGia.DB.Services;
using HongGia.Models;

namespace HongGia.Controllers
{
    public class ArticleController : DefaultController
    {
        public ActionResult AllArticles()
        {
            var result = ArtircleService.GetArticles();

            if (result == null)
            {
                return View(new AllArticlesViewModel());
            }

            return View(result);
        }
        
        public ActionResult Article(int id)
        {
            var result = ArtircleService.GetArticle(id);

            if (result == null)
            {
                return View(new ArticleViewModel());
            }

            return View(result);
        }
    }
}