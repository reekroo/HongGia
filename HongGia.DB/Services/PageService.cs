using System;
using System.Collections.Generic;
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

                var a = content.Topics.Select(t => new HongGia.Core.Models.Base.Topic()
                {
                    Id = t.Id,
                    Header = t.Header,
                    Type = t.TopicType.Name,
                    Position = t.Position ?? 0,
                    HtmlText = t.HTMLText,
                    Image = null
                }).ToList();

                var result = new BasePageView()
                {
                    Id = content.Id,
                    Header = content.Header,
                    Images = content.Images.Select(i => new HongGia.Core.Models.Base.Image()
                    {
                        Src = i.Name,
                        Alt = i.Path
                    }).ToList(),
                    Files = content.Files.Select(f => new HongGia.Core.Models.Base.File()
                    {
                        Name = f.Name,
                        Path = f.Path
                    }).ToList(),
                    Topics = content.Topics.Select(t => new HongGia.Core.Models.Base.Topic()
                    {
                        Id = t.Id,
                        Header = t.Header,
                        Type = t.TopicType.Name,
                        Position = t.Position ?? 0,
                        HtmlText = t.HTMLText,
                        Image = null
                    }).ToList()
                };

                return result;
            }
        }

        public static bool AddPageByName(string pageName, string lang, IBasePage page)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Pages.Any(x => x.Name == pageName) == false ||
                    context.Languages.Any(x => x.Name == lang) == false)
                {
                    return false;
                }

                var contect = new PageContent()
                {
                    Header = page.Header,
                    Date = DateTime.Now,
                    Files = null,
                    Images = null,
                    Topics = null,

                    Language = context.Languages.FirstOrDefault(l => l.Name == lang),
                    Page = context.Pages.FirstOrDefault(p => p.Name == pageName)
                };

                if (page.Images != null)
                {
                    contect.Images = new List<Image>();

                    foreach (var image in page.Images)
                    {
                        ImageService.AddImage(image);
                        contect.Images.Add(context.Images.Last());
                    }
                }

                if (page.Files != null)
                {
                    contect.Files = new List<File>();

                    foreach (var file in page.Files)
                    {
                       // FileService.AddFile(file);
                        contect.Files.Add(context.Files.Last());
                    }
                }

                if (page.Topics != null)
                {
                    contect.Topics = new List<Topic>();

                    foreach (var topic in page.Topics)
                    {
                        TopicService.AddTopic(topic);
                        contect.Topics.Add(context.Topics.Last());
                    }
                }

                context.PageContents.Add(contect);
                context.SaveChanges();

                return true;
            }
        }

        public static bool UpdatePageByName(string pageName, string lang, IBasePage page)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Pages.Any(x => x.Name == pageName) == false ||
                    context.Languages.Any(x => x.Name == lang) == false)
                {
                    return false;
                }

                var content = context.PageContents.FirstOrDefault(x => x.Id == page.Id);

                if (content == null)
                { 
                    return false;
                }

                content.Header = page.Header;
                content.Date = DateTime.Now;

                //Images

                if (content.Images != null && page.Images != null)
                {
                    foreach (var image in content.Images)
                    {
                        ImageService.RemoveImage(image.Id);
                    }

                    content.Images = new List<Image>();

                    foreach (var image in page.Images)
                    {
                        ImageService.AddImage(image);
                        content.Images.Add(context.Images.Last());
                    }
                }
                else if (content.Images != null && page.Images == null)
                {
                    foreach (var image in content.Images)
                    {
                        ImageService.RemoveImage(image.Id);
                    }

                    content.Images = null;
                }
                else if (content.Images == null && page.Images != null)
                {
                    content.Files = new List<File>();

                    foreach (var file in page.Files)
                    {
                        //FileService.AddFile(file);
                        content.Files.Add(context.Files.Last());
                    }
                }

                //Files

                if (content.Files != null && page.Files != null)
                {
                    foreach (var files in content.Files)
                    {
                        FileService.RemoveFile(files.Id);
                    }

                    content.Files = new List<File>();

                    foreach (var file in page.Files)
                    {
                        //FileService.AddFile(file);
                        content.Files.Add(context.Files.Last());
                    }
                }
                else if (content.Files != null && page.Files == null)
                {
                    foreach (var file in content.Files)
                    {
                        FileService.RemoveFile(file.Id);
                    }

                    content.Files = null;
                }
                else if (content.Files == null && page.Files != null)
                {
                    content.Files = new List<File>();

                    foreach (var file in page.Files)
                    {
                        //FileService.AddFile(file);
                        content.Files.Add(context.Files.Last());
                    }
                }

                //Topics

                if (content.Topics != null && page.Topics != null)
                {
                    foreach (var topic in page.Topics)
                    {
                        //TopicService.UpdateTopic(topic);
                    }
                }
                else if (content.Topics != null && page.Topics == null)
                {
                    foreach (var topic in content.Topics)
                    {
                        //TopicService.RemoveTopic(topic.Id);
                    }

                    content.Topics = null;
                }
                else if (content.Topics == null && page.Topics != null)
                {
                    content.Topics = new List<Topic>();

                    foreach (var topic in page.Topics)
                    {
                        TopicService.AddTopic(topic);
                        content.Topics.Add(context.Topics.Last());
                    }
                }

                context.PageContents.Add(content);
                context.SaveChanges();

                return true;
            }
        }

        public static bool RemovePageByName(string pageName, string lang, int pageId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Pages.Any(x => x.Name == pageName) == false ||
                    context.Languages.Any(x => x.Name == lang) == false)
                {
                    return false;
                }

                var content = context.PageContents.FirstOrDefault(x => x.Id == pageId);

                if (content == null)
                {
                    return false;
                }
                
                foreach (var image in content.Images)
                {
                    ImageService.RemoveImage(image.Id);
                }

                foreach (var file in content.Files)
                {
                    FileService.RemoveFile(file.Id);
                }

                foreach (var topic in content.Topics)
                {
                    //TopicService.RemoveTopic(topic.Id);
                }

                context.PageContents.Remove(content);
                context.SaveChanges();

                return true;
            }
        }
    }
}
