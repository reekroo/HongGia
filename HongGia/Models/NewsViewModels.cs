using System.Collections.Generic;

using HongGia.Core.Models;

namespace HongGia.Models
{
    public class AllNewsViewModel
    {
        public IEnumerable<NewsViewModel> AllNews { get; set; }
    }

    public class NewsViewModel : News
    {
    }
}