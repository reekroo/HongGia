using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Models
{
    public class AllArticlesViewModel : IArticlesView
    {
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<IArticle> AllArticles { get; set; }
    }


    public class ArticleViewModel : IArticleView
    {
        public string HtmlText { get; set; }
        public int Id { get; set; }
        public string Header { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}