using System.Linq;
using System.Web.Mvc;

using HongGia.BL.Mailer;
using HongGia.BL.SmallFunctional;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.Controllers
{
	public class HomeController : DefaultController
	{
		public ActionResult Index()
		{
			var model = HomeService.GetHome(CurrentLangCode);

			if (model == null)
			{
				return View(new HomeView());
			}

            model.TopNews.ToList().ForEach(x => x.Text = StringTruncater.Truncate(x.Text));
            
            return View(model);
		}

		[HttpGet]
		public ActionResult FeedBack(int pageNum = 0)
		{
			var feedbacks = FeedbackService.GetFeedbasks();

			ViewData["PageNum"] = pageNum;
			ViewData["ItemCount"] = feedbacks?.FeedBacks.Count() ?? 0;
			ViewData["PageSize"] = PageConstants.PageFeedbackSize;

			if (feedbacks == null)
			{
				return View(new FeedBacksView());
			}

			feedbacks.FeedBacks = feedbacks.FeedBacks.OrderBy(p => p.Date).Skip(PageConstants.PageFeedbackSize * pageNum).Take(PageConstants.PageFeedbackSize).ToList();

			return View(feedbacks);
		}

		[HttpPost]
		public ActionResult FeedBack(FeedBack feedback)
		{
			if (ModelState.IsValid)
			{
				feedback.Language =this.CurrentLangCode;

				FeedbackService.SetFeedback(feedback);
			}

			return RedirectToAction("FeedBack");
		}

		[HttpPost]
		public ActionResult Mail(Email email)
		{
			if (ModelState.IsValid)
			{
				var mailer = new Mailer(email);
				mailer.Send();
			}

			return RedirectToAction("Contacts");
		}

		public ActionResult Contacts()
		{
			return View();
		}

		public ActionResult Master()
		{
			var model = BasePageService.GetBasePageContent("HomeMaster", this.CurrentLangCode);

			if (model == null)
			{
				return View(new BasePageView());
			}

			return View(model);
		}

	}
}