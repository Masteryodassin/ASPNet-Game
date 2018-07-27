using AspNetGame.Controllers.Game;
using AspNetGame.Models;
using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using static AspNetGame.Models.Game.IoC;

namespace AspNetGame.Providers
{

    public class GamePlayerProvider : IInjectable
    {
        public ApplicationDbContext AppContext { get; set; }
        public GameDbContext GameContext { get; set; }

        


        public GamePlayerProvider()
        {

        }

        public Player GetPlayer(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            string username = user.Identity.Name;
            Player player = GameContext.Players
                .Include("Planets")
                .FirstOrDefault(p => p.Username.Equals(username));

            if (player == null)
            {
                player = new Player() { Nickname = username, Username = username };
                GameContext.Players.Add(player);
                GameContext.SaveChanges();
            }

            if (player.Planets == null)
            {
                player.Planets = new List<Planet>();
            }

            List<Building>

            if (player.Planets.Count == 0)
            {
                player.Planets = new List<Planet>() {
                    new Planet()
                    {
                        Name = "Jupiter X.9",
                        IronStock = 20000,
                        GoldStock = 8000,
                        PlutoniumStock = 2000
                        Buildings = 
                    }
                };
                GameContext.SaveChanges();
            }

            return player;
        }

        public void SelfInitialize()
        {
            AppContext = IoC.Resolve<ApplicationDbContext>();
            GameContext = IoC.Resolve<GameDbContext>();
        }
    }
}