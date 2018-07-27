using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
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

            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planet planet = Player.Planets.Where(p => p.PrimaryKey.Equals(id)).FirstOrDefault(null);
            if (planet == null)
            {
                return HttpNotFound();
            }
            return View(planet);
        }


    }
}