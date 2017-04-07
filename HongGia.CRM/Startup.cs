using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HongGia.CRM.Startup))]
namespace HongGia.CRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
