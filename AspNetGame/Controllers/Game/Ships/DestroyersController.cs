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

namespace AspNetGame.Controllers.Game.Ships
{
    public class DestroyersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Destroyers
        public async Task<ActionResult> Index()
        {
            return View(await db.Destroyers.ToListAsync());
        }

        // GET: Destroyers/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destroyer destroyer = await db.Destroyers.FindAsync(id);
            if (destroyer == null)
            {
                return HttpNotFound();
            }
            return View(destroyer);
        }

        // GET: Destroyers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destroyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrimaryKey,AttackPoint,Moving,Level,Health")] Destroyer destroyer)
        {
            if (ModelState.IsValid)
            {
                db.Destroyers.Add(destroyer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(destroyer);
        }

        // GET: Destroyers/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destroyer destroyer = await db.Destroyers.FindAsync(id);
            if (destroyer == null)
            {
                return HttpNotFound();
            }
            return View(destroyer);
        }

        // POST: Destroyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrimaryKey,AttackPoint,Moving,Level,Health")] Destroyer destroyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destroyer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(destroyer);
        }

        // GET: Destroyers/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destroyer destroyer = await db.Destroyers.FindAsync(id);
            if (destroyer == null)
            {
                return HttpNotFound();
            }
            return View(destroyer);
        }

        // POST: Destroyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Destroyer destroyer = await db.Destroyers.FindAsync(id);
            db.Destroyers.Remove(destroyer);
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
