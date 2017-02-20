using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DropDown_MVC.Startup))]
namespace DropDown_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
