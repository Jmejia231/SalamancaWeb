using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using System.Collections.Generic;
using System.Web;

namespace SalamancaWeb.Utility
{
    public class UtilityClass
    {
        public static void constructAlert(bool success, string displayMessage)
        {
            HttpContext.Current.Session["messageAlert"] = displayMessage;
            HttpContext.Current.Session["titleAlert"] = success ? AlertTitle.Success : AlertTitle.Error;
            HttpContext.Current.Session["iconAlert"] = success ? AlertIcon.Success : AlertIcon.Error;
        }
    }
}