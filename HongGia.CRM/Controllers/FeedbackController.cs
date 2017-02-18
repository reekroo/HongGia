using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Interfaces.Base;

using HongGia.CRM.Models;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public ActionResult Index(string lang, int pageNum = 0)
        {
            var result = FeedbackService.GetFeedbasks();

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = result?.FeedBacks.Count() ?? 0;
            ViewData["PageSize"] = 20;

            if (result == null)
            {
                return View(new AllNewsViewModel());
            }

            result.FeedBacks = result.FeedBacks.OrderBy(p => p.Date).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

            return View(result);
        }

        [HttpGet]
        public ActionResult Add(string lang)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(IFeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                FeedbackService.SetFeedback(feedback);
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Remove(int feedbackId)
        {
            if (ModelState.IsValid)
            {
                FeedbackService.RemoveFeedback(feedbackId);
            }

            return View("Index");
        }
    }
}