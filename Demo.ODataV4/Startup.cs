using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo.ODataV4.Startup))]
namespace Demo.ODataV4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
