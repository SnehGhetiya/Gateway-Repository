using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBootstrapDemo.Startup))]
namespace MVCBootstrapDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
