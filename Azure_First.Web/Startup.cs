using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Azure_First.Web.Startup))]
namespace Azure_First.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}