using System.Collections.Generic;
using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
    public interface IFeedBackView
    {
        IEnumerable<IFeedBack> FeedBacks { get; set; }
    }
}