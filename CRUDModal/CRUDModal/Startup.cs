using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDModal.Startup))]
namespace CRUDModal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
