using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Modelo.Startup))]
namespace Modelo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
