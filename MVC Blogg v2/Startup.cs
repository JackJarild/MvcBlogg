using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Blogg_v2.Startup))]
namespace MVC_Blogg_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
