using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApresentacaoWebApi.Startup))]
namespace ApresentacaoWebApi
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
