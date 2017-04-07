using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
    public interface IVideoView
	{
		IEnumerable<string> Categories { get; set; }
		IEnumerable<IVideo> AllVideo { get; set; }
    }

    public interface IBooksView
    {
        IEnumerable<IBook> AllBooks { get; set; }
    }
}