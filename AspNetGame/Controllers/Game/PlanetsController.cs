using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game
{
    public class PlanetsController : ReadController<Planet, long>
    {
        public PlanetsController()
        {
            Context = new GameDbContext();
        }

        public override DbSet<Planet> DbSet()
        {
            return ((GameDbContext)Context).PlanetFactories;
        }


    }
}