using System.ComponentModel.DataAnnotations;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.App_LocalResources;

namespace HongGia.Core.Models.Base
{
	public class Email : IEmail
    {
        [Display(Name ="YourName", ResourceType = typeof(GlobalRes))]
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

        public string Mail { get; set; }

        [Display(Name = "YourSubject", ResourceType = typeof(GlobalRes))]
        [Required(ErrorMessageResourceName = "ErrorSubject", ErrorMessageResourceType = typeof(GlobalRes))]
        [StringLength(50, MinimumLength = 5, ErrorMessageResourceName = "ErrorSubjectLength", ErrorMessageResourceType = typeof(GlobalRes))]

        public string Subject { get; set; }

        [Display(Name = "YourMessage", ResourceType = typeof(GlobalRes))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(GlobalRes))]
        [StringLength(5000, MinimumLength = 20, ErrorMessageResourceName = "ErrorMessageLength", ErrorMessageResourceType = typeof(GlobalRes))]

        public string Message { get; set; }
    }
}
