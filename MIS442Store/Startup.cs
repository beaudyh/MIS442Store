using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIS442Store.Startup))]
namespace MIS442Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
