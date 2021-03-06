﻿using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Helpers
{
	public static class BasePageHelper
	{
		public static MvcHtmlString BasePage(this HtmlHelper htmlHelper, IBasePage parameters)
		{
			var result = string.Empty;

			if (parameters == null)
			{
				return new MvcHtmlString(result);
			}
            
            if (parameters.Images != null && parameters.Images.Count() > 0)
			{
				if (parameters.Images.Count() > 1)
				{
					result += htmlHelper.Slider(parameters.Images).ToString();
				}
				else
				{
					var imageTagBuilder = new TagBuilder("img");

					imageTagBuilder.AddCssClass("img-responsive");
					imageTagBuilder.MergeAttribute("src", parameters.Images.First().Src);
					imageTagBuilder.MergeAttribute("alt", parameters.Images.First().Alt);

					result += imageTagBuilder.ToString();
				}
			}

			if (string.IsNullOrEmpty(parameters.Header) == false)
			{
				var headerTagBuider = new TagBuilder("h3") { InnerHtml = parameters.Header };

				headerTagBuider.AddCssClass("text-center");

				if (parameters.Images.Count() > 1)
				{
					result += headerTagBuider.ToString();
				}
				else
				{
					result = headerTagBuider.ToString() + result;
				}
			}

			if (parameters.Topics != null && parameters.Topics.Count() > 0)
			{
				foreach (var topic in parameters.Topics.OrderBy(x => x.Position))
				{
					if (string.IsNullOrEmpty(topic.Type) == false && topic.Type.ToLower() == "collapse")
					{
						result += htmlHelper.CollapsiblePanel(topic);
					}
					else
					{
						var topicTagBuider = new TagBuilder("div") { InnerHtml = topic.HtmlText };

                        topicTagBuider.AddCssClass("text-group");

                        result += topicTagBuider.ToString();
					}
				}
			}

			if (parameters.Files != null && parameters.Files.Count() > 0)
			{
				result += htmlHelper.ListGroup(parameters.Files);
			}
            
            var container = new TagBuilder("div");
            container.AddCssClass("base-page-container");

            container.InnerHtml += result;

            return new MvcHtmlString(container.ToString());
		}
	}
}