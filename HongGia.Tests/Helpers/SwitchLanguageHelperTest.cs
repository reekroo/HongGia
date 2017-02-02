using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HongGia.Core.Parameters.PartialElements;
using HongGia.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HongGia.Tests.Helpers
{
	[TestClass]
	public class SwitchLanguageHelperTest
	{
		[TestMethod]
		public void Switcher()
		{
			var context = new Mock<HttpContextBase>();
			RequestContext requestContext = new RequestContext(context.Object, new RouteData());
			UrlHelper urlHelper = new UrlHelper(requestContext);

			RouteData routeData = new RouteData();

			var switchPatameters = new SwitchLanguageParameters()
			{ Lang = "ru", RouteData = routeData, Name = "ru" };

			var expectedResult = "<li><a href=\"\">ru</a></li>";

			string actualResult = SwitchLanguageHelper.Switcher(urlHelper, switchPatameters).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void SwitcherEmpty()
		{
			var context = new Mock<HttpContextBase>();
			RequestContext requestContext = new RequestContext(context.Object, new RouteData());
			UrlHelper urlHelper = new UrlHelper(requestContext);

			RouteData routeData = new RouteData();

			var switchPatameters = new SwitchLanguageParameters();
	
			var expectedResult = "";

			string actualResult = SwitchLanguageHelper.Switcher(urlHelper, switchPatameters).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}


		[TestMethod]
		public void DropdownSwitcher()
		{
			var context = new Mock<HttpContextBase>();
			RequestContext requestContext = new RequestContext(context.Object, new RouteData());
			UrlHelper urlHelper = new UrlHelper(requestContext);

			RouteData routeData = new RouteData();
			var switchPatameters = new List<SwitchLanguageParameters>();
			switchPatameters.Add(new SwitchLanguageParameters()
			{ Lang = "ru", RouteData = routeData, Name = "ru" });
			switchPatameters.Add(new SwitchLanguageParameters()
			{ Lang = "en", RouteData = routeData, Name = "en" });
			string name = "testName";

			var expectedResult = "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"#\">testName<b class=\"caret\"></b></a><ul class=\"dropdown-menu\"><li><a href=\"\">ru</a></li><li><a href=\"\">en</a></li></ul></li>";

			string actualResult = SwitchLanguageHelper.DropdownSwitcher(urlHelper, name, switchPatameters).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void DropdownSwitcherEmptyName()
		{
			var context = new Mock<HttpContextBase>();
			RequestContext requestContext = new RequestContext(context.Object, new RouteData());
			UrlHelper urlHelper = new UrlHelper(requestContext);

			RouteData routeData = new RouteData();
			var switchPatameters = new List<SwitchLanguageParameters>();
			switchPatameters.Add(new SwitchLanguageParameters()
			{ Lang = "ru", RouteData = routeData, Name = "ru" });
			switchPatameters.Add(new SwitchLanguageParameters()
			{ Lang = "en", RouteData = routeData, Name = "en" });
			string name = "";

			var expectedResult = "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"#\"><b class=\"caret\"></b></a><ul class=\"dropdown-menu\"><li><a href=\"\">ru</a></li><li><a href=\"\">en</a></li></ul></li>";

			string actualResult = SwitchLanguageHelper.DropdownSwitcher(urlHelper, name, switchPatameters).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void DropdownSwitcherEmpty()
		{
			var context = new Mock<HttpContextBase>();
			RequestContext requestContext = new RequestContext(context.Object, new RouteData());
			UrlHelper urlHelper = new UrlHelper(requestContext);

			RouteData routeData = new RouteData();
			var switchPatameters = new List<SwitchLanguageParameters>();
			
			string name = "";

			var expectedResult = "";

			string actualResult = SwitchLanguageHelper.DropdownSwitcher(urlHelper, name, switchPatameters).ToString();

			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}
	}
}
