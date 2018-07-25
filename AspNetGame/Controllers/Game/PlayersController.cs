using AspNetGame.Models;
using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game
{
    public class PlayersController : Controller
    {
        private GameDbContext db;
        private ApplicationDbContext context;
        // GET: Players

        public PlayersController()
        {
            db = new GameDbContext();
            context = new ApplicationDbContext();
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }
        /*

        // GET: GoldWarehouses/Details/5
        public async Task<ActionResult> Details()
        {
            IUser myUser =  context.Users.Find(User.Identity);
            Player player = await db.Players.All<>(myUser.UserName);

            if (player == null)
            {
                player.Nickname = myUser.UserName;
                db.Players.Add(player);
            }
            
            return View(player);
        }
        */
       
        public void createPlayerFromUser()
        {

        }

    }
}