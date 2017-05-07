﻿using System.Web;
using System.Web.Mvc;

//using HongGia.BL.FileSaver;

using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Services;

namespace HongGia.CRM.Controllers
{
	public class SliderController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			var result = ImageService.GetSliderImages();

			if (result == null)
			{
				return View(new SliderView());
			}

			return View(result);
		}

		[HttpGet]
		public ActionResult TopImage()
		{
			var result = ImageService.GetSliderImages("top");

			if (result == null)
			{
				return View(new SliderView());
			}

			return View(result);
		}

		[HttpPost]
		public ActionResult Add(Image image)
		{
			if (ModelState.IsValid)
			{
				//var save = new Saver(filePhoto, image);
				//save.Save();

				image.Type = "slider";
				ImageService.AddImage(image);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult AddTop(Image image)
		{
			if (ModelState.IsValid)
			{
				image.Type = "top";
				ImageService.AddImage(image);
			}

			return RedirectToAction("TopImage");
		}

		[HttpPost]
		public ActionResult Remove(int imageId)
		{
			if (ModelState.IsValid)
			{
				var result = ImageService.RemoveImage(imageId);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult RemoveTop(int imageId)
		{
			if (ModelState.IsValid)
			{
				var result = ImageService.RemoveImage(imageId);
			}

			return RedirectToAction("TopImage");
		}
	}
}