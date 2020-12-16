using APC_BarbaraCoscolim_P8_v1.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APC_BarbaraCoscolim_P8_v1.Startup))]
namespace APC_BarbaraCoscolim_P8_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Criar role Admin e adiciona um user neste role
            StartupIdentity identityObject01 = new StartupIdentity("Admin", "admin01@teste.com", "123456Oi*", "admin01@teste.com");
            StartupIdentity.CreateStartupRolesAndUser(identityObject01);

            // Criar role User e adiciona um user neste role
            StartupIdentity identityObject02 = new StartupIdentity("User", "user01@teste.com", "123456Oi*", "user01@teste.com");
            StartupIdentity.CreateStartupRolesAndUser(identityObject02);
        }
    }
}
