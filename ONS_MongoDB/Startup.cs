using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ONS_MongoDB.Startup))]
namespace ONS_MongoDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
