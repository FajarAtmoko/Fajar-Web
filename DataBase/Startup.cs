using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataBase.Startup))]
namespace DataBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
