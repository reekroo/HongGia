using System.Collections.Generic;
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
        public static IFeedBackView GetFeedbasks()
        {
            using (var context = new EntitiesDB())
            {
                if (context.Feedbacks.Count() == 0)
                {
                    return new FeedBackView()
                    {
                        FeedBacks = new List<IFeedBack>()
                    };
                }

                var feedbacks = context.Feedbacks.Select(f => new FeedBack()
                {
                    Name = f.AuthorName,
                    Email = f.AuthorMail,
                    Id = f.Id,
                    Text = f.Text,
                    Language = f.Language.Name,
                    Date = f.Date.GetValueOrDefault()
                }).ToList();

                return new FeedBackView()
                {
                    FeedBacks = feedbacks
                };
            }
        }

        public static IEnumerable<IFeedBack> GetFeedbasksByLanguage(string lang)
        {
            using (var context = new EntitiesDB())
            {
                var feedbacks = context.Feedbacks.Where(l => l.Language.Name.ToLower() == "lang").Select(f => new FeedBack()
                {
                    Name = f.AuthorName,
                    Email = f.AuthorMail,
                    Id = f.Id,
                    Text = f.Text,
                    Language = f.Language.Name,
                    Date = f.Date.GetValueOrDefault()
                });

                return feedbacks;
            }
        }

        public static void SetFeedback(IFeedBack feedback)
        {
            using (var context = new EntitiesDB())
            {
                var save = new Feedback()
                {
                    Id = feedback.Id,
                    Text = feedback.Text,
                    AuthorName = feedback.Name,
                    AuthorMail = feedback.Email,
                    Date = feedback.Date,
                    Language = context.Languages.FirstOrDefault(l => l.Name == feedback.Language)
                };

                context.Feedbacks.Add(save);
                context.SaveChanges();
            }
        }
    }
}
