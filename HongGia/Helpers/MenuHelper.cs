using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

using HongGia.Core.Parameters.PartialElements;

namespace HongGia.Helpers
{
    public static class MenuHelper
    {
        public static MvcHtmlString MenuSection(this HtmlHelper htmlHelper, MenuSectionParameters parameters)
        {
            var liTagBuilder = new TagBuilder("li");

            var link = htmlHelper.ActionLink(parameters.LinkText, parameters.ActionName, parameters.ControllerName);

            if (IsActiveClass(parameters, "action"))
            {
                liTagBuilder.AddCssClass("active");
            }

            liTagBuilder.InnerHtml = link.ToHtmlString();

            return new MvcHtmlString(liTagBuilder.ToString());
        }

        public static MvcHtmlString DropdownMenuSection(this HtmlHelper htmlHelper, string dropdownName, IEnumerable<MenuSectionParameters> parameters)
        {
            var liTagBuilder = new TagBuilder("li");
            liTagBuilder.AddCssClass("dropdown");
            
            var aTagBuilder = new TagBuilder("a");
            aTagBuilder.AddCssClass("dropdown-toggle");
            aTagBuilder.MergeAttribute("data-toggle", "dropdown");
            aTagBuilder.MergeAttribute("href", "#");
            
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

            aTagBuilder.InnerHtml = dropdownName + bTagBuilder.ToString();
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
                if (menu.RouteData.Values[param] as string == menu.ActionName)
                {
                    return true;
                }
            }

            return false;
        }
    }
} 