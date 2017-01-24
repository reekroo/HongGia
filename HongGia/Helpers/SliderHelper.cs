using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using HongGia.Core.Parameters.Base;
using HongGia.Core.Parameters.PartialElements;

namespace HongGia.Helpers
{
    public static class SliderHelper
    {
        public static MvcHtmlString Slider(this HtmlHelper htmlHelper, IEnumerable<ImageParameters> parameters)
        {
            if (parameters == null || !parameters.Any())
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

        private static string Slides(IEnumerable<ImageParameters> parameters)
        {
            var wrapperTagBuilder = new TagBuilder("div");
            wrapperTagBuilder.AddCssClass("carousel-inner");
            wrapperTagBuilder.MergeAttribute("role", "listbox");

            var sliderParameterses = parameters as SliderParameters[] ?? parameters.ToArray();

            for (var i = 0; i < sliderParameterses.Count(); i++)
            {
                var itemTagBuilder = new TagBuilder("div");
                itemTagBuilder.AddCssClass("item");

                itemTagBuilder.InnerHtml = Image(sliderParameterses[i]);

                if (i == 0)
                {
                    itemTagBuilder.AddCssClass("active");
                }

                wrapperTagBuilder.InnerHtml += itemTagBuilder;
            }

            return wrapperTagBuilder.ToString();
        }

        private static string Image(ImageParameters parameter)
        {
            var imageTagBuilder = new TagBuilder("img");

            imageTagBuilder.MergeAttribute("src", parameter.Src);
            imageTagBuilder.MergeAttribute("alt", parameter.Alt);

            return imageTagBuilder.ToString();
        }
    }
} 