using System.Collections.Generic;
using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Models
{
    public class AllPhotoViewModel : IAllPhotoView
    {
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<IPhoto> AllPhoto { get; set; }
    }
    
    public class CategoryPhotoViewModel : ICategoryPhotoView
    {
        public string Category { get; set; }
        public IEnumerable<IPhoto> CategoryPhoto { get; set; }
    }
}