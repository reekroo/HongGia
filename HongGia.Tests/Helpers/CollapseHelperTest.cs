using System.Collections;
using System.Collections.Generic;
using HongGia.Core.Interfaces.Base;
using HongGia.Core.Models;
using HongGia.Core.Models.Base;
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
			var htmlHelper = Moks.Moks.CreateHtmlHelper<IPhoto>(true, true);

			string actualResult = CollapseHelper.CollapsiblePanel(htmlHelper, new Topic()
			{
				Header = "1111",
				HtmlText = "12412412515125251435"
			}
			).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");

		}

		[TestMethod]
		public void CollapsiblePanelEmptyHeaderArguments()
		{
			var expectedResult = "";
			var htmlHelper = Moks.Moks.CreateHtmlHelper<IPhoto>(true, true);

			string actualResult = CollapseHelper.CollapsiblePanel(htmlHelper, new Topic()
			{
				Header = "",
				HtmlText = ""
			}).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");

		}

		[TestMethod]
		public void CollapsiblePanelNullHtmlTextArguments()
		{
			var expectedResult =
			"<div class=\"panel-group\"><div class=\"panel panel-default\"><div class=\"panel-heading\"><h4 class=\"panel-title collapsable-header\" data-toggle=\"collapse\" href=\"#-444953022\"><a data-toggle=\"collapse\" href=\"#-444953022\">TestHeader</a><span class=\"pull-right panel-collapse--444953022\" data-toggle=\"collapse\" href=\"#-444953022\"><i class=\"glyphicon glyphicon-chevron-down\"></i></span></h4></div><div class=\"panel-collapse collapse\" id=\"-444953022\"><div class=\"panel-body\"></div></div></div><script>$(\"#-444953022\").on(\"hide.bs.collapse\", function() {$(\".panel-collapse--444953022\").find('i').removeClass(\"glyphicon-chevron-up\").addClass(\"glyphicon-chevron-down\");});$(\"#-444953022\").on(\"show.bs.collapse\", function() {$(\".panel-collapse--444953022\").find('i').removeClass(\"glyphicon-chevron-down\").addClass(\"glyphicon-chevron-up\");});</script></div>";
			var htmlHelper = Moks.Moks.CreateHtmlHelper<IPhoto>(true, true);

			string actualResult = CollapseHelper.CollapsiblePanel(htmlHelper, new Topic()
			{
				Header = "TestHeader",

			}).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");

		}

		[TestMethod]
		public void CollapsiblePanelNullArguments()
		{
			var expectedResult = "";
			var htmlHelper = Moks.Moks.CreateHtmlHelper<IPhoto>(true, true);

			string actualResult = CollapseHelper.CollapsiblePanel(htmlHelper, new Topic()).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");

		}

		[TestMethod]
		public void ColllapsiblePhotoPanel()
		{
			var expectedResult = "<div class=\"panel-group\"><div class=\"panel panel-default\"><div class=\"panel-heading\"><h4 class=\"panel-title collapsable-header\" data-toggle=\"collapse\" href=\"#-444953022\"><a data-toggle=\"collapse\" href=\"#-444953022\">TestHeader</a><span class=\"pull-right panel-collapse--444953022\" data-toggle=\"collapse\" href=\"#-444953022\"><i class=\"glyphicon glyphicon-chevron-down\"></i></span></h4></div><div class=\"panel-collapse collapse\" id=\"-444953022\"><div class=\"panel-body\"><div class=\"row row-margin\"><div class=\"col-md-3\"><div class=\"thumbnail\"><img alt=\"\" class=\"img-responsive\" src=\"\"></img></div></div><div class=\"col-md-3\"><div class=\"thumbnail\"><img alt=\"\" class=\"img-responsive\" src=\"\"></img></div></div></div><div class=\"row row-margin\"></div></div></div></div><script>$(\"#-444953022\").on(\"hide.bs.collapse\", function() {$(\".panel-collapse--444953022\").find('i').removeClass(\"glyphicon-chevron-up\").addClass(\"glyphicon-chevron-down\");});$(\"#-444953022\").on(\"show.bs.collapse\", function() {$(\".panel-collapse--444953022\").find('i').removeClass(\"glyphicon-chevron-down\").addClass(\"glyphicon-chevron-up\");});</script></div>";

			var photos = new List<Photo>();
			photos.Add(new Photo() { Id = 1 });
			photos.Add(new Photo() { Id = 2 });

			string header = "TestHeader";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<IPhoto>(true, true);

			string actualResult = CollapseHelper.ColllapsiblePhotoPanel(htmlHelper, photos, header).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ColllapsiblePhotoPanelEmptyHeaderArgument()
		{
			var expectedResult = "";

			var photos = new List<Photo>();
			photos.Add(new Photo() { Id = 1 });
			photos.Add(new Photo() { Id = 2 });

			string header = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<IPhoto>(true, true);

			string actualResult = CollapseHelper.ColllapsiblePhotoPanel(htmlHelper, photos, header).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");

		}

		[TestMethod]
		public void ColllapsiblePhotoPanelEmptyPhotoArgument()
		{
			var expectedResult = "";

			var photos = new List<Photo>();
			string header = "TestHeader";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<IPhoto>(true, true);

			string actualResult = CollapseHelper.ColllapsiblePhotoPanel(htmlHelper, photos, header).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");

		}

		[TestMethod]
		public void ColllapsiblePhotoPanelEightPhoto()
		{
			var expectedResult = "<div class=\"panel-group\"><div class=\"panel panel-default\"><div class=\"panel-heading\"><h4 class=\"panel-title collapsable-header\" data-toggle=\"collapse\" href=\"#-444953022\"><a data-toggle=\"collapse\" href=\"#-444953022\">TestHeader</a><span class=\"pull-right panel-collapse--444953022\" data-toggle=\"collapse\" href=\"#-444953022\"><i class=\"glyphicon glyphicon-chevron-down\"></i></span></h4></div><div class=\"panel-collapse collapse\" id=\"-444953022\"><div class=\"panel-body\"><div class=\"row row-margin\"><div class=\"col-md-3\"><div class=\"thumbnail\"><img alt=\"\" class=\"img-responsive\" src=\"\"></img></div></div><div class=\"col-md-3\"><div class=\"thumbnail\"><img alt=\"\" class=\"img-responsive\" src=\"\"></img></div></div><div class=\"col-md-3\"><div class=\"thumbnail\"><img alt=\"\" class=\"img-responsive\" src=\"\"></img></div></div><div class=\"col-md-3\"><div class=\"thumbnail\"><img alt=\"\" class=\"img-responsive\" src=\"\"></img></div></div></div><div class=\"row row-margin\"><div class=\"col-md-3\"><div class=\"thumbnail\"><img alt=\"\" class=\"img-responsive\" src=\"\"></img></div></div><div class=\"col-md-3\"><div class=\"thumbnail\"><img alt=\"\" class=\"img-responsive\" src=\"\"></img></div></div><div class=\"col-md-3\"><div class=\"thumbnail\"><img alt=\"\" class=\"img-responsive\" src=\"\"></img></div></div><div class=\"col-md-3\"><div class=\"thumbnail\"><a class=\"btn btn-default\" href=\"\">See More Photo</a></div></div></div></div></div></div><script>$(\"#-444953022\").on(\"hide.bs.collapse\", function() {$(\".panel-collapse--444953022\").find('i').removeClass(\"glyphicon-chevron-up\").addClass(\"glyphicon-chevron-down\");});$(\"#-444953022\").on(\"show.bs.collapse\", function() {$(\".panel-collapse--444953022\").find('i').removeClass(\"glyphicon-chevron-down\").addClass(\"glyphicon-chevron-up\");});</script></div>";

			var photos = new List<Photo>();
			photos.Add(new Photo() { Id = 1 });
			photos.Add(new Photo() { Id = 2 });
			photos.Add(new Photo() { Id = 3 });
			photos.Add(new Photo() { Id = 4 });
			photos.Add(new Photo() { Id = 5 });
			photos.Add(new Photo() { Id = 6 });
			photos.Add(new Photo() { Id = 7 });
			photos.Add(new Photo() { Id = 8 });

			string header = "TestHeader";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<IPhoto>(true, true);

			string actualResult = CollapseHelper.ColllapsiblePhotoPanel(htmlHelper, photos, header).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");

		}
	}
}
