using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetGame.Models;
using AspNetGame.Models.Game.Factories;
using AspNetGame.Models.Game;

namespace AspNetGame.Controllers.Game.Factories
{
    public class SpaceShipyardsController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: SpaceShipyards
        public async Task<ActionResult> Index()
        {
            return View(await db.SpaceShipyards.ToListAsync());
        }

        // GET: SpaceShipyards/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpaceShipyard spaceShipyard = await db.SpaceShipyards.FindAsync(id);
            if (spaceShipyard == null)
            {
                return HttpNotFound();
            }
            return View(spaceShipyard);
        }

        // GET: SpaceShipyards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpaceShipyards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,Level,Health")] SpaceShipyard spaceShipyard)
        {
            if (ModelState.IsValid)
            {
                db.SpaceShipyards.Add(spaceShipyard);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(spaceShipyard);
        }

        // GET: SpaceShipyards/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpaceShipyard spaceShipyard = await db.SpaceShipyards.FindAsync(id);
            if (spaceShipyard == null)
            {
                return HttpNotFound();
            }
            return View(spaceShipyard);
        }

        // POST: SpaceShipyards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,Level,Health")] SpaceShipyard spaceShipyard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spaceShipyard).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(spaceShipyard);
        }

        // GET: SpaceShipyards/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpaceShipyard spaceShipyard = await db.SpaceShipyards.FindAsync(id);
            if (spaceShipyard == null)
            {
                return HttpNotFound();
            }
            return View(spaceShipyard);
        }

        // POST: SpaceShipyards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            SpaceShipyard spaceShipyard = await db.SpaceShipyards.FindAsync(id);
            db.SpaceShipyards.Remove(spaceShipyard);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
