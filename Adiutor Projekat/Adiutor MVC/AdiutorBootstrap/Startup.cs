using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdiutorBootstrap.Startup))]
namespace AdiutorBootstrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
