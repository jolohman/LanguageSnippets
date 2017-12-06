using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LanguageSnippets.Web.Startup))]
namespace LanguageSnippets.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
