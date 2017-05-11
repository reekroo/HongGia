using System;
using System.Linq;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Base;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
	public class FeedbackService
	{
		public static IFeedBacksView GetFeedbasks()
		{
			using (var context = new EntitiesDB())
			{
				if (context.Feedbacks == null || 
                    context.Feedbacks.Any() == false)
				{
					return null;
				}

				var feedbacks = context.Feedbacks.Select(f => new FeedBack()
				{
					Name = f.AuthorName,
					Email = f.AuthorMail,
					Id = f.Id,
					Text = f.Text,
					Language = f.Language.Name,
					Date = f.Date.Value
				}).ToList();

				return new FeedBacksView()
				{
					FeedBacks = feedbacks
				};
			}
		}

		public static IFeedBacksView GetFeedbasks(string lang)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Feedbacks == null ||
					context.Languages == null ||
					context.Languages.Any(x => x.Name.ToLower().Contains(lang)) == false ||
					context.Feedbacks.Any(x => x.Language.Name.ToLower() == lang) == false)
				{
					return null;
				}

				var feedbacks = context.Feedbacks.Where(l => l.Language.Name.ToLower() == lang).Select(f => new FeedBack()
				{
					Name = f.AuthorName,
					Email = f.AuthorMail,
					Id = f.Id,
					Text = f.Text,
					Language = f.Language.Name,
					Date = f.Date.Value
				}).ToList();

				return new FeedBacksView()
				{
					FeedBacks = feedbacks
				};
			}
		}

		public static bool SetFeedback(IFeedBack feedback)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Feedbacks == null || 
                    context.Feedbacks.Count() < 0 ||
                    context.Languages.Any(x => x.Name.ToLower().Contains(feedback.Language)) == false)
				{
					return false;
				}

				var save = new Feedback()
				{
					Text = feedback.Text,
					AuthorName = feedback.Name,
					AuthorMail = feedback.Email,

					Date = DateTime.Now,
					Language = context.Languages.FirstOrDefault(l => l.Name == feedback.Language)
				};

				context.Feedbacks.Add(save);
				context.SaveChanges();

				return true;
			}
		}

		public static bool RemoveFeedback(int feedbackId)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Feedbacks.Any() == false)
				{
					return false;
				}

				var selectFeedback = context.Feedbacks.FirstOrDefault(f => f.Id == feedbackId);

				if (selectFeedback == null)
				{
					return false;
				}

				context.Feedbacks.Remove(selectFeedback);
				context.SaveChanges();

				return true;
			}
		}
	}
}
