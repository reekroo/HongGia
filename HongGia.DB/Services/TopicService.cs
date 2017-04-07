using System;
using System.Data.Entity.Migrations;
using System.Linq;

using HongGia.Core.Interfaces.Base;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class TopicService
    {
        public static bool AddTopic(ITopic topic)
        {
            using (var context = new EntitiesDB())
            {
                var save = new Topic()
                {
                    Header = topic.Header,
                    HTMLText = topic.HtmlText,
                    Position = topic.Position,
                    Date = DateTime.Now
                };

                if (topic.Type != null)
                {
                    var type = context.TopicTypes.FirstOrDefault(t => t.Name == topic.Type);

                    save.TopicType = type;
                }

                context.Topics.Add(save);
                context.SaveChanges();

                return true;
            }
        }

        public static bool AddTopic(ITopic topic, int contentId)
        {
            using (var context = new EntitiesDB())
            {
                var content = context.PageContents.FirstOrDefault(c => c.Id == contentId);
                
                var save = new Topic()
                {
                    Header = topic.Header,
                    HTMLText = topic.HtmlText,
                    Position = topic.Position,
                    Date = DateTime.Now,
                    PageContent = content
                };

                if (topic.Type != null)
                {
                    var type = context.TopicTypes.FirstOrDefault(t => t.Name == topic.Type);

                    save.TopicType = type;
                }

                context.Topics.Add(save);
                context.SaveChanges();

                return true;
            }
        }

        public static bool UpdateTopic(ITopic topic)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Topics.Any())
                {
                    return false;
                }

                var selectTopic = context.Topics.FirstOrDefault();

                if (selectTopic == null)
                {
                    return false;
                }
                
                var type = context.TopicTypes.FirstOrDefault(t => t.Name == topic.Type);

                selectTopic.Header = topic.Header;
                selectTopic.HTMLText = topic.HtmlText;
                selectTopic.Position = topic.Position;
                selectTopic.TopicType = type;
                selectTopic.Date = DateTime.Now;

                context.Topics.AddOrUpdate(selectTopic);
                context.SaveChanges();

                return true;
            }
        }

        public static bool RemoveTopic(int fileId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Topics.Any())
                {
                    return false;
                }

                var selectTopic = context.Topics.FirstOrDefault();

                if (selectTopic == null)
                {
                    return false;
                }
                
                context.Topics.Remove(selectTopic);
                context.SaveChanges();

                return true;
            }
        }
    }
}
