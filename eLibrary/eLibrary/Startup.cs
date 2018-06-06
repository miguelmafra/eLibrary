using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eLibrary.Startup))]
namespace eLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
