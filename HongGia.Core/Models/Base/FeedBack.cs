using System;

namespace HongGia.Core.Models.Base
{
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
