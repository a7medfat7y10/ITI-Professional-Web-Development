using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task_3.Startup))]
namespace Task_3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
