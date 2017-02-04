using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
    public class HomeView : IHomeView
    {
        public IEnumerable<IImage> SliderImages { get; set; }

        public IEnumerable<INews> TopNews { get; set; }
    }
    
    public class FeedBackView : IFeedBackView
    {
        public IEnumerable<IFeedBack> FeedBacks { get; set; }
    }
}