using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TareaExamenFrame.Startup))]
namespace TareaExamenFrame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
