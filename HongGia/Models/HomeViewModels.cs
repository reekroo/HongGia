using System.Collections.Generic;
using HongGia.Models.Classes;

namespace HongGia.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ImageParameters> SliderImages { get; set; }

        public IEnumerable<NewsViewModel> TopNews { get; set; }
    }
}