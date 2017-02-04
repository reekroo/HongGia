using System;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class FeedBack : IFeedBack
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }
    }
}
