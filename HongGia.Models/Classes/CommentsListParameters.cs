using System;

namespace HongGia.Models.Classes
{
    public class CommentsListParameters : ListParameters
    {
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
