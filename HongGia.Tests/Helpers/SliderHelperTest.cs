using System;
using System.Collections.Generic;
using HongGia.Core.Models;
using HongGia.Core.Parameters.Base;
using HongGia.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HongGia.Tests.Helpers
{
	[TestClass]
	public class SliderHelperTest
	{
		[TestMethod]
		public void SliderTest()
		{
			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);

			var Images= new List<ImageParameters>();
			Images.Add(new ImageParameters()
			{
				Src = "TestHeader",
				Alt = "12412412515125251435"

			});
			Images.Add(new ImageParameters()
			{

				Src = "TestHeader",
				Alt = "12412412515125251435"

			});
			var expectedResult = "<div class=\"carousel slide\" data-ride=\"carousel\" id=\"carousel-example-generic\"><ol class=\"carousel-indicators\"><li class=\"active\" data-slide-to=\"0\" data-target=\"#carousel-example-generic\"></li><li data-slide-to=\"1\" data-target=\"#carousel-example-generic\"></li></ol><div class=\"carousel-inner\" role=\"listbox\"><div class=\"active item\"><img alt=\"12412412515125251435\" src=\"TestHeader\"></img></div><div class=\"item\"><img alt=\"12412412515125251435\" src=\"TestHeader\"></img></div></div><a class=\"left carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"prev\"><span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\"></span><span class=\"sr-only\">Previous</span></a><a class=\"right carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"next\"><span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span><span class=\"sr-only\">Next</span></a></div>";

			string actualResult = SliderHelper.Slider(htmlHelper, Images).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void SliderTestEmptyImages()
		{
			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);

			var Images = new List<ImageParameters>();
			
			var expectedResult = "";

			string actualResult = SliderHelper.Slider(htmlHelper, Images).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}
	}
}
