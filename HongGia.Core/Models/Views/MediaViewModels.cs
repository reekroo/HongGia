using System.Collections.Generic;

using HongGia.Core.Models.Base;

namespace HongGia.Core.Models.Views
{
    public class VideoView
    {
        public IEnumerable<Video> AllVideo { get; set; }
    }

    public class BooksView
    {
        public IEnumerable<Book> AllBooks { get; set; }
    }
}