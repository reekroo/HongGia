using System;
using HongGia.Core.Parameters.Base;

namespace HongGia.Core.Models.Base
{
    public class News
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public ImageParameters Image { get; set; }
        public string Language { get; set; }
    }
}
