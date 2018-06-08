using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistreFoncier.Startup))]
namespace RegistreFoncier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
