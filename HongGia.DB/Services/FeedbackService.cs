using System.Collections.Generic;
using System.Linq;

using HongGia.Core.Models.Base;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class FeedbackService
    {
        public static IEnumerable<FeedBack> GetFeedbasks()
        {
            using (var context = new EntitiesDB())
            {
                var feedbacks = context.Feedbacks.Select(f => new HongGia.Core.Models.Base.FeedBack()
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

        public static IEnumerable<FeedBack> GetFeedbasksByLanguage(string lang)
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

        public static void SetFeedback(FeedBack feedback)
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
