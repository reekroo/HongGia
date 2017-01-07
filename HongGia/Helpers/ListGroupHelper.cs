using System.Collections.Generic;
using System.Web.Mvc;
using HongGia.Models.Classes;

namespace HongGia.Helpers
{
    public static class ListGroupHelper
    {
        public static MvcHtmlString Group(this HtmlHelper htmlHelper, NewsListParameters parameter)
        {
            var linkTagBuilder = new TagBuilder("a");
            var headerTagBuilder = new TagBuilder("h4");
            var textTagBuilder = new TagBuilder("p");
            var dateTagBuilder = new TagBuilder("p");

            linkTagBuilder.AddCssClass("list-group-item list-group-item-action");
            headerTagBuilder.AddCssClass("list-group-item-heading text");
            textTagBuilder.AddCssClass("list-group-item-text");
            dateTagBuilder.AddCssClass("list-group-item-text text-right");

            linkTagBuilder.MergeAttribute("href", parameter.Link);
            headerTagBuilder.SetInnerText(parameter.Header);
            textTagBuilder.SetInnerText(parameter.Text);
            dateTagBuilder.SetInnerText(parameter.Date.ToString("d"));

            linkTagBuilder.InnerHtml = headerTagBuilder.ToString() + textTagBuilder.ToString() + dateTagBuilder.ToString();

            return new MvcHtmlString(linkTagBuilder.ToString());
        }

        public static MvcHtmlString ListGroup(this HtmlHelper htmlHelper, IEnumerable<NewsListParameters> parameters)
        {
            var thumbnailTagBuilder = new TagBuilder("div");
            var listGroupTagBuilder = new TagBuilder("div");

            thumbnailTagBuilder.AddCssClass("thumbnail");
            listGroupTagBuilder.AddCssClass("list-group");

            listGroupTagBuilder.MergeAttribute("style", "margin-bottom: 0");
            
            foreach (var parameter in parameters)
            {
                listGroupTagBuilder.InnerHtml += Group(htmlHelper, parameter);
            }

            thumbnailTagBuilder.InnerHtml = listGroupTagBuilder.ToString();
            
            return new MvcHtmlString(thumbnailTagBuilder.ToString());
        }
    }
} 