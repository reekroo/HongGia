using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HongGia.Core.Interfaces.Base;

namespace HongGia.CRM.Helpers
{
    public static class SliderHelper
    {
        public static MvcHtmlString Slider(this HtmlHelper htmlHelper, IEnumerable<IImage> parameters)
        {
            if (parameters == null || !parameters.Any() || parameters.Count() == 0)
            {
                return new MvcHtmlString(string.Empty);
            }

            var carouselTagBuilder = new TagBuilder("div");
            carouselTagBuilder.AddCssClass("carousel slide");
            carouselTagBuilder.MergeAttribute("id", "carousel-example-generic");
            carouselTagBuilder.MergeAttribute("data-ride", "carousel");

            carouselTagBuilder.InnerHtml += Indicators(parameters.Count());
            carouselTagBuilder.InnerHtml += Slides(parameters);
            carouselTagBuilder.InnerHtml += Controls();

            return new MvcHtmlString(carouselTagBuilder.ToString());
        }

        private static string Controls()
        {
            return
                "<a class=\"left carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"prev\">" +
                "<span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\"></span>" +
                "<span class=\"sr-only\">Previous</span></a>" +
                "<a class=\"right carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"next\">" +
                "<span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span>" +
                "<span class=\"sr-only\">Next</span></a>";
        }

        private static string Indicators(int count)
        {
            var indicatorTagBuilder = new TagBuilder("ol");
            indicatorTagBuilder.AddCssClass("carousel-indicators");

            for (var i = 0; i < count; i++)
            {
                var genericTagBuilder = new TagBuilder("li");
                genericTagBuilder.MergeAttribute("data-target", "#carousel-example-generic");
                genericTagBuilder.MergeAttribute("data-slide-to", i.ToString());

                if (i == 0)
                {
                    genericTagBuilder.AddCssClass("active");
                }

                indicatorTagBuilder.InnerHtml += genericTagBuilder;
            }

            return indicatorTagBuilder.ToString();
        }

        private static string Slides(IEnumerable<IImage> parameters)
        {
            var wrapperTagBuilder = new TagBuilder("div");
            wrapperTagBuilder.AddCssClass("carousel-inner");
            wrapperTagBuilder.MergeAttribute("role", "listbox");

            var enumerable = parameters as IList<IImage> ?? parameters.ToList();

            for (var i = 0; i < enumerable.Count(); i++)
            {
                var itemTagBuilder = new TagBuilder("div");
                itemTagBuilder.AddCssClass("item");

                itemTagBuilder.InnerHtml = Image(enumerable[i]);

                if (i == 0)
                {
                    itemTagBuilder.AddCssClass("active");
                }

                wrapperTagBuilder.InnerHtml += itemTagBuilder;
            }

            return wrapperTagBuilder.ToString();
        }

        private static string Image(IImage parameter)
        {
            var imageTagBuilder = new TagBuilder("img");

            imageTagBuilder.MergeAttribute("src", parameter.Src);
            imageTagBuilder.MergeAttribute("alt", parameter.Alt);

            return imageTagBuilder.ToString();
        }
    }
} 