using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDay1.Startup))]
namespace MVCDay1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
