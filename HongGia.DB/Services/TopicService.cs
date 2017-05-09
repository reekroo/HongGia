using System;
using System.Data.Entity.Migrations;
using System.Linq;

using HongGia.Core.Interfaces.Base;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
	public class TopicService
	{
		public static bool AddNullable(int basePageContentId)
		{
			using (var context = new EntitiesDB())
			{
				var pageContent = context.PageContents.FirstOrDefault(x => x.Id == basePageContentId);

				if (pageContent == null)
				{
					return false;
				}

				var save = new Topic()
				{
					Date = DateTime.Now,
					PageContent = pageContent
				};

				context.Topics.Add(save);
				context.SaveChanges();

				return true;
			}
		}

		public static bool Remove(int topicId)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Topics.Any() == false)
				{
					return false;
				}

				var selectTopic = context.Topics.FirstOrDefault(x => x.Id == topicId);

				if (selectTopic == null)
				{
					return false;
				}

				context.Topics.Remove(selectTopic);
				context.SaveChanges();

				return true;
			}
		}

		public static bool Update(ITopic topic)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Topics.Any() == false)
				{
					return false;
				}

				var selectTopic = context.Topics.FirstOrDefault(x => x.Id == topic.Id);

				if (selectTopic == null)
				{
					return false;
				}

				var type = context.TopicTypes.FirstOrDefault(t => t.Name == topic.Type);

				selectTopic.Header = topic.Header;
				selectTopic.HTMLText = topic.HtmlText;
				selectTopic.Position = topic.Position;
				selectTopic.TopicType = type;
				selectTopic.UpdateDate = DateTime.Now;

				context.Topics.AddOrUpdate(selectTopic);
				context.SaveChanges();

				return true;
			}
		}
	}
}
