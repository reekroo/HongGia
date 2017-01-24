using System.Web.Routing;

namespace HongGia.Core.Parameters.PartialElements
{
    public class SwitchLanguageParameters
    {
        public string Name { get; set; }
        public string Lang { get; set; }
        public RouteData RouteData { get; set; }
    }
}
