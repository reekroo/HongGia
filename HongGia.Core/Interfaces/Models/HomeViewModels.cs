using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
    public interface IHomeView
    {
        IEnumerable<IImage> SliderImages { get; set; }
        IEnumerable<INews> TopNews { get; set; }
    }
}