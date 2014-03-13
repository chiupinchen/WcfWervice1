using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinqToSqlDiscovery.Startup))]
namespace LinqToSqlDiscovery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
