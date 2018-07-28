using System.Collections.Generic;
using System.Data.Entity;
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
            : base("AuthenticationConnection", throwIfV1Schema: false)
        {
            if (this.Database.CreateIfNotExists())
            {
                Seed(this);
            }
            if (!this.Database.CompatibleWithModel(false))
            {
                this.Database.Delete();
                if (this.Database.CreateIfNotExists())
                {
                    Seed(this);
		}
	    }
        }

        private void Seed(ApplicationDbContext context)
        {
            List<IdentityRole> defaultRoles = new List<IdentityRole>
            {
                new IdentityRole() { Name = "Admin" },
                new IdentityRole() { Name = "Employee" },
                new IdentityRole() { Name = "Manager" }
            };

            //INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], 
            //[LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES 
            //(N'53c5b44c-5208-4319-804b-11bcac7a5aa2', N'fabien.lehouedec@gmail.com', 0, N'AACws3iAjLap/fFWVxHc1/47Fo8p9FOOILqEHo1weeHfRuUkaP1ZKPAL1jQYSca8XQ==',
            //N'359c4600-4b9e-4588-9556-b107ad06b164', NULL, 0, 0, NULL, 1, 0, N'fabien')


           // IdentityUser adminUser = new IdentityUser() { Email = "admin@mywebsite.com", PasswordHash =  }

            foreach (IdentityRole role in defaultRoles)
            {
                context.Roles.Add(role);
            }

            context.SaveChanges();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Ships.Scout> Scouts { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Ships.Cruiser> Cruisers { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Ships.Striker> Strikers { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Ships.Destroyer> Destroyers { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Defence.PowerShield> PowerShields { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Defence.LaserTower> LaserTowers { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Defence.MissileLauncher> MissileLaunchers { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Factories.SpaceShipyard> SpaceShipyards { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Factories.ResearchCenter> ResearchCenters { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Factories.WeaponFactory> WeaponFactories { get; set; }
    }
}
