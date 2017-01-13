using System.Web.Mvc;

namespace HongGia.Core.Controllers
{
    public class BaseController : Controller
    {
        protected static string LoginPage = "~/Login";
        protected static string ErrorPage = "~/Error";
        protected static string NotFoundPage = "~/NotFoundPage";
        
        public static string HostName = string.Empty;

        public RedirectResult RedirectToNotFoundPage
        {
            get
            {
                return Redirect(NotFoundPage);
            }
        }

        public RedirectResult RedirectToLoginPage
        {
            get
            {
                return Redirect(LoginPage);
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }

            base.Initialize(requestContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            filterContext.Result = Redirect(ErrorPage);
        }
    }
}