using System;
using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Base;

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
                return View(new FeedBackViewModel());
            }

            result.FeedBacks = result.FeedBacks.OrderBy(p => p.Id).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

            return View(result);
        }
        
        [HttpPost]
        public ActionResult Add(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Date = DateTime.Now;
                feedback.Language = "ru";

                FeedbackService.SetFeedback(feedback);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IFeedBackView Remove(int feedbackId)
        {
            if (ModelState.IsValid)
            {
                FeedbackService.RemoveFeedback(feedbackId);
            }

            var result = FeedbackService.GetFeedbasks();

            var s = ViewData["PageNum"] ?? 0;
            ViewData["ItemCount"] = result?.FeedBacks.Count() ?? 0;
            ViewData["PageSize"] = 20;

            if (result == null)
            {
                return new FeedBackViewModel();
            }

            result.FeedBacks = result.FeedBacks.OrderBy(p => p.Id).Skip(PageConstants.PageNewsSize * (int)s).Take(PageConstants.PageNewsSize).ToList();

            return result;
        }

        //[HttpPost]
        //public ActionResult Remove(int feedbackId)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        FeedbackService.RemoveFeedback(feedbackId);
        //    }
            
        //    return RedirectToAction("Index");
        //}
    }
}