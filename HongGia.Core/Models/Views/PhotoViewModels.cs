using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
    public class AllPhotoView : IAllPhotoView
    {
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<IPhoto> AllPhoto { get; set; }
    }


    public class CategoryPhotoView : ICategoryPhotoView
    {
        public string Category { get; set; }

        public IEnumerable<IPhoto> CategoryPhoto { get; set; }
    }
}