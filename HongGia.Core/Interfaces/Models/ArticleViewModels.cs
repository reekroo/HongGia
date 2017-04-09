using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
    public interface IArticlesView
    {
        IEnumerable<string> Categories { get; set; }
        IEnumerable<IArticle> AllArticles { get; set; }
    }
    
    public interface IArticleView : IArticle
    {
    }
}