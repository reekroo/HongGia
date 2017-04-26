using System.Web.Routing;

namespace HongGia.Core.Parameters
{
	public class MenuSectionParameters
	{
		public string QueryString { get; set; }
		public string LinkText { get; set; }
		public string ActionName { get; set; }
		public string ControllerName { get; set; }
		public RouteData RouteData { get; set; }
	}
}
