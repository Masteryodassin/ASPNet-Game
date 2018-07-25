using AspNetGame.Models;
using AspNetGame.Models.Game;
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
    public interface IBaseController<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        /// <summary>
        /// A method that provides to the controller logic the DbSet to use to manage data entity.
        /// </summary>
        /// <returns></returns>
        DbSet<TEntity> DbSet();
    }

    public interface IMvcReadOperations<TId>
    {
        Task<ActionResult> Index();

        Task<ActionResult> Details(TId id);
    }

    public abstract class BaseController<TEntity, TId> : Controller, IBaseController<TEntity, TId> 
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
    }

    public abstract class ReadController<TEntity, TId> : BaseController<TEntity, TId>, IMvcReadOperations<TId>
    where TEntity : BaseEntity<TId>
    {

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


    }
}