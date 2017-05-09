using System.Linq;
using System.Web.Mvc;

using HongGia.BL.SmallFunctional;

using HongGia.Core.Constants;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class VideoController : Controller
	{
		[HttpGet]
		public ActionResult Index(int pageNum = 0)
		{
			var result = VideoService.GetAllVideo();

			ViewData["PageNum"] = pageNum;
			ViewData["ItemCount"] = result?.AllVideo.Count() ?? 0;
			ViewData["PageSize"] = 20;

			if (result == null)
			{
				return View(new VideosView());
			}

			foreach (var video in result.AllVideo)
			{
				video.Screen = new Image()
				{
					Src = FilePathCreator.GetYouTubeImagePath(video.Path),
					Alt = video.Name
				};
			}

			result.AllVideo = result.AllVideo.OrderBy(p => p.Id).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

			return View(result);
		}

		[HttpGet]
		public ActionResult Add()
		{
			var result = new VideoView()
			{
				Categories = CatigoryService.GetCatigoriesListStringByType("video")
			};

			return View(result);
		}

		[HttpGet]
		public ActionResult Update(int videoId)
		{
			var result = VideoService.GetVideo(videoId);

			if (result == null)
			{
				return View("Add");
			}

			return View(result);
		}
		
		[HttpPost]
		public ActionResult Add(VideoView video)
		{
			if (ModelState.IsValid)
			{
				var str = video.Categories.FirstOrDefault();

				video.Categories = string.IsNullOrEmpty(str) == false ? str.Split(',') : null;
				video.Path = FilePathCreator.GetYouTubePath(video.Path);

				var result = VideoService.AddVideo(video);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Update(VideoView video)
		{
			if (ModelState.IsValid)
			{
				var str = video.Categories.FirstOrDefault();

				video.Categories = string.IsNullOrEmpty(str) == false ? str.Split(',') : null;

				VideoService.UpdateVideo(video);
			}

			return RedirectToAction("Index");
		}
		
		[HttpPost]
		public ActionResult Remove(int videoId)
		{
			if (ModelState.IsValid)
			{
				var result = VideoService.RemoveVideo(videoId);
			}

			return RedirectToAction("Index");
		}
	}
}