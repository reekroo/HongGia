using System.Web.Mvc;

using HongGia.Core.Controllers;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.Controllers
{
	public class ArticleController : DefaultController
	{
		public ActionResult Articles()
		{
			var result = ArtircleService.GetArticles();

			if (result == null)
			{
				return View(new ArticlesView());
			}

			return View(result);
		}

		public ActionResult Article(int id)
		{
			var result = ArtircleService.GetArticle(id);

			if (result == null)
			{
				return View(new ArticleView());
			}

			return View(result);
		}
	}
}