using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Units;
using AspNetGame.Providers;
using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game.Core
{
    
    public abstract class GameController<TEntity> : BaseController<TEntity, long>
        where TEntity: BaseEntity<long>, new()
    {
        private GamePlayerProvider provider;

        public GameController(IRepository<TEntity, long> repository) : 
            base(repository)
        {
            provider = IoC.Resolve<GamePlayerProvider>();
        }

        protected async Task<Player> GetPlayer()
        {
            if (User != null)
            {
                return await provider.GetPlayer(User);
            }
            else
            {
                throw new Exception("Could not resolve the current player.");
            }
        }



        public override async Task<ActionResult> Create([Bind] TEntity entity)
        {
            ViewBag.Player = await GetPlayer();
            return await base.Create(entity);
        }

        public override async Task<ActionResult> Create()
        {
            ViewBag.Player = await GetPlayer();
            return await base.Create();
        }

        public async override Task<ActionResult> Details(long id)
        {
            ViewBag.Player = await GetPlayer();
            return await base.Details(id);
        }

        public async override Task<ActionResult> Index()
        {
            ViewBag.Player = await GetPlayer();
            return await base.Index();
        }
    }
}