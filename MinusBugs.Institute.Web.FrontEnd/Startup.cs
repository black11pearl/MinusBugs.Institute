using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinusBugs.Institute.Web.FrontEnd.Startup))]
namespace MinusBugs.Institute.Web.FrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
