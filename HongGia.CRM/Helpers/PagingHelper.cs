using System;
using System.Globalization;
using System.Text;
using System.Web.Mvc;

namespace HongGia.CRM.Helpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, int currentPage, int itemCount, int pageSize, Func<int, string> pageUrl)
        {
            var builder = new StringBuilder();
            var totalPages = (int)Math.Ceiling((double)itemCount / pageSize);

            //Prev
            var prevBuilder = new TagBuilder("a") { InnerHtml = "«" };
            if (currentPage == 0)
            {
                prevBuilder.MergeAttribute("href", "#");
                builder.AppendLine("<li class=\"active\">" + prevBuilder + "</li>");
            }
            else
            {
                prevBuilder.MergeAttribute("href", pageUrl.Invoke(currentPage - 1));
                builder.AppendLine("<li>" + prevBuilder + "</li>");
            }
            
            for (int i = 0; i < totalPages; i++)
            {
                int num = i + 1;

                if (((i <= 3) || (i > (totalPages - 3))) || ((i > (currentPage - 2)) && (i < (currentPage + 2))))
                {
                    var subBuilder = new TagBuilder("a") { InnerHtml = num.ToString(CultureInfo.InvariantCulture) };
                    if (i == currentPage)
                    {
                        subBuilder.MergeAttribute("href", "#");
                        builder.AppendLine("<li class=\"active\">" + subBuilder + "</li>");
                    }
                    else
                    {
                        subBuilder.MergeAttribute("href", pageUrl.Invoke(i));
                        builder.AppendLine("<li>" + subBuilder + "</li>");
                    }
                }
                else if ((i == 4) && (currentPage > 5))
                {
                    builder.AppendLine("<li class=\"disabled\"> <a href=\"#\">...</a> </li>");
                }
                else if ((i == (totalPages - 3)) && (currentPage < (totalPages - 4)))
                {
                    builder.AppendLine("<li class=\"disabled\"> <a href=\"#\">...</a> </li>");
                }
            }

            //Next
            var nextBuilder = new TagBuilder("a") { InnerHtml = "»" };
            if ((currentPage == totalPages - 1)) //|| (currentPage == 0))
            {
                nextBuilder.MergeAttribute("href", "#");
                builder.AppendLine("<li class=\"active\">" + nextBuilder + "</li>");
            }
            else
            {
                nextBuilder.MergeAttribute("href", pageUrl.Invoke(currentPage + 1));
                builder.AppendLine("<li>" + nextBuilder + "</li>");
            }

            return new MvcHtmlString("<ul class=\"pagination \">" + builder + "</ul>");
        }
    }
}