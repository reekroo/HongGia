using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using HongGia.Models.Classes;

namespace HongGia.Helpers
{
    public static class MenuHelper
    {
        public static MvcHtmlString MenuSection(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            var liTagBuilder = new TagBuilder("li");

            var link = htmlHelper.ActionLink(linkText, actionName, controllerName);

            liTagBuilder.InnerHtml = link.ToHtmlString();

            return new MvcHtmlString(liTagBuilder.ToString());
        }

        public static MvcHtmlString MenuSection(this HtmlHelper htmlHelper, MenuSectionParameters parameters)
        {
            var liTagBuilder = new TagBuilder("li");

            var link = htmlHelper.ActionLink(parameters.LinkText, parameters.ActionName, parameters.ControllerName);

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
                ulTagBuilder.InnerHtml += MenuSection(htmlHelper, parameter);
            }

            aTagBuilder.InnerHtml = dropdownName + bTagBuilder.ToString();
            liTagBuilder.InnerHtml = aTagBuilder.ToString() + ulTagBuilder.ToString();
            
            return new MvcHtmlString(liTagBuilder.ToString());
        }
    }
} 