using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.CRM.Models
{
    public class FeedBackViewModel : IFeedBackView
    {
        public IEnumerable<IFeedBack> FeedBacks { get; set; }
    }
}