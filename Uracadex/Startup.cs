using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Uracadex.Startup))]
namespace Uracadex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
