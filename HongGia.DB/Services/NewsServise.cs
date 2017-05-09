using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class NewsService
    {
        public static IAllNewsView GetAllNews()
        {
            using (var context = new EntitiesDB())
            {
                if (context.News == null || context.News.Any() == false)
                {
                    return null;
                }

                var news = context.News.Select(n => new Core.Models.Base.News()
                {
                    Id = n.Id,
                    Header = n.Header,
                    Text = n.HTMLText,
                    Date = n.Date.Value,

                    Language = n.Language.Name,

                    Image = n.Image == null ? null : new HongGia.Core.Models.Base.Image()
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

        public static IEnumerable<INews> GetTopNews(int count)
        {
            using (var context = new EntitiesDB())
            {
                if (context.News == null || context.News.Any() == false)
                {
                    return null;
                }

                List<Core.Models.Base.News> news;
                
                if (context.News.Count() < count - 1)
                {
                    news = context.News.OrderBy(x => x.Date).Select(n => new Core.Models.Base.News()
                            {
                                Id = n.Id,
                                Header = n.Header,
                                Text = n.HTMLText,
                                Date = n.Date.Value,

                                Language = n.Language.Name,

                                Image = n.Image == null ? null : new HongGia.Core.Models.Base.Image()
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
                            Date = n.Date.Value,

                            Language = n.Language.Name,

                            Image = n.Image == null ? null : new HongGia.Core.Models.Base.Image()
                            {
                                Src = n.Image.Path,
                                Alt = n.Image.Name
                            }
                        }).ToList();
                
                return news;
            }
        }

        public static INewsView GetNews(int newsId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.News == null || context.News.Any(x => x.Id == newsId) == false)
                {
                    return null;
                }

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
                    Date = news.Date.Value,

                    Language = news.Language.Name,

                    Image = news.Image == null ? null : new HongGia.Core.Models.Base.Image()
                    {
                        Src = news.Image.Path,
                        Alt = news.Image.Name
                    }
                };
            }
        }

        public static bool AddNews(INews news)
        {
            using (var context = new EntitiesDB())
            {
                if (context.News == null || context.News.Count() < 0)
                {
                    return false;
                }

                var save = new News()
                {
                    Header = news.Header,
                    HTMLText = news.Text,
                    Date = DateTime.Now,
                    
                    Language = context.Languages.First(l => l.Name == news.Language),
                    
                    Image = new Image()
                    {
	                    Name = news.Image.Alt,
						Path = news.Image.Src
					}
                };

                context.News.Add(save);
                context.SaveChanges();

                return true;
            }
        }

        public static bool UpdateNews(INews news)
        {
            using (var context = new EntitiesDB())
            {
                if (context.News == null || context.News.Any() == false)
                {
                    return false;
                }

                var selectNews = context.News.FirstOrDefault(a => a.Id == news.Id);

                if (selectNews == null)
                {
                    return false;
                }

                selectNews.Header = news.Header;
                selectNews.HTMLText = news.Text;
                selectNews.Date = DateTime.Now;
                selectNews.Language = context.Languages.First(l => l.Name == news.Language);


                context.News.AddOrUpdate(selectNews);
                context.SaveChanges();

                return true;
            }
        }

        public static bool RemoveNews(int newsId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.News == null || context.News.Any() == false)
                {
                    return false;
                }

                var selectNews = context.News.FirstOrDefault(a => a.Id == newsId);

                if (selectNews == null)
                {
                    return false;
                }

                context.News.Remove(selectNews);
                context.SaveChanges();
                
                return true;
            }
        }
    }
}
