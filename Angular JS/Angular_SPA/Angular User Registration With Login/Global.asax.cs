using System.Web;
using System.Web.Http;

namespace Angular_User_Registration_With_Login
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}