using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetUnity.Startup))]
namespace PetUnity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
