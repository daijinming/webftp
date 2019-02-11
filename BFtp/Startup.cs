using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BFtp.Startup))]
namespace BFtp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
