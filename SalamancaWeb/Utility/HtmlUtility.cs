using System.Web.Mvc;

namespace SalamancaWeb.Utility {
    public static class HtmlUtility {
        public static string IsActive(this HtmlHelper html, string control, string action) {
            var routeData = html.ViewContext.RouteData;

            var routeControl = (string)routeData.Values["controller"];

            // must match both
            var returnActive = control == routeControl;

            return returnActive ? "active" : "";
        }
    }
}