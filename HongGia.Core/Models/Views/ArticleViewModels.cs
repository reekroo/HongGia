using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
    public class ArticlesView : IArticlesView
    {
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<IArticle> AllArticles { get; set; }
    }
    
    public class ArticleView : IArticleView
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string HtmlText { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}