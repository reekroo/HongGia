using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Interfaces.Parameters;

namespace HongGia.Models
{
    public class HomeViewModel : IHomeView
    {
        public IEnumerable<IImage> SliderImages { get; set; }
        public IEnumerable<INews> TopNews { get; set; }
    }
    
    public class FeedBackViewModel : IFeedBackView
    {
        public IEnumerable<IFeedBack> FeedBacks { get; set; }
    }
}