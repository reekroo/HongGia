using System;
using HongGia.Core.Models;
using HongGia.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HongGia.Tests.Helpers
{
	[TestClass]
	public class PagingHelperTest
	{
		[TestMethod]
		public void PageLinks()
		{
			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			int CurrentPage = 1;
			int itemCount = 1;
			int pageSize = 10;
			var expectedResult = "<ul class=\"pagination \"><li><a href=\"Page0\">«</a></li>\r\n<li><a href=\"Page0\">1</a></li>\r\n<li><a href=\"Page2\">»</a></li>\r\n</ul>";

			Func<int, string> pageUrl = i => "Page" + i;
			string actualResult = PagingHelper.PageLinks(htmlHelper, CurrentPage, itemCount, pageSize, pageUrl).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void PageLinksCurrentPage0()
		{
			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			int CurrentPage = 0;
			int itemCount = 1;
			int pageSize = 10;

			var expectedResult = "<ul class=\"pagination \"><li class=\"active\"><a href=\"#\">«</a></li>\r\n<li class=\"active\"><a href=\"#\">1</a></li>\r\n<li class=\"active\"><a href=\"#\">»</a></li>\r\n</ul>";

			Func<int, string> pageUrl = i => "Page" + i;
			string actualResult = PagingHelper.PageLinks(htmlHelper, CurrentPage, itemCount, pageSize, pageUrl).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void PageLinksPageSize()
		{
			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			int CurrentPage = 0;
			int itemCount = 10;
			int pageSize = 3;

			var expectedResult = "<ul class=\"pagination \"><li class=\"active\"><a href=\"#\">«</a></li>\r\n<li class=\"active\"><a href=\"#\">1</a></li>\r\n<li><a href=\"Page1\">2</a></li>\r\n<li><a href=\"Page2\">3</a></li>\r\n<li><a href=\"Page3\">4</a></li>\r\n<li><a href=\"Page1\">»</a></li>\r\n</ul>";

			Func<int, string> pageUrl = i => "Page" + i;
			string actualResult = PagingHelper.PageLinks(htmlHelper, CurrentPage, itemCount, pageSize, pageUrl).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void PageLinksitemCount0()
		{
			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			int CurrentPage = 0;
			int itemCount = 0;
			int pageSize = 10;

			var expectedResult = "<ul class=\"pagination \"><li class=\"active\"><a href=\"#\">«</a></li>\r\n<li><a href=\"Page1\">»</a></li>\r\n</ul>";

			Func<int, string> pageUrl = i => "Page" + i;
			string actualResult = PagingHelper.PageLinks(htmlHelper, CurrentPage, itemCount, pageSize, pageUrl).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void PageLinkspageSize0()
		{
			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			int CurrentPage = 0;
			int itemCount = 10;
			int pageSize = 0;

			var expectedResult = "<ul class=\"pagination \"><li class=\"active\"><a href=\"#\">«</a></li>\r\n<li><a href=\"Page1\">»</a></li>\r\n</ul>";

			Func<int, string> pageUrl = i => "Page" + i;
			string actualResult = PagingHelper.PageLinks(htmlHelper, CurrentPage, itemCount, pageSize, pageUrl).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}
	}
}
