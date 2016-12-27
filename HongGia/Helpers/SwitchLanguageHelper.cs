﻿using System.Web.Mvc;
using System.Web.Routing;

namespace HongGia.Helpers
{
    public static class SwitchLanguageHelper
    {
        public static MvcHtmlString Switcher(this UrlHelper url, string name, RouteData routeData, string lang)
        {
            var liTagBuilder = new TagBuilder("li");
            var aTagBuilder = new TagBuilder("a");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);

            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (routeData.Values["lang"] as string == lang)
                {
                    liTagBuilder.AddCssClass("active");
                }
                else
                {
                    routeValueDictionary["lang"] = lang;
                }
            }

            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.SetInnerText(name);

            liTagBuilder.InnerHtml = aTagBuilder.ToString();

            return new MvcHtmlString(liTagBuilder.ToString());
        }
    }
}