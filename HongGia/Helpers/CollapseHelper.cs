using System.Web.Mvc;
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

            titleTagBuilder.AddCssClass("panel-title");
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

            scriptTagBuilder.InnerHtml = //"window.onload = function () {" +
                "$(\"#" + parameters.Header.GetHashCode().ToString() + "\").on(\"hide.bs.collapse\", function() {" +
                "$(\".panel-collapse-" + parameters.Header.GetHashCode().ToString() +
                "\").find('i').removeClass(\"glyphicon-chevron-up\").addClass(\"glyphicon-chevron-down\");" +
                "});" +
                "$(\"#" + parameters.Header.GetHashCode().ToString() + "\").on(\"show.bs.collapse\", function() {" +
                "$(\".panel-collapse-" + parameters.Header.GetHashCode().ToString() +
                "\").find('i').removeClass(\"glyphicon-chevron-down\").addClass(\"glyphicon-chevron-up\");" +
                "});";//+
                //"}";

            groupTagBuilder.InnerHtml += scriptTagBuilder.ToString();

            return new MvcHtmlString(groupTagBuilder.ToString());
        }
    }
}