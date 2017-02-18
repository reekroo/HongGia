using System;
using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.CRM.Models
{
    public class AllNewsViewModel : IAllNewsView
    {
        public IEnumerable<INews> AllNews { get; set; }
    }

    public class NewsViewModel : INewsView
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public IImage Image { get; set; }
        public string Language { get; set; }
    }
}