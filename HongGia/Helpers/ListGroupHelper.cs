using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Models;
using HongGia.Core.Parameters;
using HongGia.Core.Parameters.Base;
using HongGia.Models;

namespace HongGia.Helpers
{
	public static class ListGroupHelper
	{
		#region News

		public static MvcHtmlString Group(this HtmlHelper htmlHelper, News parameter)
		{
			if (parameter == null)
			{
				return new MvcHtmlString(string.Empty);
			}

			if (string.IsNullOrEmpty(parameter.Text) == true
 			  || string.IsNullOrEmpty(parameter.Header) == true
			  || string.IsNullOrEmpty(parameter.Date.ToString()) == true
			  || string.IsNullOrEmpty(parameter.Language) == true
			  || string.IsNullOrEmpty(parameter.Id.ToString()) == true)
			{
				return new MvcHtmlString(string.Empty);
			}

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

		public static MvcHtmlString ListGroup(this HtmlHelper htmlHelper, IEnumerable<News> parameters)
		{

			if (parameters == null || parameters.Count() == 0)
			{
				return new MvcHtmlString(string.Empty);
			}

			var thumbnailTagBuilder = new TagBuilder("div");
			var listGroupTagBuilder = new TagBuilder("div");

			thumbnailTagBuilder.AddCssClass("thumbnail");
			listGroupTagBuilder.AddCssClass("list-group margin-bottom-zero");

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
			if (parameter == null)
			{
				return new MvcHtmlString(string.Empty);
			}

			if (string.IsNullOrEmpty(parameter.Text) == true
 			  || string.IsNullOrEmpty(parameter.Email) == true
			  || string.IsNullOrEmpty(parameter.Date.ToString()) == true
			  || string.IsNullOrEmpty(parameter.Language) == true
			  || string.IsNullOrEmpty(parameter.Name) == true
			  || string.IsNullOrEmpty(parameter.Id.ToString()) == true)
			{
				return new MvcHtmlString(string.Empty);
			}

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
			if (parameters == null || parameters.Count() == 0)
			{
				return new MvcHtmlString(string.Empty);
			}

			var listTagBuilder = new TagBuilder("div");

			foreach (var parameter in parameters)
			{
				listTagBuilder.InnerHtml += Group(htmlHelper, parameter);
			}

			return new MvcHtmlString(listTagBuilder.ToString());
		}

		#endregion

		#region DownLoads

		public static MvcHtmlString Group(this HtmlHelper htmlHelper, FileParameters parameter)
		{
			if (parameter == null)
			{
				return new MvcHtmlString(string.Empty);
			}

			if (string.IsNullOrEmpty(parameter.Name) == true
 			  || string.IsNullOrEmpty(parameter.Path) == true)
			{
				return new MvcHtmlString(string.Empty);
			}

			var linkTagBuilder = new TagBuilder("a");
			var spanTagBuilder = new TagBuilder("span");
			var iconTagBuilder = new TagBuilder("i");

			linkTagBuilder.AddCssClass("list-group-item");
			linkTagBuilder.MergeAttribute("href", parameter.Path);

			spanTagBuilder.AddCssClass("pull-left margin-right-ten");

			iconTagBuilder.AddCssClass("glyphicon glyphicon-file");

			spanTagBuilder.InnerHtml = iconTagBuilder.ToString();
			linkTagBuilder.InnerHtml = spanTagBuilder.ToString() + parameter.Name;

			return new MvcHtmlString(linkTagBuilder.ToString());
		}

		public static MvcHtmlString ListGroup(this HtmlHelper htmlHelper, IEnumerable<FileParameters> parameters)
		{

			if (parameters == null || parameters.Count() == 0)
			{
				return new MvcHtmlString(string.Empty);
			}

			var groupTagBuilder = new TagBuilder("div");
			var headerLinkTagBuilder = new TagBuilder("a");
			var spanTagBuilder = new TagBuilder("span");
			var iconTagBuilder = new TagBuilder("i");
			var scriptTagBuilder = new TagBuilder("script");

			groupTagBuilder.AddCssClass("list-group");
			headerLinkTagBuilder.AddCssClass("list-group-item active links");
			headerLinkTagBuilder.MergeAttribute("href", "#");
			spanTagBuilder.AddCssClass("pull-right");
			iconTagBuilder.AddCssClass("glyphicon glyphicon-download-alt");

			spanTagBuilder.InnerHtml = iconTagBuilder.ToString();
			headerLinkTagBuilder.InnerHtml = "Download all files" + spanTagBuilder.ToString();
			groupTagBuilder.InnerHtml = headerLinkTagBuilder.ToString();

			foreach (var parameter in parameters)
			{
				groupTagBuilder.InnerHtml += Group(htmlHelper, parameter);
			}

			scriptTagBuilder.InnerHtml = "$('a.links').click(function(e) { e.preventDefault();";

			foreach (var parameter in parameters)
			{
				scriptTagBuilder.InnerHtml += "window.open('" + parameter.Path + "');";
			}

			scriptTagBuilder.InnerHtml += "});";

			groupTagBuilder.InnerHtml += scriptTagBuilder.ToString();

			return new MvcHtmlString(groupTagBuilder.ToString());
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