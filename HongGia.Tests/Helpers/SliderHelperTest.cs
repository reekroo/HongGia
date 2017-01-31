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
			var expectedResult = "";
			string actualResult = SliderHelper.Slider(htmlHelper, Images).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
			//        public static MvcHtmlString Slider(this HtmlHelper htmlHelper, IEnumerable<ImageParameters> parameters)
		}
	}
}
