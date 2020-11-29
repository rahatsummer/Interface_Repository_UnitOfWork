using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnderstandRepo.UI.Startup))]
namespace UnderstandRepo.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
