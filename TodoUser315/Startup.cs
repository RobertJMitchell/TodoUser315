using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoUser315.Startup))]
namespace TodoUser315
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
