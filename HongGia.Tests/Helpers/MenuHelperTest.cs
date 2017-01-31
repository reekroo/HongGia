using System;
using System.Collections.Generic;
using System.Web.Routing;
using HongGia.Core.Parameters.PartialElements;
using HongGia.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HongGia.Tests.Helpers
{
	[TestClass]
	public class MenuHelperTest
	{
		#region MenuSection
		[TestMethod]
		public void MenuHelperMenuSection()
		{
			var expectedResult = "<li><a href=\"\">LinkText</a></li>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<MenuSectionParameters>(true, true);
			var Menu = new MenuSectionParameters()
			{
				LinkText = "LinkText",
				ActionName = "ActionName",
				ControllerName = "ControllerName",
				RouteData = new RouteData()

			};

			string actualResult = MenuHelper.MenuSection(htmlHelper, Menu).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void MenuHelperMenuSectionEmptyLinktext()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<MenuSectionParameters>(true, true);
			var Menu = new MenuSectionParameters()
			{
				LinkText = "",
				ActionName = "ActionName",
				ControllerName = "ControllerName",
				RouteData = new RouteData()

			};

			string actualResult = MenuHelper.MenuSection(htmlHelper, Menu).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void MenuHelperMenuSectionEmptyActionName()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<MenuSectionParameters>(true, true);
			var Menu = new MenuSectionParameters()
			{
				LinkText = "LinkText",
				ActionName = "",
				ControllerName = "ControllerName",
				RouteData = new RouteData()

			};

			string actualResult = MenuHelper.MenuSection(htmlHelper, Menu).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void MenuHelperMenuSectionEmptyControllerName()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<MenuSectionParameters>(true, true);
			var Menu = new MenuSectionParameters()
			{
				LinkText = "LinkText",
				ActionName = "ActionName",
				ControllerName = "",
				RouteData = new RouteData()

			};

			string actualResult = MenuHelper.MenuSection(htmlHelper, Menu).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void MenuHelperMenuSectionNullRouteData()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<MenuSectionParameters>(true, true);
			var Menu = new MenuSectionParameters()
			{
				LinkText = "LinkText",
				ActionName = "ActionName",
				ControllerName = "ControllerName"

			};

			string actualResult = MenuHelper.MenuSection(htmlHelper, Menu).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		[TestMethod]
		public void MenuHelperMenuSectionNullData()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<MenuSectionParameters>(true, true);
			MenuSectionParameters Menu = null;
			

			string actualResult = MenuHelper.MenuSection(htmlHelper, Menu).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}
		#endregion
		#region DropdownMenuSection
		[TestMethod]
		public void MenuHelperDropdownMenuSection()
		{
			var expectedResult = "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"#\">dropdownName<b class=\"caret\"></b></a><ul class=\"dropdown-menu\"><li><a href=\"\">LinkText1</a></li><li><a href=\"\">LinkText2</a></li></ul></li>";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<MenuSectionParameters>(true, true);
			var MenuSectionParameters = new List<MenuSectionParameters>();
			MenuSectionParameters.Add(new MenuSectionParameters()
			{
				LinkText = "LinkText1",
				ActionName = "ActionName",
				ControllerName = "Test1",
				RouteData = new RouteData()
			});
			MenuSectionParameters.Add(new MenuSectionParameters()
			{
				LinkText = "LinkText2",
				ActionName = "ActionName",
				ControllerName = "Test2",
				RouteData = new RouteData()
			});

			string actualResult = MenuHelper.DropdownMenuSection(htmlHelper, "dropdownName", MenuSectionParameters).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}
		[TestMethod]
		public void MenuHelperDropdownMenuSectionEmptyParam()
		{
			var expectedResult = "";

			var htmlHelper = Moks.Moks.CreateHtmlHelper<MenuSectionParameters>(true, true);
			var MenuSectionParameters = new List<MenuSectionParameters>();

			string actualResult = MenuHelper.DropdownMenuSection(htmlHelper, "dropdownName", MenuSectionParameters).ToString();
			Assert.AreEqual(expectedResult, actualResult, "Correct");
		}

		#endregion
	}
}
