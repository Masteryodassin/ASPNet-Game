using AspNetGame.Models.Game;
using AspNetGame.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AspNetGame.Repositories
{
    public class PlanetRepository : GameRepository<Planet>
    {
        public PlanetRepository() : base() { }

        protected override Expression<Func<Planet, object>>[] DefaultIncludedProperties()
        {
            return new Expression<Func<Planet, object>>[]
            {
                planet => planet.Units
            };
        }
    }
}