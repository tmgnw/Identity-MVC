using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityMVC.Startup))]
namespace IdentityMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
