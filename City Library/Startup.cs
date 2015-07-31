using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(City_Library.Startup))]
namespace City_Library
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
