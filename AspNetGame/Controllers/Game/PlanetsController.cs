using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
using AspNetGame.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game
{
    [Authorize]
    public class PlanetsController : GameControllerBase
    {
        public ActionResult Index()
        {
            return View(Player.Planets);
        }

        public ActionResult Details(long? id)
        {
            Planet planet = null;
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planet = Player.Planets.ToList().First(pl => pl.PrimaryKey.Equals(id.Value));
            List<Building> buildings = planet.Buildings;


          
            try
            {
                planet = Player.Planets.ToList().First(pl => pl.PrimaryKey.Equals(id.Value));
            } catch (InvalidOperationException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            

            return View(planet);
        }


    }
}