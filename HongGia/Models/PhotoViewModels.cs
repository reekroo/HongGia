using System.Collections.Generic;

using HongGia.Core.Models;

namespace HongGia.Models
{
    public class AllPhotoViewModel
    {
        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<Photo> AllPhoto { get; set; }
    }


    public class CategoryPhotoViewModel
    {
        public string Category { get; set; }

        public IEnumerable<Photo> CategoryPhoto { get; set; }
    }
}