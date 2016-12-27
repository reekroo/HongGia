using System.Globalization;
using System.Threading;

namespace HongGia.Controllers
{
    public class DefaultController : BaseController
    {
        public string CurrentLangCode { get; protected set; }
        
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }

            if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                CurrentLangCode = requestContext.RouteData.Values["lang"] as string;

                if (CurrentLangCode != null)
                {
                    var ci = new CultureInfo(CurrentLangCode);

                    Thread.CurrentThread.CurrentUICulture = ci;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
                }
            }
            base.Initialize(requestContext);
        }
    }
}