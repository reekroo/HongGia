using System.Linq;
using System.Web.Mvc;

using HongGia.BL.SmallFunctional;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.Controllers
{
	public class MediaController : DefaultController
	{
		public ActionResult Books()
		{
			var result = MediaService.GetAllBookFiles();

			if (result == null)
			{
				return View(new BooksView());
			}

			return View(result);
		}

		public ActionResult Video(int pageNum = 0)
		{
			var result = MediaService.GetAllVideo();

			ViewData["PageNum"] = pageNum;
			ViewData["ItemCount"] = result?.AllVideo.Count() ?? 0;
			ViewData["PageSize"] = PageConstants.PageVideoSize;

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

			result.AllVideo = result.AllVideo.OrderBy(p => p.Id).Skip(PageConstants.PageCategoriesPhotoSize * pageNum).Take(PageConstants.PageVideoSize).ToList();

			return View(result);
		}
	}
}