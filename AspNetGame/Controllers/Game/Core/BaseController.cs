using AspNetGame.Models.Game.Core;
using AspNetGame.Models.Game.Units;
using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game.Core
{
    public abstract class BaseController<TEntity, TId> : Controller
        where TId: struct, IComparable<TId>
        where TEntity: BaseEntity<TId>, new()
    {
        protected BaseController(IRepository<TEntity, TId> repository)
        {
            Repository = repository;
        }

        protected IRepository<TEntity, TId> Repository { get; }

        
        public virtual async Task<ActionResult> Index()
        {
            return View(await Repository.GetAll());
        }

        public virtual async Task<ActionResult> Details(TId id)
        {
            ViewBag.Editing = false;
            TEntity entity = await Repository.Find(id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create([Bind]TEntity entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repository.Insert(entity);
                    await Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(entity);
        }

        public virtual async Task<ActionResult> Create()
        {
            ViewBag.Editing = true;

            TEntity entity = Activator.CreateInstance<TEntity>();
            return View(entity);
        }
    }
}