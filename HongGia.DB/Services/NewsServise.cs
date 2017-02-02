﻿using System.Collections.Generic;
using System.Linq;

using HongGia.Core.Models.Views;
using HongGia.Core.Parameters.Base;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class NewsService
    {
        public static AllNewsView GetAllNews()
        {
            using (var context = new EntitiesDB())
            {
                var news = context.News.Select(n => new Core.Models.Base.News()
                {
                    Id = n.Id,
                    Header = n.Header,
                    Text = n.HTMLText,
                    Date = n.Date.GetValueOrDefault(),

                    Language = n.Language.Name,

                    Image = new ImageParameters()
                    {
                        Src = n.Image.Path,
                        Alt = n.Image.Name
                    } 
                }).ToList();

                var allnews = new AllNewsView()
                {
                    AllNews = news
                };

                return allnews;
            }
        }

        public static IEnumerable<Core.Models.Base.News> GetTopNews(int count)
        {
            using (var context = new EntitiesDB())
            {
                var news = new List<Core.Models.Base.News>();

                if (context.News.Count() < count - 1)
                {
                    news = context.News.OrderBy(x => x.Date).Take(count).Select(n => new Core.Models.Base.News()
                            {
                                Id = n.Id,
                                Header = n.Header,
                                Text = n.HTMLText,
                                Date = n.Date.GetValueOrDefault(),

                                Language = n.Language.Name,

                                Image = new ImageParameters()
                                {
                                    Src = n.Image.Path,
                                    Alt = n.Image.Name
                                }
                            }).ToList();
                    
                    return news;
                }

                news = context.News.OrderBy(x => x.Date).Take(count).Select(n => new Core.Models.Base.News()
                        {
                            Id = n.Id,
                            Header = n.Header,
                            Text = n.HTMLText,
                            Date = n.Date.GetValueOrDefault(),

                            Language = n.Language.Name,

                            Image = new ImageParameters()
                            {
                                Src = n.Image.Path,
                                Alt = n.Image.Name
                            }
                        }).ToList();
                
                return news;
            }
        }

        public static NewsView GetNews(int newsId)
        {
            using (var context = new EntitiesDB())
            {
                var news = context.News.FirstOrDefault(x => x.Id == newsId);

                if (news == null)
                {
                    return null;
                }

                return new NewsView()
                {
                    Id = news.Id,
                    Header = news.Header,
                    Text = news.HTMLText,
                    Date = news.Date.GetValueOrDefault(),

                    Language = news.Language.Name,

                    Image = new ImageParameters()
                    {
                        Src = news.Image.Path,
                        Alt = news.Image.Name
                    }
                };
            }
        }
    }
}