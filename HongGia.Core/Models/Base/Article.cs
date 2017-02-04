using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class Article : IArticle
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string HtmlText { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
