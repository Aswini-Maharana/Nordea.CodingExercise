using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nordea.CodingExercise.Startup))]
namespace Nordea.CodingExercise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
