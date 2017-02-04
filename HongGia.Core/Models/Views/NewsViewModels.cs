using System;
using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Interfaces.Parameters;

namespace HongGia.Core.Models.Views
{
    public class AllNewsView : IAllNewsView
    {
        public IEnumerable<INews> AllNews { get; set; }
    }

    public class NewsView : INewsView
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public IImage Image { get; set; }
        public string Language { get; set; }
    }
}