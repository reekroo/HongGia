using System.Collections.Generic;

using HongGia.Core.Models.Base;

namespace HongGia.Core.Models.Views
{
    public class AllPhotoView
    {
        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<Photo> AllPhoto { get; set; }
    }


    public class CategoryPhotoView
    {
        public string Category { get; set; }

        public IEnumerable<Photo> CategoryPhoto { get; set; }
    }
}