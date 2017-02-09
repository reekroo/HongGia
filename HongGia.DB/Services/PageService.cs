using System.Linq;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class PageService
    {
        public static IBasePage GetPageByName(string pageName, string lang)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Pages.Any(x => x.Name == pageName) == false)
                {
                    return null;
                }

                var pageContents = context.Pages.FirstOrDefault(x => x.Name == pageName).PageContents.ToList();

                var content = pageContents.FirstOrDefault(x => x.Language.Name == lang);

                if (content == null)
                {
                    return null;
                }

                var result = new BasePageView()
                {
                    Id = content.Id,
                    Header = content.Header,
                    Images = content.Images.Select(i => new HongGia.Core.Models.Base.Image()
                    {
                        Src = i.Name,
                        Alt = i.Path
                    }),
                    Files = content.Images.Select(f => new HongGia.Core.Models.Base.File()
                    {
                        Name = f.Name,
                        Path = f.Path
                    }),
                    Topics = content.Topics.Select(t => new HongGia.Core.Models.Base.Topic()
                    {
                        Id = t.Id,
                        Header = t.Header,
                        Type = t.TopicType.Name,
                        Position = t.Position ?? 0,
                        HtmlText = t.HTMLText,
                        Image = null
                    })
                };

                return result;
            }
        }
    }
}
