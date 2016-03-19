using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hack24.web.Startup))]
namespace hack24.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
