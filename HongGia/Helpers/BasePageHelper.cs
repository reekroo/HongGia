using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Helpers
{
    public static class BasePageHelper
    {
        public static MvcHtmlString BasePage(this HtmlHelper htmlHelper, IBasePage parameters)
        {
            var result = string.Empty;

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

                    result += parameters.Header;
                }
            }

            if (string.IsNullOrEmpty(parameters.Header) == false)
            {
                var headerTagBuider = new TagBuilder("h3") {InnerHtml = parameters.Header};

                headerTagBuider.AddCssClass("text-center");
                
                if (parameters.Images.Count() > 1 )
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
                    if (topic.Type.ToLower() == "collapse")
                    {
                        result += htmlHelper.CollapsiblePanel(parameters as ICollapsiblePanel);
                    }
                    else
                    {
                        var topicTagBuider = new TagBuilder("div") {InnerHtml = topic.HtmlText};
                        
                        result += topicTagBuider.ToString();
                    }
                }
            }

            if (parameters.Files != null && parameters.Files.Count() > 0)
            {
                result += htmlHelper.ListGroup(parameters.Files);
            }

            return new MvcHtmlString(result);
        }
    }
} 