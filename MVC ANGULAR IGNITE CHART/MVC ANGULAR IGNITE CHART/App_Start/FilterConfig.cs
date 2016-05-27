using System.Web;
using System.Web.Mvc;

namespace MVC_ANGULAR_IGNITE_CHART
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
