using System.Collections.Generic;

using HongGia.Core.Models;

namespace HongGia.Models
{
    public class VideoViewModel
    {
        public IEnumerable<Video> AllVideo { get; set; }
    }

    public class BooksViewModel
    {
        public IEnumerable<Book> AllBooks { get; set; }
    }
}