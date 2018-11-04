using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheStore.Site.Startup))]
namespace TheStore.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
