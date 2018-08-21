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
    /// <summary>
    /// The context for the game model. 
    /// The database is automatically flushed and rebuilt
    /// if it doesn't exist yet or if the model has changed
    /// </summary>
    public class GameDbContext: DbContext 
    {
        public GameDbContext() : base("GameConnection")
        {
            //Database.Delete();
            if (this.Database.CreateIfNotExists()) {
                Seed(this);
            }
            if (!this.Database.CompatibleWithModel(false))
            {
                Database.Delete();
                if (this.Database.CreateIfNotExists()) {
                    Seed(this);
                }
            }
        }

        /// <summary>
        /// A method called at each creation of the database
        /// </summary>
        /// <param name="context"></param>
        private void Seed(GameDbContext context)
        {
        }

        /// <summary>
        /// Adds properties to model
        /// </summary>
        /// <param name="modelBuilder">A builder for the model definition</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Adding a concatenated unique index on Player.Username + Player.Nickname
            modelBuilder.Entity<Player>()
                .HasIndex(p => new { p.Nickname, p.Username }).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Unit templates DbSet
        /// </summary>
        public System.Data.Entity.DbSet<UnitTemplate> UnitTemplates { get; set; }

        /// <summary>
        /// Players DbSet
        /// </summary>
        public System.Data.Entity.DbSet<Player> Players { get; set; }
        
        /// <summary>
        /// Planets DbSet
        /// </summary>
        public System.Data.Entity.DbSet<Planet> Planets { get; set; }

        /// <summary>
        /// Params DbSet
        /// </summary>
        public System.Data.Entity.DbSet<Param> Params { get; set; }

    }
}