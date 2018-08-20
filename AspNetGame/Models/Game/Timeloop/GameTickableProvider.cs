using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspNetGame.Models.Game.Timeloop
{
    public class GameTickableProvider : ITickableProvider
    {

        private GameDbContext Context = IoC.Resolve<GameDbContext>();
        private PlayerRepository Players = IoC.Resolve<PlayerRepository>();

        private List<ITickable> tickables = new List<ITickable>();


        public GameTickableProvider()
        {
            Init();
        }

        private async void Init()
        {
            tickables.AddRange(await Players.GetAll());
        }

        public async Task<IEnumerable<ITickable>> Provide()
        {
            var tickables = new List<ITickable>();
            tickables.AddRange(await Players.GetAll());
            return tickables;
        }
    }
}