using System.Collections.Generic;

using HongGia.Core.Models.Base;

namespace HongGia.Core.Models.Views
{
    public class AllArticlesView
    {
        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<Article> AllArticles { get; set; }
    }
    
    public class ArticleView : Article
    {
    }
}