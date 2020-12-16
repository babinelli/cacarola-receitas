using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public class StartupIdentity
    {
        #region Properties
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        #endregion

        #region Constructor
        public StartupIdentity(string role, string email, string password, string username)
        {
            Role = role;
            Email = email;
            Password = password;
            Username = username;
        }
        #endregion

        #region Methods
        public static void CreateStartupRolesAndUser(StartupIdentity identityObject)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists(identityObject.Role))
            {
                // Cria o role    
                var role = new IdentityRole();
                role.Name = identityObject.Role;
                roleManager.Create(role);

                // Cria o user
                var user = new ApplicationUser();
                user.UserName = identityObject.Username;
                user.Email = identityObject.Email;

                var statusUser = userManager.Create(user, identityObject.Password);

                // Adiciona user ao Role    
                if (statusUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, role.Name);
                }
            }

        }
        #endregion
    }
}
