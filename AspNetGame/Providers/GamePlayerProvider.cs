using AspNetGame.Models;
using AspNetGame.Models.Game;
using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading.Tasks;
using static AspNetGame.Models.Game.IoC;

namespace AspNetGame.Providers
{

    public class GamePlayerProvider : IInjectable
    {
        public ApplicationDbContext AppContext { get; set; }
        
        public PlayerRepository PlayerRepository { get; set; }

        public GamePlayerProvider()
        {
        }

        public async Task<Player> GetPlayer(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            string username = user.Identity.Name;
            Player player = await PlayerRepository
                .Find(p => p.Username.Equals(username));

            if (player == null)
            {
                player = new Player() { Name = username, Username = username };
                PlayerRepository.Insert(player);
                await PlayerRepository.Save();
            }

            return player;
        }

        public void SelfInitialize()
        {
            AppContext = IoC.Resolve<ApplicationDbContext>();
            PlayerRepository = IoC.Resolve<PlayerRepository>();
        }
    }
}