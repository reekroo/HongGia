﻿using System.Linq;

using HongGia.Core.Models.Views;
using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class ArtircleService
    {
        public static AllArticlesView GetArticles()
        {
            using (var context = new EntitiesDB())
            {
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

        public static ArticleView GetArticle(int articleId)
        {
            using (var context = new EntitiesDB())
            {
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