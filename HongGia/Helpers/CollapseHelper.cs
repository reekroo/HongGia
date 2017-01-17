using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using HongGia.Core.Models;
using HongGia.Core.Parameters;

namespace HongGia.Helpers
{
    public static class CollapseHelper
    {
        public static MvcHtmlString CollapsiblePanel(this HtmlHelper htmlHelper, CollapsiblePanelParameters parameters)
        {
            var groupTagBuilder = new TagBuilder("div");
            var panelTagBuilder = new TagBuilder("div");
            var headerTagBuilder = new TagBuilder("div");
            var titleTagBuilder = new TagBuilder("h4");
            var linkTagBuilder = new TagBuilder("a");
            var collapseTagBuilder = new TagBuilder("div");
            var bodyTagBuilder = new TagBuilder("div");
            var spanTagBuilder = new TagBuilder("span");
            var iconTagBuilder = new TagBuilder("i");
            var imageTagBuilder = new TagBuilder("img");
            var scriptTagBuilder = new TagBuilder("script");

            groupTagBuilder.AddCssClass("panel-group");
            panelTagBuilder.AddCssClass("panel panel-default");
            headerTagBuilder.AddCssClass("panel-heading");

            titleTagBuilder.AddCssClass("panel-title collapsable-header");
            titleTagBuilder.MergeAttribute("data-toggle", "collapse");
            titleTagBuilder.MergeAttribute("href", "#" + parameters.Header.GetHashCode().ToString());

            linkTagBuilder.MergeAttribute("data-toggle", "collapse");
            linkTagBuilder.MergeAttribute("href", "#" + parameters.Header.GetHashCode().ToString());

            spanTagBuilder.AddCssClass("pull-right panel-collapse-" + parameters.Header.GetHashCode().ToString());
            spanTagBuilder.MergeAttribute("data-toggle", "collapse");
            spanTagBuilder.MergeAttribute("href", "#" + parameters.Header.GetHashCode().ToString());

            iconTagBuilder.AddCssClass("glyphicon glyphicon-chevron-down");

            collapseTagBuilder.AddCssClass("panel-collapse collapse");
            collapseTagBuilder.MergeAttribute("id", parameters.Header.GetHashCode().ToString());

            bodyTagBuilder.AddCssClass("panel-body");

            linkTagBuilder.InnerHtml = parameters.Header;

            if (parameters.Image != null)
            {
                imageTagBuilder.AddCssClass("img-responsive");
                imageTagBuilder.MergeAttribute("src", parameters.Image.Src);
                imageTagBuilder.MergeAttribute("alt", parameters.Image.Alt);

                bodyTagBuilder.InnerHtml += imageTagBuilder.ToString();
            }

            bodyTagBuilder.InnerHtml += parameters.Text;

            spanTagBuilder.InnerHtml = iconTagBuilder.ToString();
            titleTagBuilder.InnerHtml = linkTagBuilder.ToString() + spanTagBuilder.ToString();
            headerTagBuilder.InnerHtml = titleTagBuilder.ToString();

            collapseTagBuilder.InnerHtml = bodyTagBuilder.ToString();

            panelTagBuilder.InnerHtml = headerTagBuilder.ToString() + collapseTagBuilder.ToString();
            groupTagBuilder.InnerHtml = panelTagBuilder.ToString();

            scriptTagBuilder.InnerHtml = GetScript(parameters.Header);

            groupTagBuilder.InnerHtml += scriptTagBuilder.ToString();

            return new MvcHtmlString(groupTagBuilder.ToString());
        }

        public static MvcHtmlString ColllapsiblePhotoPanel(this HtmlHelper htmlHelper, IEnumerable<Photo> parameters, string header)
        {
            if (parameters == null || parameters.Count() == 0)
            {
                return new MvcHtmlString("");
            }
            
            var groupTagBuilder = new TagBuilder("div");
            var panelTagBuilder = new TagBuilder("div");
            var headerTagBuilder = new TagBuilder("div");
            var titleTagBuilder = new TagBuilder("h4");
            var linkTagBuilder = new TagBuilder("a");
            var collapseTagBuilder = new TagBuilder("div");
            var bodyTagBuilder = new TagBuilder("div");
            var spanTagBuilder = new TagBuilder("span");
            var iconTagBuilder = new TagBuilder("i");
            var scriptTagBuilder = new TagBuilder("script");

            groupTagBuilder.AddCssClass("panel-group");
            panelTagBuilder.AddCssClass("panel panel-default");
            headerTagBuilder.AddCssClass("panel-heading");

            titleTagBuilder.AddCssClass("panel-title collapsable-header");
            titleTagBuilder.MergeAttribute("data-toggle", "collapse");
            titleTagBuilder.MergeAttribute("href", "#" + header.GetHashCode().ToString());

            linkTagBuilder.MergeAttribute("data-toggle", "collapse");
            linkTagBuilder.MergeAttribute("href", "#" + header.GetHashCode().ToString());

            spanTagBuilder.AddCssClass("pull-right panel-collapse-" + header.GetHashCode().ToString());
            spanTagBuilder.MergeAttribute("data-toggle", "collapse");
            spanTagBuilder.MergeAttribute("href", "#" + header.GetHashCode().ToString());

            iconTagBuilder.AddCssClass("glyphicon glyphicon-chevron-down");

            collapseTagBuilder.AddCssClass("panel-collapse collapse");
            collapseTagBuilder.MergeAttribute("id", header.GetHashCode().ToString());

            bodyTagBuilder.AddCssClass("panel-body");
            
            linkTagBuilder.InnerHtml = header;

            if (parameters.Count() <= 7)
            {
                bodyTagBuilder.InnerHtml += PhotoGroup(htmlHelper, parameters);
            }
            else
            {
                bodyTagBuilder.InnerHtml += PhotoGroup(htmlHelper, parameters.OrderBy(x => x.Id).Take(7).ToList(), header);
            }


            spanTagBuilder.InnerHtml = iconTagBuilder.ToString();
            titleTagBuilder.InnerHtml = linkTagBuilder.ToString() + spanTagBuilder.ToString();
            headerTagBuilder.InnerHtml = titleTagBuilder.ToString();

            collapseTagBuilder.InnerHtml = bodyTagBuilder.ToString();

            panelTagBuilder.InnerHtml = headerTagBuilder.ToString() + collapseTagBuilder.ToString();
            groupTagBuilder.InnerHtml = panelTagBuilder.ToString();

            scriptTagBuilder.InnerHtml = GetScript(header);

            groupTagBuilder.InnerHtml += scriptTagBuilder.ToString();

            return new MvcHtmlString(groupTagBuilder.ToString());
        }

        private static string PhotoGroup(HtmlHelper htmlHelper, IEnumerable<Photo> parameters, string category = null)
        {

            var firstRowTagBuilder = new TagBuilder("div");
            var secondRowTagBuilder = new TagBuilder("div");

            firstRowTagBuilder.AddCssClass("row row-margin");
            secondRowTagBuilder.AddCssClass("row row-margin");

            foreach (var parameter in parameters.Take(4).ToList())
            {
                firstRowTagBuilder.InnerHtml += GetPhoto(parameter);
            }
            
            foreach (var parameter in parameters.Skip(4).Take(3).ToList())
            {
                secondRowTagBuilder.InnerHtml += GetPhoto(parameter);
            }

            if (string.IsNullOrEmpty(category) == false)
            {
                secondRowTagBuilder.InnerHtml += GetLink(htmlHelper, category);
            }

            return firstRowTagBuilder.ToString() + secondRowTagBuilder.ToString();
        }
        
        private static string GetPhoto(Photo parameter)
        {
            var col = new TagBuilder("div");
            var thumbnail = new TagBuilder("div");
            var image = new TagBuilder("img");

            col.AddCssClass("col-md-3");
            thumbnail.AddCssClass("thumbnail");
            image.AddCssClass("img-responsive");

            image.MergeAttribute("alt", parameter.Name);
            image.MergeAttribute("src", parameter.Path);

            thumbnail.InnerHtml = image.ToString();
            col.InnerHtml = thumbnail.ToString();

            return col.ToString();
        }

        private static string GetLink(HtmlHelper htmlHelper, string category)
        {
            var col = new TagBuilder("div");
            var thumbnail = new TagBuilder("div");

            col.AddCssClass("col-md-3");
            thumbnail.AddCssClass("thumbnail");

            var link = htmlHelper.ActionLink("See More Photo", "CategoryPhoto", "Photo", routeValues:new { category }, htmlAttributes:new { @class = "btn btn-default"});
            
            thumbnail.InnerHtml = link.ToString();
            col.InnerHtml = thumbnail.ToString();

            return col.ToString();
        }

        private static string GetScript(string parameter)
        {
            return
                "$(\"#" + parameter.GetHashCode().ToString() + "\").on(\"hide.bs.collapse\", function() {" +
                "$(\".panel-collapse-" + parameter.GetHashCode().ToString() + "\").find('i').removeClass(\"glyphicon-chevron-up\").addClass(\"glyphicon-chevron-down\");" +
                "});" +
                "$(\"#" + parameter.GetHashCode().ToString() + "\").on(\"show.bs.collapse\", function() {" +
                "$(\".panel-collapse-" + parameter.GetHashCode().ToString() + "\").find('i').removeClass(\"glyphicon-chevron-down\").addClass(\"glyphicon-chevron-up\");" +
                "});";
        }
    }
}