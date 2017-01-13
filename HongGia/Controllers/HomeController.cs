using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

using HongGia.Models;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;
using HongGia.Core.Parameters;

namespace HongGia.Controllers
{
    public class HomeController : DefaultController
    {
        private HomeViewModel temp = new HomeViewModel()
        {
            SliderImages = new List<ImageParameters>()
            {
                new ImageParameters() {Alt = "1", Src = "/Content/Images/download.svg"},
                new ImageParameters() {Alt = "2", Src = "/Content/Images/download.svg"},
                new ImageParameters() {Alt = "3", Src = "/Content/Images/download.svg"}
            },
            TopNews = new List<NewsViewModel>()
            {
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "111", Text = "124qfer asf", Id = 1},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "112", Text = "124qfer asf", Id = 2},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "113", Text = "124qfer asf", Id = 3},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "114", Text = "124qfer asf", Id = 4},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "115", Text = "124qfer asf", Id = 5},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "116", Text = "124qfer asf", Id = 6},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "117", Text = "124qfer asf", Id = 7},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "118", Text = "124qfer asf", Id = 8},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "119", Text = "124qfer asf", Id = 9},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "1110", Text = "124qfer asf", Id = 10},
                new NewsViewModel() {Date = "12.12.12".AsDateTime(), Header = "1111", Text = "124qfer asf", Id = 11}
            }
        };

        private FeedBackViewModel tempFeedBack = new FeedBackViewModel()
        {
            FeedBacks = new List<FeedBack>()
            {
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""},
                new FeedBack() {Date = "12.12.12".AsDateTime(), Name = "111", Text = "124qfer asf", Id = 1,Email = "1111111111@eeee",Language = ""}
            }
        };

        //readonly EntitiesDB _context = new EntitiesDB();
        

        public ActionResult Index()
        {
            var model = temp;
            
            model.TopNews = model.TopNews.Where(x => x.Language == CurrentLangCode || string.IsNullOrEmpty(x.Language)).OrderBy(x => x.Date).Take(PageConstants.PageIndexNewsSize).ToList();

            return View(model);
        }
        
        [HttpGet]
        public ActionResult FeedBack(int pageNum = 0)
        {
            var feedbacks = tempFeedBack;

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = feedbacks.FeedBacks.Count();
            ViewData["PageSize"] = PageConstants.PageFeedbackSize;

            feedbacks.FeedBacks = feedbacks.FeedBacks.OrderBy(p => p.Date).Skip(PageConstants.PageFeedbackSize * pageNum).Take(PageConstants.PageFeedbackSize).ToList();

            return View(feedbacks);
        }

        [HttpPost]
        public ActionResult FeedBack(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Id = 1;
                feedback.Date = DateTime.Now;
                feedback.Language = CurrentLangCode;

                //_context.FeedBack.Add(feedback);
                //_context.SaveChanges();

                return View("FeedBack");
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