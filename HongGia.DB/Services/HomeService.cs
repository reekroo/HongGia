using System.Linq;

using HongGia.Core.Constants;
using HongGia.Core.Models.Views;
using HongGia.Core.Parameters.PartialElements;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class HomeService
    {
        public static HomeView GetHome(string lang)
        {
            using (var context = new EntitiesDB())
            {
                var pageContent = new PageContent();

                var pages = context.Pages.Where(p => p.Name.ToLower() == "home").ToList();

                foreach (var page in pages)
                {
                    foreach (var content in page.PageContents)
                    {
                        if (content.Language.Name == lang)
                        {
                            pageContent = content;
                        }
                    }
                }
                
                var home = new HomeView()
                {
                    TopNews = NewsService.GetTopNews(PageConstants.PageIndexNewsSize),
                    SliderImages = pageContent.Images.Select(i => new SliderParameters()
                    {
                        Alt = i.Name,
                        Src = i.Path
                    })
            };

                return home;
            }
        }
    }
}
