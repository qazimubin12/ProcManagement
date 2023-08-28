using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProcManagement.Startup))]
namespace ProcManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }
    }
}
