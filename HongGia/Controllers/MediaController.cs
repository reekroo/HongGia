using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Constants;
using HongGia.Core.Controllers;
using HongGia.Core.Models;
using HongGia.Core.Parameters.Base;

using HongGia.Models;

namespace HongGia.Controllers
{
    public class MediaController : DefaultController
    {
        private VideoViewModel temp = new VideoViewModel()
        {
            AllVideo = new List<Video>()
            {
                new Video() { Id = 1, Name = "1", Path = ""},
                new Video() { Id = 2, Name = "2", Path = "http://kung-fu.by/Media/books/Dao_meditacii.djvu", Screen = new ImageParameters() {Alt = "1", Src = "https://i.ytimg.com/vi/QQPGaAb_Fr4/hqdefault.jpg?custom=true&w=196&h=110&stc=true&jpg444=true&jpgq=90&sp=68&sigh=NkDixts7N8eJHsnLv5cIXl5pHEc"} },
                new Video() { Id = 3, Name = "3", Path = "https://www.youtube.com/watch?v=Ne1aBAUzajE&t=76s"},
                new Video() { Id = 4, Name = "4", Path = "https://www.youtube.com/watch?v=xmUUYa9w1xY"},
                new Video() { Id = 5, Name = "5", Path = "https://www.youtube.com/watch?v=610Es0bcZFs"},
                new Video() { Id = 6, Name = "6", Path = "https://www.youtube.com/watch?v=Z3dgeWORqsg"},
                new Video() { Id = 7, Name = "7", Path = "https://www.youtube.com/watch?v=1KMF6Vj0qq0"},
            }
        };
        private BooksViewModel tempBooks = new BooksViewModel()
        {
            AllBooks = new List<Book>()
            {
                new Book() { Id = 1, Name = "1", Path = ""},
                new Book() { Id = 4, Name = "4", Path = "https://www.youtube.com/watch?v=xmUUYa9w1xY"},
                new Book() { Id = 5, Name = "5", Path = "https://www.youtube.com/watch?v=610Es0bcZFs"},
                new Book() { Id = 6, Name = "6", Path = "https://www.youtube.com/watch?v=Z3dgeWORqsg"},
                new Book() { Id = 7, Name = "7", Path = "https://www.youtube.com/watch?v=1KMF6Vj0qq0"},
            }
        };


        // GET: Media
        public ActionResult Articles()
        {
            return View();
        }

        public ActionResult Books()
        {
            var result = tempBooks;
            return View(result);
        }

        public ActionResult Video(int pageNum = 0)
        {
            var result = temp;

            ViewData["PageNum"] = pageNum;
            ViewData["ItemCount"] = result.AllVideo.Count();
            ViewData["PageSize"] = PageConstants.PageVideoSize;

            result.AllVideo = result.AllVideo.OrderBy(p => p.Id).Skip(PageConstants.PageCategoriesPhotoSize * pageNum).Take(PageConstants.PageVideoSize).ToList();

            return View(result);
        }
    }
}