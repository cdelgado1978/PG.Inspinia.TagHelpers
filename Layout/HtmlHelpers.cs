
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PG.Inspinia.TagHelpers
{
    public static class HtmlHelpers
    {

        public static string IsSelected(this IHtmlHelper html,string area=null, string controller = null, string action = null, string cssClass = null)
        {
            if (string.IsNullOrEmpty(cssClass))
                cssClass = "active";

            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];
            var currentArea = (string)html.ViewContext.RouteData.Values["area"];

            if (string.IsNullOrEmpty(area))
                area = currentArea;

            if (string.IsNullOrEmpty(controller))
                controller = currentController;

            if (string.IsNullOrEmpty(action))
                action = currentAction;

            return area== currentArea && controller == currentController && action == currentAction ?
                cssClass : string.Empty;
        }

        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            var currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

    }
}
