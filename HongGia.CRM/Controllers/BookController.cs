using System.Linq;
using System.Web.Mvc;

using HongGia.BL.SmallFunctional;

using HongGia.Core.Constants;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class BookController : Controller
	{
		[HttpGet]
		public ActionResult Index(int pageNum = 0)
		{
			var result = BookService.GetAllBookFiles();

			ViewData["PageNum"] = pageNum;
			ViewData["ItemCount"] = result?.AllBooks.Count() ?? 0;
			ViewData["PageSize"] = PageSizeConstants.UnicSize;

			if (result == null)
			{
				return View(new BooksView());
			}

			result.AllBooks = result.AllBooks.OrderBy(p => p.Id).Skip(PageSizeConstants.UnicSize * pageNum).Take(PageSizeConstants.UnicSize).ToList();

			return View(result);
		}

		[HttpPost]
		public ActionResult Add(Book book)
		{
			if (ModelState.IsValid)
			{
				book.Name = book.Header;
				book.Path = FilePathCreator.GetGooglePath(book.Path);

				BookService.AddBook(book);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Remove(int bookId)
		{
			BookService.RemoveBook(bookId);

			return RedirectToAction("Index");
		}
	}
}