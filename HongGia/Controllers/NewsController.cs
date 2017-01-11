using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

using HongGia.Models;

using HongGia.Core.Constants;

namespace HongGia.Controllers
{
    public class NewsController : DefaultController
    {
        private AllNewsViewModel temp = new AllNewsViewModel()
        {
            AllNews = new List<NewsViewModel>()
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

        public ActionResult AllNews(int pageNum = 0)
        {
            var allNews = temp;

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = allNews.AllNews.Count();
            ViewData["PageSize"] = PageConstants.PageNewsSize;
            
            allNews.AllNews = allNews.AllNews.OrderBy(p => p.Date).Skip(PageConstants.PageNewsSize * pageNum).Take(PageConstants.PageNewsSize).ToList();

            return View(allNews);
        }

        public ActionResult News(int id)
        {
            var news = temp.AllNews.FirstOrDefault(x => x.Id == id);
            return View(news);
        }
    }
}