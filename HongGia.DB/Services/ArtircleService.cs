﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;

using HongGia.Core.Interfaces.Base;
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

                var allArticles = new ArticlesView()
                {
                    Categories = catigories,
                    AllArticles = articles
                };

                return allArticles;
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
                    Id = article.Id,
                    Header = article.Header,
                    HtmlText = article.HTMLText,

                    Categories = article.Catigories.Select(x => x.Name)
                };
            }
        }
 
        public static bool AddArticle(IArticle article)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Articles == null || 
					context.Articles.Count() < 0 || 
                    context.Catigories.Any(x => x.Type.ToLower() == "article") == false)
                {
                    return false;
                }

                var selectCatigories = CatigoryService.GetCatigoriesByNamesAndType(article.Categories, "article");

                var save = new Article()
                {
                    Header = article.Header,
                    HTMLText = article.HtmlText,
                    Date = DateTime.Now,
				};

				if (selectCatigories != null)
				{
					foreach (var cat in selectCatigories)
					{
						save.Catigories.Add(cat);
						context.Catigories.Attach(cat);
					}
				}
				context.Articles.Add(save);
				
				context.SaveChanges();

                return true;
            }
        }

        public static bool UpdateArticle(IArticle article)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Articles.Any() == false || 
					context.Catigories.Any(x => x.Type.ToLower() == "article") == false)
                {
                    return false;
                }

                var selectArticle = context.Articles.FirstOrDefault(a => a.Id == article.Id);

                if (selectArticle == null)
                {
                    return false;
                }

				var selectCatigories = CatigoryService.GetCatigoriesByNamesAndType(context, article.Categories, "article");

				selectArticle.Catigories.Clear();

				selectArticle.Header = article.Header;
				selectArticle.HTMLText = article.HtmlText;
				selectArticle.Date = DateTime.Now;

				if (selectCatigories != null)
				{
					foreach (var cat in selectCatigories)
					{
						selectArticle.Catigories.Add(cat);
						context.Catigories.Attach(cat);
					}
				}
				context.Articles.AddOrUpdate(selectArticle);

				context.SaveChanges();

                return true;
            }
        }

        public static bool RemoveArticle(int articleId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Articles.Any() == false || 
					context.Catigories.Any(x => x.Type.ToLower() == "article") == false)
                {
                    return false;
                }

                var selectArticle = context.Articles.FirstOrDefault(a => a.Id == articleId);

                if (selectArticle == null)
                {
                    return false;
                }

                context.Articles.Remove(selectArticle);
                context.SaveChanges();

                return true;
            }
        }
    }
}
