using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Models
{
    public class VideoViewModel : IVideoView
    {
        public IEnumerable<IVideo> AllVideo { get; set; }
    }

    public class BooksViewModel : IBooksView
    {
        public IEnumerable<IBook> AllBooks { get; set; }
    }
}