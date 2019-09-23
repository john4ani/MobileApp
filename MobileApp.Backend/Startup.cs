using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MobileApp.Backend.Startup))]

namespace MobileApp.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}