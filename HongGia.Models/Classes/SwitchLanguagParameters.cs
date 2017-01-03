using System.Web.Routing;

namespace HongGia.Models.Classes
{
    public class SwitchLanguagParameters
    {
        public string Name { get; set; }
        public string Lang { get; set; }
        public RouteData RouteData { get; set; }
    }
}
