using AspNetGame.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers
{
	public class HomeController : Controller
	{
        private GameDbContext Context { get; set; }
        public HomeController(): base()
        {
            Context = IoC.Resolve<GameDbContext>();
        }
		public ActionResult Index()
		{
            ViewBag.PlayersCount = Context.Players.Count();
			return View();
		}
	}
}