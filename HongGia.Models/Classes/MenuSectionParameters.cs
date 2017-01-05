using System.Web.Routing;

namespace HongGia.Models.Classes
{
    public class MenuSectionParameters
    {
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public RouteData RouteData { get; set; }
    }
}
