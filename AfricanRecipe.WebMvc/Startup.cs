using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AfricanRecipe.WebMvc.Startup))]
namespace AfricanRecipe.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
