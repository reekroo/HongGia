using System;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Parameters;

namespace HongGia.Core.Models.Base
{
    public class News : INews
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public IImage Image { get; set; }
        public string Language { get; set; }
    }
}
