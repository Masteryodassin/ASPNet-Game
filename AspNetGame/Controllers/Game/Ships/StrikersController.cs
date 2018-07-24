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
    public class StrikersController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: Strikers
        public async Task<ActionResult> Index()
        {
            return View(await db.Strikers.ToListAsync());
        }

        // GET: Strikers/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Striker striker = await db.Strikers.FindAsync(id);
            if (striker == null)
            {
                return HttpNotFound();
            }
            return View(striker);
        }

        // GET: Strikers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Strikers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,AttackPoint,Moving,Level,Health")] Striker striker)
        {
            if (ModelState.IsValid)
            {
                db.Strikers.Add(striker);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(striker);
        }

        // GET: Strikers/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Striker striker = await db.Strikers.FindAsync(id);
            if (striker == null)
            {
                return HttpNotFound();
            }
            return View(striker);
        }

        // POST: Strikers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,AttackPoint,Moving,Level,Health")] Striker striker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(striker).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(striker);
        }

        // GET: Strikers/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Striker striker = await db.Strikers.FindAsync(id);
            if (striker == null)
            {
                return HttpNotFound();
            }
            return View(striker);
        }

        // POST: Strikers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Striker striker = await db.Strikers.FindAsync(id);
            db.Strikers.Remove(striker);
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
