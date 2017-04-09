using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

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
				return View(new ArticlesView());
			}

			result.AllArticles = result.AllArticles.OrderBy(p => p.Id).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

			return View(result);
		}

		[HttpGet]
		public ActionResult Add()
		{
			var result = new ArticleView()
			{
				Categories = CatigoryService.GetCatigoriesListStringByType("article")
			};

			return View(result);
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
		[ValidateInput(false)]
		public ActionResult Add(Article article)
		{
			var str = article.Categories.FirstOrDefault();

			article.Categories = string.IsNullOrEmpty(str) == false ? str.Split(',') : null;

			if (ModelState.IsValid)
			{
				ArtircleService.AddArticle(article);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Update(Article article)
		{
			var str = article.Categories.FirstOrDefault();

			article.Categories = string.IsNullOrEmpty(str) == false ? str.Split(',') : null;

			if (ModelState.IsValid)
			{
				ArtircleService.UpdateArticle(article);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Remove(int articleId)
		{
			if (ModelState.IsValid)
			{
				ArtircleService.RemoveArticle(articleId);
			}

			return RedirectToAction("Index");
		}

	}
}