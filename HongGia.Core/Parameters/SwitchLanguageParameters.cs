using System.Web.Routing;

namespace HongGia.Core.Parameters
{
    public class SwitchLanguageParameters
    {
        public string Name { get; set; }
        public string Lang { get; set; }
        public RouteData RouteData { get; set; }
    }
}
