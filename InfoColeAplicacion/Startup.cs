using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfoColeAplicacion.Startup))]
namespace InfoColeAplicacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
