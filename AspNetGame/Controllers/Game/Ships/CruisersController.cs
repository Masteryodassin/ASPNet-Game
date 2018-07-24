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
using AspNetGame.Models.Game.Ships;
using AspNetGame.Models.Game;

namespace AspNetGame.Controllers.Game.Ships
{
    public class CruisersController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: Cruisers
        public async Task<ActionResult> Index()
        {
            return View(await db.Cruisers.ToListAsync());
        }

        // GET: Cruisers/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruiser cruiser = await db.Cruisers.FindAsync(id);
            if (cruiser == null)
            {
                return HttpNotFound();
            }
            return View(cruiser);
        }

        // GET: Cruisers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cruisers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,AttackPoint,Moving,Level,Health")] Cruiser cruiser)
        {
            if (ModelState.IsValid)
            {
                db.Cruisers.Add(cruiser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cruiser);
        }

        // GET: Cruisers/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruiser cruiser = await db.Cruisers.FindAsync(id);
            if (cruiser == null)
            {
                return HttpNotFound();
            }
            return View(cruiser);
        }

        // POST: Cruisers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,AttackPoint,Moving,Level,Health")] Cruiser cruiser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cruiser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cruiser);
        }

        // GET: Cruisers/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruiser cruiser = await db.Cruisers.FindAsync(id);
            if (cruiser == null)
            {
                return HttpNotFound();
            }
            return View(cruiser);
        }

        // POST: Cruisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Cruiser cruiser = await db.Cruisers.FindAsync(id);
            db.Cruisers.Remove(cruiser);
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
