using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
    public class PhotosView : IPhotosView
    {
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<IPhoto> AllPhoto { get; set; }
    }


    public class CategoryPhotoView : ICategoryPhotoView
    {
        public string Category { get; set; }

        public IEnumerable<IPhoto> CategoryPhoto { get; set; }
    }

	public class PhotoView : IPhotoView
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public IEnumerable<string> Categories { get; set; }
	}
}