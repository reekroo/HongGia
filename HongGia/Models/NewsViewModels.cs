using System;
using System.Collections.Generic;

using HongGia.Models.Classes;

namespace HongGia.Models
{
    public class AllNewsViewModel
    {
        public IEnumerable<NewsViewModel> AllNews { get; set; }
    }

    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public ImageParameters Image { get; set; }
        public string Language { get; set; }
    }
}