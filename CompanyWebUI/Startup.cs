using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyWebUI.Startup))]
namespace CompanyWebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
