using System.Collections.Generic;

using HongGia.Core.Models;

namespace HongGia.Models
{
    public class AllArticlesViewModel
    {
        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<Article> AllArticles { get; set; }
    }


    public class ArticleViewModel : Article
    {
    }
}