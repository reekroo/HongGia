using System.Web.Mvc;
using HongGia.Core.Models;
using HongGia.Core.Parameters;
using HongGia.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HongGia.Tests.Helpers
{
	[TestClass]
	public class CollapseHelperTest
	{
		[TestMethod]
		public void CollapsiblePanel()
		{
			var expectedResult = "<div class=\"panel-group\"><div class=\"panel panel-default\"><div class=\"panel-heading\"><h4 class=\"panel-title collapsable-header\" data-toggle=\"collapse\" href=\"#406113220\"><a data-toggle=\"collapse\" href=\"#406113220\">1111</a><span class=\"pull-right panel-collapse-406113220\" data-toggle=\"collapse\" href=\"#406113220\"><i class=\"glyphicon glyphicon-chevron-down\"></i></span></h4></div><div class=\"panel-collapse collapse\" id=\"406113220\"><div class=\"panel-body\">12412412515125251435</div></div></div><script>$(\"#406113220\").on(\"hide.bs.collapse\", function() {$(\".panel-collapse-406113220\").find('i').removeClass(\"glyphicon-chevron-up\").addClass(\"glyphicon-chevron-down\");});$(\"#406113220\").on(\"show.bs.collapse\", function() {$(\".panel-collapse-406113220\").find('i').removeClass(\"glyphicon-chevron-down\").addClass(\"glyphicon-chevron-up\");});</script></div>";
			var htmlHelper = Moks.Moks.CreateHtmlHelper<Photo> (true, true);

			string actualResult = CollapseHelper.CollapsiblePanel(htmlHelper, new CollapsiblePanelParameters()
			{
				Header = "1111",
				Text = "12412412515125251435"
			}).ToString();
			
			Assert.AreEqual(expectedResult, actualResult,  "Correct");

		}
}
}
