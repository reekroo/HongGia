using System.Collections.Generic;

using HongGia.Core.Models.Base;

namespace HongGia.Core.Models.Views
{
    public class AllNewsView
    {
        public IEnumerable<News> AllNews { get; set; }
    }

    public class NewsView : News
    {
    }
}