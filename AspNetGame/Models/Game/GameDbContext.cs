using AspNetGame.Models.Game.Core;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game
{
    public class GameDbContext: DbContext 
    {
        public GameDbContext() : base("GameConnection")
        {
            if (this.Database.CreateIfNotExists()) {
                Seed(this);
            }
            if (!this.Database.CompatibleWithModel(false))
            {
                this.Database.Delete();
                if (this.Database.CreateIfNotExists()) {
                    Seed(this);
                }
            }
        }

        private void Seed(GameDbContext context)
        {
        }

        public System.Data.Entity.DbSet<Building> Buildings { get; set; }

        public System.Data.Entity.DbSet<Unit> Units { get; set; }

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Core.Player> Players { get; set; }
        
        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Core.Planet> Planets { get; set; }
    }
}