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

        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Core.Player> Players { get; set; }
            
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
        public System.Data.Entity.DbSet<AspNetGame.Models.Game.Core.Planet> Planets { get; set; }
    }
}