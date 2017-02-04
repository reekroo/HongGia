using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
    public class VideoView : IVideoView
    {
        public IEnumerable<IVideo> AllVideo { get; set; }
    }

    public class BooksView : IBooksView
    {
        public IEnumerable<IBook> AllBooks { get; set; }
    }
}