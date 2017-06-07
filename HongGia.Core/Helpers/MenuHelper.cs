using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

using HongGia.Core.Parameters;

namespace HongGia.Core.Helpers
{
	public static class MenuHelper
	{
		public static MvcHtmlString MenuSection(this HtmlHelper htmlHelper, MenuSectionParameters parameters, string prevCssClass = "")
		{
			if (parameters == null)
			{
				return new MvcHtmlString(string.Empty);
			}

			if (string.IsNullOrEmpty(parameters.ActionName) == true ||
			  string.IsNullOrEmpty(parameters.ControllerName) == true ||
			  string.IsNullOrEmpty(parameters.LinkText) == true ||
			  parameters.RouteData == null)
			{
				return new MvcHtmlString(string.Empty);
			}

			var liTagBuilder = new TagBuilder("li");
			var linkText= new TagBuilder("span");
			linkText.AddCssClass("header-span");
			linkText.InnerHtml = parameters.LinkText;

			if (IsActiveClass(parameters, "action"))
			{
				liTagBuilder.AddCssClass("active");
			}
			var link = htmlHelper.ActionLink(parameters.LinkText, parameters.ActionName, parameters.ControllerName, new { name = parameters.QueryString }, null);
			liTagBuilder.InnerHtml = link.ToHtmlString();

			if (!string.IsNullOrEmpty(prevCssClass) == true)
			{
				var spanImageTagBuilder = new TagBuilder("span");
				spanImageTagBuilder.AddCssClass(prevCssClass);

				link = htmlHelper.ActionLink(" ", parameters.ActionName, parameters.ControllerName, new { name = parameters.QueryString }, null);

				var result = spanImageTagBuilder.ToString() +"<br>"+ linkText.ToString();

				var linkWithNameContainer = link.ToString().Insert((link.ToString().IndexOf("</a>", StringComparison.Ordinal)-1), result);
				liTagBuilder.InnerHtml = linkWithNameContainer.ToString();
			}


			return new MvcHtmlString(liTagBuilder.ToString());
		}

		public static MvcHtmlString DropdownMenuSection(this HtmlHelper htmlHelper, string dropdownName, IEnumerable<MenuSectionParameters> parameters, string prevCssClass = "")
		{
			if (parameters == null || parameters.Count() == 0)
			{
				return new MvcHtmlString(string.Empty);
			}
			
			var liTagBuilder = new TagBuilder("li");
			liTagBuilder.AddCssClass("dropdown");

			var aTagBuilder = new TagBuilder("a");
			aTagBuilder.AddCssClass("dropdown-toggle");
			aTagBuilder.MergeAttribute("data-toggle", "dropdown");
			aTagBuilder.MergeAttribute("href", "#");
			//	"<span class='glyphicon glyphicon-tree-deciduous'></span><br>")
		
			var spanTagBuilder = new TagBuilder("span");
			spanTagBuilder.AddCssClass("header-span");


			var bTagBuilder = new TagBuilder("b");
			bTagBuilder.AddCssClass("caret");

			var ulTagBuilder = new TagBuilder("ul");
			ulTagBuilder.AddCssClass("dropdown-menu");

			foreach (var parameter in parameters)
			{
				if (parameter == null)
				{
					ulTagBuilder.InnerHtml += AddSeporator();
				}
				else
				{
					ulTagBuilder.InnerHtml += MenuSection(htmlHelper, parameter);
				}
			}

			if (ulTagBuilder.InnerHtml.Contains("active"))
			{
				liTagBuilder.AddCssClass("active");
			}

			spanTagBuilder.InnerHtml = dropdownName;

			if (!string.IsNullOrEmpty(prevCssClass) == true)
			{
				var spanImageTagBuilder = new TagBuilder("span");
				spanImageTagBuilder.AddCssClass(prevCssClass);

				aTagBuilder.InnerHtml = spanImageTagBuilder.ToString() + "<br>" + spanTagBuilder.ToString() + bTagBuilder.ToString();
			}else{
				aTagBuilder.InnerHtml = spanTagBuilder.ToString() + bTagBuilder.ToString();
			}
			
			
			liTagBuilder.InnerHtml = aTagBuilder.ToString() + ulTagBuilder.ToString();

			return new MvcHtmlString(liTagBuilder.ToString());
		}

		private static string AddSeporator()
		{
			var separator = new TagBuilder("li");
			separator.AddCssClass("divider");
			separator.MergeAttribute("role", "separator");

			return separator.ToString();
		}

		private static bool IsActiveClass(MenuSectionParameters menu, string param)
		{
			if (menu.RouteData == null)
			{
				return false;
			}

			var routeValueDictionary = new RouteValueDictionary(menu.RouteData.Values);

			if (routeValueDictionary.ContainsKey(param))
			{
				//if (menu.RouteData.Values[param] as string == menu.ActionName)
				if (menu.RouteData.Values["controller"] as string == menu.ControllerName &&
					menu.RouteData.Values["action"] as string == menu.ActionName)
				{
					return true;
				}
			}

			return false;
		}
	}
}