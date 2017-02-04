using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
    public interface IVideoView
    {
        IEnumerable<IVideo> AllVideo { get; set; }
    }

    public interface IBooksView
    {
        IEnumerable<IBook> AllBooks { get; set; }
    }
}