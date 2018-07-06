using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VaktiImProject.Startup))]
namespace VaktiImProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
