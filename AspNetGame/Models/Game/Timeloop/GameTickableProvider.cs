using AspNetGame.Models.Game.Core;
using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspNetGame.Models.Game.Timeloop
{
    public class GameTickables : ITickable
    {

        private GameDbContext Context = IoC.Resolve<GameDbContext>();
        
        private PlayerRepository Players = IoC.Resolve<PlayerRepository>();



        public GameTickables()
        {
        }


        public async Task<IEnumerable<ITickable>> Get()
        {
            var tickables = new List<ITickable>();

            tickables.AddRange(await Players.GetAll());
            return tickables;
        }

        public async void Tick(long count)
        {
            foreach (var tickable in await Get())
            {
                tickable.Tick(count);
                await Players.Save();
            }
            
        }
    }
}