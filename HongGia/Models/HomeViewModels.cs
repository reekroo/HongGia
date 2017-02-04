using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

using HongGia.Core.Models.Views;

namespace HongGia.Models
{
    public class HomeViewModel : HomeView
    {
    }
    
    public class FeedBackViewModel : IFeedBackView
    {
        public IEnumerable<IFeedBack> FeedBacks { get; set; }
    }
}