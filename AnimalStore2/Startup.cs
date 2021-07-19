using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimalStore2.Startup))]
namespace AnimalStore2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}