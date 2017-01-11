using System;
using System.Collections.Generic;

using HongGia.Core.Parameters;

namespace HongGia.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ImageParameters> SliderImages { get; set; }

        public IEnumerable<NewsViewModel> TopNews { get; set; }
    }
    
    public class FeedBackViewModel
    {
        public IEnumerable<FeedBack> FeedBacks { get; set; }
    }

    public class FeedBack
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }
    }
}