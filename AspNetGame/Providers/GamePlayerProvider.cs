using AspNetGame.Models;
using AspNetGame.Models.Game;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
                .FirstOrDefault(p => p.Username.Equals(username));

            if (player == null)
            {
                player = new Player() { Name = username, Username = username };
                GameContext.Players.Add(player);
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