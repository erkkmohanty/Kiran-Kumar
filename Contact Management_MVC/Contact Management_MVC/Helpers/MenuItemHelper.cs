using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Contact_Management_MVC.Helpers
{
    /// <summary>
    /// This helper method renders a link within an HTML LI tag.
    /// A class="selected" attribute is added to the tag when
    /// the link being rendered corresponds to the current
    /// controller and action.
    /// 
    /// This helper method is used in the _Layout View 
    /// Page to display the website menu.
    /// </summary>
    public static class MenuItemHelper
    {
        public static MvcHtmlString MenuItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            string currentControllerName = Convert.ToString(helper.ViewContext.RouteData.Values["controller"]);
            string currentActionName = Convert.ToString(helper.ViewContext.RouteData.Values["action"]);
            var liBuilder = new TagBuilder("li");
            // Add selected class
            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                liBuilder.AddCssClass("selected");

            // Add link
            liBuilder.InnerHtml = Convert.ToString(helper.ActionLink(linkText, actionName, controllerName));

            // Render Tag Builder
            return MvcHtmlString.Create(liBuilder.ToString());
        }

    }
}