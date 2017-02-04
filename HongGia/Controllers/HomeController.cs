using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;
using HongGia.Core.Interfaces.Base;

using HongGia.DB.Services;

namespace HongGia.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            var model = HomeService.GetHome(CurrentLangCode);
            
            return View(model);
        }
        
        [HttpGet]
        public ActionResult FeedBack(int pageNum = 0)
        {
            var feedbacks = FeedbackService.GetFeedbasks();
            
            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = feedbacks.FeedBacks.Count();
            ViewData["PageSize"] = PageConstants.PageFeedbackSize;
            
            feedbacks.FeedBacks = feedbacks.FeedBacks.OrderBy(p => p.Date).Skip(PageConstants.PageFeedbackSize * pageNum).Take(PageConstants.PageFeedbackSize).ToList();

            return View(feedbacks);
        }

        [HttpPost]
        public ActionResult FeedBack(IFeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                FeedbackService.SetFeedback(feedback);
            }

            return View("FeedBack");
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult Master()
        {
            return View();
        }

    }
}