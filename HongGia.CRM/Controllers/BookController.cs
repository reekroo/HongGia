using System.Web.Mvc;

using HongGia.Core.Interfaces.Base;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var result = BookService.GetAllBookFiles();

            return View(result);
        }

        [HttpPost]
        public ActionResult Add(IBook book)
        {
            var result = BookService.AddBook(book);

            return View("Index");
        }

        [HttpPost]
        public ActionResult Remove(int bookId)
        {
            var result = BookService.RemoveBook(bookId);

            return View("Index");
        }
    }
}