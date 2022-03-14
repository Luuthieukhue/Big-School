using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab3_luuthieukhue.Startup))]
namespace lab3_luuthieukhue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
