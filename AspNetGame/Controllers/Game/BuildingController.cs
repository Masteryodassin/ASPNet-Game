using AspNetGame.Controllers.Game.Core;
using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Units;
using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game
{
    [Authorize(Roles = "Player")]
    public class BuildingController : GameController<Planet>
    {
        

        public BuildingController() : base(new PlanetRepository())
        {
           
        }

        // GET: Building
        //public override Task<ActionResult> Index()
        //{
        //    return base.Index(GetPlanetBuilding());
        //}


        private async Task<IEnumerable<Planet>> GetPlanetBuilding(int Id)
        {
            IEnumerable<Planet>  tps = (await Repository.GetAllIncluding(p => p.Id == Id)).ToList();
            return tps;
        }
        
    }
}