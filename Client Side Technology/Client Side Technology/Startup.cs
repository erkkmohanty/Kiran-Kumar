using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Client_Side_Technology.Startup))]
namespace Client_Side_Technology
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
