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
            : base("DefaultConnection", throwIfV1Schema: false)
        {

            this.Database.CreateIfNotExists();
            if (!this.Database.CompatibleWithModel(false))
            {
                this.Database.Delete();
                this.Database.CreateIfNotExists();
            }
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Ships.Scout> Scouts { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Mines.GoldMine> GoldMines { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Mines.PlutoniumMine> PlutoniumMines { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Mines.IronMine> IronMines { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Stores.PlutoniumWarehouse> PlutoniumWarehouses { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Stores.GoldWarehouse> GoldWarehouses { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Stores.IronWarehouse> IronWarehouses { get; set; }

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