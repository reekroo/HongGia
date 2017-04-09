using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
	public class VideosView : IVideosView
	{
		public IEnumerable<string> Categories { get; set; }
		public IEnumerable<IVideo> AllVideo { get; set; }
	}

	public class VideoView : IVideoView
	{
		public string Name { get; set; }
		public string Path { get; set; }
		public int Id { get; set; }
		public IImage Screen { get; set; }
		public IEnumerable<string> Categories { get; set; }
	}

	public class BooksView : IBooksView
	{
		public IEnumerable<IBook> AllBooks { get; set; }
	}
}