using System;
using System.Collections.Generic;
using HongGia.Core.Models;
using HongGia.Helpers;
using HongGia.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HongGia.Tests.Helpers
{
	[TestClass]
	public class ListGroupHelperTest
	{
		[TestMethod]
		public void ListGroupHelperGroup()
		{
			var expectedResult = "<a class=\"list-group-item list-group-item-action\" href=\"/en/News/News?id=1\"><h4 class=\"list-group-item-heading text\">TestHeader</h4><p class=\"list-group-item-text\">12412412515125251435</p><p class=\"list-group-item-text text-right\">1/24/2017</p></a>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new NewsViewModel()
			{
				Id = 1,
				Header = "TestHeader",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.Now
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyHeader()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new NewsViewModel()
			{
				Id = 1,
				Header = "",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.Now
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyText()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new NewsViewModel()
			{
				Id = 1,
				Header = "TestHeader",
				Text = "",
				Language = "en",
				Date = DateTime.Now
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyLanguage()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new NewsViewModel()
			{
				Id = 1,
				Header = "TestHeader",
				Text = "12412412515125251435",
				Language = "",
				Date = DateTime.Now
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyData()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new NewsViewModel()
			{
				Id = 1,
				Header = "",
				Text = "12412412515125251435",
				Language = "en"
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyId()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new NewsViewModel()
			{
				Id = 1,
				Header = "",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.Now
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyNews()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new NewsViewModel();

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperListGroup()
		{
			var expectedResult = "<div class=\"thumbnail\"><div class=\"list-group margin-bottom-zero\"><a class=\"list-group-item list-group-item-action\" href=\"/en/News/News?id=1\"><h4 class=\"list-group-item-heading text\">TestHeader</h4><p class=\"list-group-item-text\">12412412515125251435</p><p class=\"list-group-item-text text-right\">1/24/2017</p></a><a class=\"list-group-item list-group-item-action\" href=\"/en/News/News?id=2\"><h4 class=\"list-group-item-heading text\">TestHeader</h4><p class=\"list-group-item-text\">12412412515125251435</p><p class=\"list-group-item-text text-right\">1/24/2017</p></a></div></div>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			
			var news = new List<NewsViewModel>();
			news.Add(new NewsViewModel()
			{
				Id = 1,
				Header = "TestHeader",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.Now
			});
			news.Add(new NewsViewModel()
			{
				Id = 2,
				Header = "TestHeader",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.Now
			});

			string actualResult = ListGroupHelper.ListGroup(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperListGroupEmptyNews()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);

			var news = new List<NewsViewModel>();
			
			string actualResult = ListGroupHelper.ListGroup(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

	}
}
