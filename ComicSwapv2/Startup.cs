using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComicSwapv2.Startup))]
namespace ComicSwapv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
