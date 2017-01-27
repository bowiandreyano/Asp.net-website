using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ter2.Startup))]
namespace Ter2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
