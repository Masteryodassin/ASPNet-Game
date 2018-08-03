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
        private GamePlayerProvider _provider;

        public GameController(IRepository<TEntity, long> repository) : 
            base(repository)
        {
            _provider = IoC.Resolve<GamePlayerProvider>();
        }

        protected Player Player
        {
            get
            {
                if (User != null)
                {
                    return _provider.GetPlayer(User);
                }
                else
                {
                    throw new Exception("Could not resolve the current player.");
                }
            }
        }

        public override async Task<ActionResult> Create([Bind] TEntity entity)
        {
            ViewBag.Player = Player;
            return await base.Create(entity);
        }

        public override ActionResult Create()
        {
            ViewBag.Player = Player;
            return base.Create();
        }

        public async override Task<ActionResult> Details(long id)
        {
            ViewBag.Player = Player;
            return await base.Details(id);
        }

        public async override Task<ActionResult> Index()
        {
            ViewBag.Player = Player;
            return await base.Index();
        }
    }
}