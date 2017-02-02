using System;
using System.Collections.Generic;
using HongGia.Core.Models;
using HongGia.Core.Models.Base;
using HongGia.Core.Parameters.Base;
using HongGia.Helpers;
using HongGia.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HongGia.Tests.Helpers
{
	[TestClass]
	public class ListGroupHelperTest
	{
		#region News
		[TestMethod]
		public void ListGroupHelperGroup()
		{
			var expectedResult = "<a class=\"list-group-item list-group-item-action\" href=\"/en/News/News?id=1\"><h4 class=\"list-group-item-heading text\">TestHeader</h4><p class=\"list-group-item-text\">12412412515125251435</p><p class=\"list-group-item-text text-right\">1/1/0001</p></a>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new News()
			{
				Id = 1,
				Header = "TestHeader",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyHeader()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new News()
			{
				Id = 1,
				Header = "",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyText()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new News()
			{
				Id = 1,
				Header = "TestHeader",
				Text = "",
				Language = "en",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyLanguage()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new News()
			{
				Id = 1,
				Header = "TestHeader",
				Text = "12412412515125251435",
				Language = "",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyData()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new News()
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
			var news = new News()
			{
				Id = 1,
				Header = "",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperGroupEmptyNews()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);
			var news = new News();

			string actualResult = ListGroupHelper.Group(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperListGroup()
		{
			var expectedResult = "<div class=\"thumbnail\"><div class=\"list-group margin-bottom-zero\"><a class=\"list-group-item list-group-item-action\" href=\"/en/News/News?id=1\"><h4 class=\"list-group-item-heading text\">TestHeader</h4><p class=\"list-group-item-text\">12412412515125251435</p><p class=\"list-group-item-text text-right\">1/1/0001</p></a><a class=\"list-group-item list-group-item-action\" href=\"/en/News/News?id=2\"><h4 class=\"list-group-item-heading text\">TestHeader</h4><p class=\"list-group-item-text\">12412412515125251435</p><p class=\"list-group-item-text text-right\">1/1/0001</p></a></div></div>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);

			var news = new List<News>();
			news.Add(new News()
			{
				Id = 1,
				Header = "TestHeader",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue
			});
			news.Add(new News()
			{
				Id = 2,
				Header = "TestHeader",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue
			});

			string actualResult = ListGroupHelper.ListGroup(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperListGroupEmptyNews()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<News>(true, true);

			var news = new List<News>();

			string actualResult = ListGroupHelper.ListGroup(htmlHelper, news).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}
		#endregion
		#region FeedBacks
		[TestMethod]
		public void ListGroupHelperFeedBacksGroup()
		{
			var expectedResult = "<div class=\"feetback\"><p class=\"text-justify\">12412412515125251435</p><p class=\"text-right\"><i class=\"glyphicon glyphicon-user\"></i> TestHeader / <i class=\"glyphicon glyphicon-calendar\"></i> 1/1/0001</p></div>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FeedBack>(true, true);
			var FeedBacks = new FeedBack()
			{
				Id = 1,
				Name = "TestHeader",
				Email = "email",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, FeedBacks).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperFeedBacksGroupEmptyName()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FeedBack>(true, true);
			var FeedBacks = new FeedBack()
			{
				Id = 1,
				Name = "",
				Email = "email",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, FeedBacks).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}
		[TestMethod]
		public void ListGroupHelperFeedBacksGroupEmptyEmail()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FeedBack>(true, true);
			var FeedBacks = new FeedBack()
			{
				Id = 1,
				Name = "TestHeader",
				Email = "",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, FeedBacks).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperFeedBacksGroupEmptyText()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FeedBack>(true, true);
			var FeedBacks = new FeedBack()
			{
				Id = 1,
				Name = "TestHeader",
				Email = "email",
				Text = "",
				Language = "en",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, FeedBacks).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}
		[TestMethod]
		public void ListGroupHelperFeedBacksGroupEmptyLanguage()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FeedBack>(true, true);
			var FeedBacks = new FeedBack()
			{
				Id = 1,
				Name = "TestHeader",
				Email = "email",
				Text = "12412412515125251435",
				Language = "",
				Date = DateTime.MinValue
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, FeedBacks).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		//[TestMethod]
		//public void ListGroupHelperFeedBacksGroupNullData()
		//{
		//	var expectedResult = "";

		//	var htmlHelper = Moks.Moks.CreateHtmlHelper<FeedBack>(true, true);
		//	var FeedBacks = new FeedBack()
		//	{
		//		Id = 1,
		//		Name = "TestHeader",
		//		Email = "email",
		//		Text = "12412412515125251435",
		//		Language = "en"
		//	};

		//	string actualResult = ListGroupHelper.Group(htmlHelper, FeedBacks).ToString();
		//	Assert.AreEqual(expectedResult, actualResult, "Correct");
		//}

		[TestMethod]
		public void ListGroupHelperFeedBacksListGroup()
		{
			var expectedResult = "<div><div class=\"feetback\"><p class=\"text-justify\">12412412515125251435</p><p class=\"text-right\"><i class=\"glyphicon glyphicon-user\"></i> TestHeader / <i class=\"glyphicon glyphicon-calendar\"></i> 1/1/0001</p></div><div class=\"feetback\"><p class=\"text-justify\">12412412515125251435</p><p class=\"text-right\"><i class=\"glyphicon glyphicon-user\"></i> TestHeader / <i class=\"glyphicon glyphicon-calendar\"></i> 1/1/0001</p></div></div>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FeedBack>(true, true);

			var FeedBack = new List<FeedBack>();
			FeedBack.Add(new FeedBack()
			{
				Id = 1,
				Name = "TestHeader",
				Email = "email",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue

			});
			FeedBack.Add(new FeedBack()
			{
				Id = 1,
				Name = "TestHeader",
				Email = "email",
				Text = "12412412515125251435",
				Language = "en",
				Date = DateTime.MinValue
			});

			string actualResult = ListGroupHelper.ListGroup(htmlHelper, FeedBack).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperFeedBackListGroupEmptyNews()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FeedBack>(true, true);

			var FeedBack = new List<FeedBack>();

			string actualResult = ListGroupHelper.ListGroup(htmlHelper, FeedBack).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		#endregion
		#region DownLoads
		[TestMethod]
		public void ListGroupHelperDownLoadsGroup()
		{
			var expectedResult = "<a class=\"list-group-item\" href=\"D\"><span class=\"pull-left margin-right-ten\"><i class=\"glyphicon glyphicon-file\"></i></span>testName</a>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FileParameters>(true, true);
			var FileParameters = new FileParameters()
			{
				Name = "testName",
				Path = "D"
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, FileParameters).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}
		[TestMethod]
		public void ListGroupHelperDownLoadsGroupEmptyName()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FileParameters>(true, true);
			var FileParameters = new FileParameters()
			{
				Name = "",
				Path = "D"
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, FileParameters).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperDownLoadsGroupEmptyPath()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FileParameters>(true, true);
			var FileParameters = new FileParameters()
			{
				Name = "TestName",
				Path = ""
			};

			string actualResult = ListGroupHelper.Group(htmlHelper, FileParameters).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperDownLoadsListGroup()
		{
			var expectedResult = "<div class=\"list-group\"><a class=\"list-group-item active links\" href=\"#\">Download all files<span class=\"pull-right\"><i class=\"glyphicon glyphicon-download-alt\"></i></span></a><a class=\"list-group-item\" href=\"D\"><span class=\"pull-left margin-right-ten\"><i class=\"glyphicon glyphicon-file\"></i></span>1</a><a class=\"list-group-item\" href=\"D\"><span class=\"pull-left margin-right-ten\"><i class=\"glyphicon glyphicon-file\"></i></span>2</a><script>$('a.links').click(function(e) { e.preventDefault();window.open('D');window.open('D');});</script></div>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FileParameters>(true, true);

			var FileParameters = new List<FileParameters>();
			FileParameters.Add(new FileParameters()
			{
				Name = "1",
				Path = "D"

			});
			FileParameters.Add(new FileParameters()
			{
				Name = "2",
				Path = "D"
			});

			string actualResult = ListGroupHelper.ListGroup(htmlHelper, FileParameters).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void ListGroupHelperDownLoadsListGroupEmptyFileParameters()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<FeedBack>(true, true);

			var FileParameters = new List<FileParameters>();

			string actualResult = ListGroupHelper.ListGroup(htmlHelper, FileParameters).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		#endregion
	}
}
