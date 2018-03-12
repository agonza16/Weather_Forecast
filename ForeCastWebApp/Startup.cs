using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForeCastWebApp.Startup))]
namespace ForeCastWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
