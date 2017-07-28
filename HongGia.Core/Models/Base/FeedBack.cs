using System;
using System.ComponentModel.DataAnnotations;


using HongGia.Core.Interfaces.Base;
using HongGia.Core.App_LocalResources;

namespace HongGia.Core.Models.Base
{
    public class FeedBack : IFeedBack
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }

        [Display(Name = "YourName", ResourceType = typeof(GlobalRes))]
        [Required(ErrorMessageResourceName = "ErrorName", ErrorMessageResourceType = typeof(GlobalRes))]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceName = "ErrorNameLength", ErrorMessageResourceType = typeof(GlobalRes))]

        public string Name { get; set; }

        [Display(Name = "YourEmail", ResourceType = typeof(GlobalRes))]
        [Required(ErrorMessageResourceName = "ErrorEmail", ErrorMessageResourceType = typeof(GlobalRes))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                ErrorMessageResourceName = "ErrorEmailValid", ErrorMessageResourceType = typeof(GlobalRes))]
        [EmailAddress]

        public string Email { get; set; }

        [Display(Name = "YourFeedback", ResourceType = typeof(GlobalRes))]
        [Required(ErrorMessageResourceName = "ErrorFeedback", ErrorMessageResourceType = typeof(GlobalRes))]
        [StringLength(2000, MinimumLength = 20, ErrorMessageResourceName = "ErrorFeedbackLength", ErrorMessageResourceType = typeof(GlobalRes))]

        public string Text { get; set; }
    }
}
