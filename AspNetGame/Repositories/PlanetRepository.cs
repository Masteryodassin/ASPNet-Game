using AspNetGame.Models.Game;
using AspNetGame.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Repositories
{
    public class PlanetRepository : GameRepository<Planet>
    {
        public PlanetRepository() : base() { }
       
    }
}