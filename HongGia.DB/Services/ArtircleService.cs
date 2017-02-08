using System.Linq;

using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;
using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class ArtircleService
    {
        public static IArticlesView GetArticles()
        {
            using (var context = new EntitiesDB())
            {
                if (context.Articles == null || context.Articles.Any() == false ||
                    context.Catigories.Any(x => x.Type.ToLower() == "article") == false)
                {
                    return null;
                }

                var catigories = context.Catigories.Where(x => x.Type.ToLower() == "article").Select(y => y.Name).ToList();
                var articles = context.Articles.Select(article => new Core.Models.Base.Article()
                            {
                                Id = article.Id,
                                Header = article.Header,
                                HtmlText = article.HTMLText,
                                
                                Categories = article.Catigories.Select(x => x.Name)
                }).ToList();

                var allvideos = new AllArticlesView()
                {
                    Categories = catigories,
                    AllArticles = articles
                };

                return allvideos;
            }
        }

        public static IArticleView GetArticle(int articleId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Articles == null ||
                    context.Articles.Any(a => a.Catigories.Any(x => x.Type.ToLower() == "article")) == false ||
                    context.Catigories.Any(x => x.Type.ToLower() == "article") == false)
                {
                    return null;
                }

                var article = context.Articles.FirstOrDefault(x => x.Id == articleId);
                
                if (article == null)
                {
                    return null;
                }

                return new ArticleView()
                {
                    Header = article.Header,
                    HtmlText = article.HTMLText,

                    Categories = article.Catigories.Select(x => x.Name)
                };
            }
        }
    }
}
