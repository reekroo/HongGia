using System.Collections.Generic;
using System.Web.Mvc;
using HongGia.Models;

namespace HongGia.Helpers
{
    public static class ListGroupHelper
    {
        #region News

        public static MvcHtmlString Group(this HtmlHelper htmlHelper, NewsViewModel parameter)
        {
            var linkTagBuilder = new TagBuilder("a");
            var headerTagBuilder = new TagBuilder("h4");
            var textTagBuilder = new TagBuilder("p");
            var dateTagBuilder = new TagBuilder("p");

            linkTagBuilder.AddCssClass("list-group-item list-group-item-action");
            headerTagBuilder.AddCssClass("list-group-item-heading text");
            textTagBuilder.AddCssClass("list-group-item-text");
            dateTagBuilder.AddCssClass("list-group-item-text text-right");

            linkTagBuilder.MergeAttribute("href", GetLink(parameter.Id, parameter.Language));
            headerTagBuilder.SetInnerText(parameter.Header);
            textTagBuilder.SetInnerText(parameter.Text);
            dateTagBuilder.SetInnerText(parameter.Date.ToString("d"));

            linkTagBuilder.InnerHtml = headerTagBuilder.ToString() + textTagBuilder.ToString() + dateTagBuilder.ToString();

            return new MvcHtmlString(linkTagBuilder.ToString());
        }

        public static MvcHtmlString ListGroup(this HtmlHelper htmlHelper, IEnumerable<NewsViewModel> parameters)
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

        #endregion

        #region FeedBacks

        public static MvcHtmlString Group(this HtmlHelper htmlHelper, FeedBack parameter)
        {
            var groupTagBuilder = new TagBuilder("div");
            var textTagBuilder = new TagBuilder("p");
            var commenterTagBuilder = new TagBuilder("p");
            var authorImgTagBuilder = new TagBuilder("i");
            var dateImgTagBuilder = new TagBuilder("i");

            groupTagBuilder.AddCssClass("feetback");
            textTagBuilder.AddCssClass("text-justify");
            commenterTagBuilder.AddCssClass("text-right");
            authorImgTagBuilder.AddCssClass("glyphicon glyphicon-user");
            dateImgTagBuilder.AddCssClass("glyphicon glyphicon-calendar");

            textTagBuilder.InnerHtml = parameter.Text;
            commenterTagBuilder.InnerHtml = authorImgTagBuilder + " " + parameter.Name + " / " + dateImgTagBuilder + " " + parameter.Date.ToString("d");

            groupTagBuilder.InnerHtml = textTagBuilder.ToString() + commenterTagBuilder.ToString();

            return new MvcHtmlString(groupTagBuilder.ToString());
        }

        public static MvcHtmlString ListGroup(this HtmlHelper htmlHelper, IEnumerable<FeedBack> parameters)
        {
            var listTagBuilder = new TagBuilder("div");
            
            foreach (var parameter in parameters)
            {
                listTagBuilder.InnerHtml += Group(htmlHelper, parameter);
            }

            return new MvcHtmlString(listTagBuilder.ToString());
        }

        #endregion
        
        private static string GetLink(int id, string lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                return "/ru/News/News?id=" + id;
            }

            return "/" + lang + "/News/News?id=" + id;
        }
    }
}  