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
    public class BuildingController : GameController<UnitTemplate>
    {
        

        public BuildingController() : base(new UnitTemplateRepository())
        {
           
        }

        // GET: Building
        
          private async Task<IEnumerable<UnitTemplate>> GetPlanetBuilding(int Id)
        {
            return (await Repository.GetAllIncluding(u => u.isActive & u.Planets.Exists(p => p.Id == Id))).ToList();
        }
        
    }
}