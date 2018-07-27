using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AspNetGame.Models.Game.IoC;

namespace AspNetGame.Services
{
    public class GameModelManager : IInjectable
    {
        private GameDbContext Context { get; set; }

        public List<Building> BuildingsForPlanet(long planetId)
        {
            return Context.Buildings
                .Where(building => building.Planet.PrimaryKey.Equals(planetId))
                .ToList();
        }

        public void SelfInitialize()
        {
            Context = Resolve<GameDbContext>();
        }
    }
}