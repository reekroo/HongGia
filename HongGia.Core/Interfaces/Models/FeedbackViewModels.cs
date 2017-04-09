using System.Collections.Generic;
using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
    public interface IFeedBacksView
    {
        IEnumerable<IFeedBack> FeedBacks { get; set; }
    }
}