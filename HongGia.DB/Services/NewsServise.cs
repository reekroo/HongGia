using System.Collections.Generic;
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
                    Date = n.Date.GetValueOrDefault(),

                    Language = n.Language.Name,

                    Image = new HongGia.Core.Models.Base.Image()
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

                var news = new List<Core.Models.Base.News>();
                
                if (context.News.Count() < count - 1)
                {
                    news = context.News.OrderBy(x => x.Date).Select(n => new Core.Models.Base.News()
                            {
                                Id = n.Id,
                                Header = n.Header,
                                Text = n.HTMLText,
                                Date = n.Date.GetValueOrDefault(),

                                Language = n.Language.Name,

                                Image = new HongGia.Core.Models.Base.Image()
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

                            Image = new HongGia.Core.Models.Base.Image()
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
                    Date = news.Date.GetValueOrDefault(),

                    Language = news.Language.Name,

                    Image = new HongGia.Core.Models.Base.Image()
                    {
                        Src = news.Image.Path,
                        Alt = news.Image.Name
                    }
                };
            }
        }
    }
}
