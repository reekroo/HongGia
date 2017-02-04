using System.Web.Mvc;

using HongGia.Core.Controllers;
using HongGia.DB.Services;

namespace HongGia.Controllers
{
    public class ArticleController : DefaultController
    {
        public ActionResult AllArticles()
        {
            var result = ArtircleService.GetArticles();

            return View(result);
        }
        
        public ActionResult Article(int id)
        {
            var result = ArtircleService.GetArticle(id);

            return View(result);
        }
    }
}