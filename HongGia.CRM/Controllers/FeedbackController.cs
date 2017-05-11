using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
    [Authorize(Roles = "admin")]
    public class FeedbackController : Controller
	{
		[HttpGet]
		public ActionResult Index(int pageNum = 0)
		{
			var result = FeedbackService.GetFeedbasks();

			ViewData["PageNum"] = pageNum;
			ViewData["ItemCount"] = result?.FeedBacks.Count() ?? 0;
			ViewData["PageSize"] = PageSizeConstants.UnicSize;

			if (result == null)
			{
				return View(new FeedBacksView());
			}

			result.FeedBacks = result.FeedBacks.OrderBy(p => p.Id).Skip(PageSizeConstants.UnicSize * pageNum).Take(PageSizeConstants.UnicSize).ToList();

			return View(result);
		}

		[HttpPost]
		public ActionResult Add(FeedBack feedback)
		{
			if (ModelState.IsValid)
			{
				FeedbackService.SetFeedback(feedback);
			}

			return RedirectToAction("Index");
		}

        [HttpPost]
        public ActionResult Remove(int feedbackId)
        {
            if (ModelState.IsValid)
            {
                FeedbackService.RemoveFeedback(feedbackId);
            }

            return RedirectToAction("Index");
        }
    }
}