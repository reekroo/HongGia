using System.Collections.Generic;

using HongGia.Core.Models;
using HongGia.Core.Parameters.Base;

namespace HongGia.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ImageParameters> SliderImages { get; set; }

        public IEnumerable<NewsViewModel> TopNews { get; set; }
    }
    
    public class FeedBackViewModel
    {
        public IEnumerable<FeedBack> FeedBacks { get; set; }
    }
}