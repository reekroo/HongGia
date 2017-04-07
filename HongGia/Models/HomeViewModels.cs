using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

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

    public class MasterViewModel : BasePageViewModels
    {
    }
}