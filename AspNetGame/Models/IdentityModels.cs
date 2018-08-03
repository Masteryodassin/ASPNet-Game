using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AspNetGame.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Notez que authenticationType doit correspondre à l'instance définie dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Ajouter des revendications d’utilisateur personnalisées ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("AuthenticationConnection")
        {
            if (Database.CreateIfNotExists())
            {
                Seed(this);
            }
            if (!Database.CompatibleWithModel(false))
            {
                Database.Delete();
                if (Database.CreateIfNotExists())
                {
                    Seed(this);
                }
            }
        }

        private void Seed(ApplicationDbContext context)
        {
            IdentityRole roleAdmin = new IdentityRole() { Name = RoleConstants.Admin };
            IdentityRole rolePlayer = new IdentityRole() { Name = RoleConstants.Player };

            context.Roles.Add(roleAdmin);
            context.Roles.Add(rolePlayer);

            ApplicationUser admin = context.Users
                 .Where(user => user.UserName.Equals("admin"))
                 .FirstOrDefault();           

            if (admin == null)
            {
                // admin - Admin123#
                admin = new ApplicationUser()
                {
                    Email = "admin@galacticgame.org",
                    EmailConfirmed = false,
                    PasswordHash = "AI8MPuTYyxre+v0z1VoRAsoD78MrBWJm5h6XyT6/9Vz8gQC4EzMx4tu7/PW8SHy1gg==",
                    SecurityStamp = "7090227b-8b7a-4139-b427-992666dc2766",
                    LockoutEnabled = true,
                    UserName = "admin"
                };
                context.Users.Add(admin);
                context.SaveChanges();

                admin.Roles.Add(new IdentityUserRole()
                {
                    RoleId = roleAdmin.Id,
                    UserId = admin.Id
                });
            }

            context.SaveChanges();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class RoleConstants
    {
        public static readonly string Admin = "Admin";
        public static readonly string Player = "Player";
    }
}