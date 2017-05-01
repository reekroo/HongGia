using System.Web.Mvc;
using HongGia.Core.Models.Base;
using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class TopicController : Controller
	{

		[HttpPost]
		public ActionResult Add(int pageContentId, string name, string lang)
		{
			var result = TopicService.AddNullable(pageContentId);

			return RedirectToAction("AddOrUpdate", "BasePage", new {name = name, lang = lang});
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Update(Topic topic, string name, string lang)
		{
			var result = TopicService.Update(topic);

			return RedirectToAction("AddOrUpdate", "BasePage", new { name = name, lang = lang });
		}

		[HttpPost]
		public ActionResult Remove(int topicId, string name, string lang)
		{
			var result = TopicService.Remove(topicId);

			return RedirectToAction("AddOrUpdate", "BasePage", new { name = name, lang = lang });
		}

	}
}