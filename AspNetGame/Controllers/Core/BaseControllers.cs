using AspNetGame.Models;
using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Core;
using AspNetGame.Providers;
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
    public abstract class GameControllerBase : Controller
    {
        private readonly GameDbContext context = IoC.Resolve<GameDbContext>();
        private readonly GamePlayerProvider playerProvider = IoC.Resolve<GamePlayerProvider>();

        public Player Player
        {
            get {
                if (playerProvider != null && User != null)
                {
                    return playerProvider.GetPlayer(User);
                } else
                {
                    throw new Exception("PlayerProvider or User must not be null.");
                }
            }
        }

        public GameDbContext Context { get { return context; } }

    }
    /*public interface IBaseController<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        /// <summary>
        /// A method that provides to the controller logic the DbSet to use to manage data entity.
        /// </summary>
        /// <returns></returns>
        DbSet<TEntity> DbSet();
    }*/

    /*public interface IMvcReadOperations<TId>
    {
        Task<ActionResult> Index();

        Task<ActionResult> Details(TId id);
    }*/

    /*public abstract class BaseController<TEntity, TId> : Controller
        where TEntity : BaseEntity<TId>
    {
        private DbContext context;

        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }
        public abstract DbSet<TEntity> DbSet();

        /// <summary>
        /// A method that provides the view name.
        /// </summary>
        /// <returns></returns>
        public virtual string ViewName() { return null; }
    }*/

    /*public abstract class ReadController<TEntity, TId> : GameControllerBase<TEntity, TId>, IMvcReadOperations<TId>
    where TEntity : BaseEntity<TId>
    {

        protected ReadController() : base() { }

        public async Task<ActionResult> Index()
        {
            return View(await DbSet().ToListAsync());   
        }

        public async Task<ActionResult> Details(TId id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEntity entity = await DbSet().FindAsync(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        public new ViewResult View(object model) {
            if (ViewName() == null)
                return base.View(model);

            return base.View(ViewName(), model);
        }

    
    }*/
}