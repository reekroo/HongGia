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
			var result = TopicService.AddNullableTopic(pageContentId);

			return RedirectToAction("AddOrUpdate", "BasePage", new {name = name, lang = lang});
		}

		[HttpPost]
		public ActionResult Update(Topic topic, string name, string lang)
		{
			return RedirectToAction("AddOrUpdate", "BasePage", new { name = name, lang = lang });
		}

		[HttpPost]
		public ActionResult Remove(int topicId, string name, string lang)
		{
			return RedirectToAction("AddOrUpdate", "BasePage", new { name = name, lang = lang });
		}

	}
}