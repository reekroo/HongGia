using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Base;
using HongGia.Core.Parameters.Base;

namespace HongGia.Core.Models.Views
{
    public class HomeView
    {
        public IEnumerable<ImageParameters> SliderImages { get; set; }

        public IEnumerable<News> TopNews { get; set; }
    }
    
    public class FeedBackView : IFeedBackView
    {
        public IEnumerable<IFeedBack> FeedBacks { get; set; }
    }
}