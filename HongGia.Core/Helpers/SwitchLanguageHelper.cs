﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using HongGia.Core.Parameters;

namespace HongGia.Core.Helpers
{
    public static class SwitchLanguageHelper
    {
        public static MvcHtmlString Switcher(this UrlHelper url, SwitchLanguageParameters parameter)
        {
			if (parameter == null ||
			    parameter.RouteData == null ||
			    string.IsNullOrEmpty(parameter.Name) == true)
			{
				return new MvcHtmlString(string.Empty);
			}

			var liTagBuilder = new TagBuilder("li");
            var aTagBuilder = new TagBuilder("a");

            var routeValueDictionary = new RouteValueDictionary(parameter.RouteData.Values);

            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (parameter.RouteData.Values["lang"] as string == parameter.Lang)
                {
                    liTagBuilder.AddCssClass("active");
                }
                else
                {
                    routeValueDictionary["lang"] = parameter.Lang;
                }
            }

            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.SetInnerText(parameter.Name);

            liTagBuilder.InnerHtml = aTagBuilder.ToString();

            return new MvcHtmlString(liTagBuilder.ToString());
        }

        public static MvcHtmlString DropdownSwitcher(this UrlHelper url, string name, IEnumerable<SwitchLanguageParameters> parameters)
        {
			if (parameters == null ||  parameters.Count()==0)
			{
				return new MvcHtmlString(string.Empty);
			}

			var liTagBuilder = new TagBuilder("li");
            liTagBuilder.AddCssClass("dropdown");

            var aTagBuilder = new TagBuilder("a");
            aTagBuilder.AddCssClass("dropdown-toggle");
            aTagBuilder.MergeAttribute("data-toggle", "dropdown");
            aTagBuilder.MergeAttribute("href", "#");

            var bTagBuilder = new TagBuilder("b");
            bTagBuilder.AddCssClass("caret");

            var ulTagBuilder = new TagBuilder("ul");
            ulTagBuilder.AddCssClass("dropdown-menu");

            foreach (var parameter in parameters)
            {
                ulTagBuilder.InnerHtml += Switcher(url, parameter);
            }

            aTagBuilder.InnerHtml = name + CurrentLanguage(parameters) + bTagBuilder.ToString();
            liTagBuilder.InnerHtml = aTagBuilder.ToString() + ulTagBuilder.ToString();

            return new MvcHtmlString(liTagBuilder.ToString());
        }

	    public static MvcHtmlString DropdownSwitcher(this UrlHelper url, string name, IEnumerable<SwitchLanguageParameters> parameters, string prevHtmlCode)
	    {
		    var result = DropdownSwitcher(url, name, parameters);

		    if (string.IsNullOrEmpty(prevHtmlCode) == true)
		    {
			    return result;
		    }

		    return new MvcHtmlString(result.ToString().Insert(result.ToString().IndexOf(name + CurrentLanguage(parameters) + '<', StringComparison.Ordinal), prevHtmlCode));
	    }
		
		private static string CurrentLanguage(IEnumerable<SwitchLanguageParameters> parameters)
        {
            var result = parameters.FirstOrDefault(x => x.Lang == x.RouteData.Values["lang"] as string);

            if (result == null)
            {
                return string.Empty;
            }

            return result.Lang;
        }
    }
}