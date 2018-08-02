using AspNetGame.Models.Game.Base;
using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Units;
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

        public System.Data.Entity.DbSet<UnitTemplate> UnitTemplates { get; set; }

        public System.Data.Entity.DbSet<Player> Players { get; set; }

        //public System.Data.Entity.DbSet<Planet> Planets { get; set; }
        
    }
}