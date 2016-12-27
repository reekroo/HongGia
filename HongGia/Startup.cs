using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HongGia.Startup))]
namespace HongGia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
