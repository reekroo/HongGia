using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
	public interface IVideosView
	{
		IEnumerable<string> Categories { get; set; }
		IEnumerable<IVideo> AllVideo { get; set; }
	}

	public interface IVideoView : IVideo
	{
	}

	public interface IBooksView
	{
		IEnumerable<IBook> AllBooks { get; set; }
	}
}